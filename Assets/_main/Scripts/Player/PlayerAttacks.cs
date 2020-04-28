using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    SWORD,
    BOW,
    STAFF,
    GUN
}

public class PlayerAttacks : MonoBehaviour
{
    [HideInInspector] public static PlayerAttacks playerAttacks;

    [Header("Player Setup")]
    public Weapon currentWeapon;
    public GameObject currentProjectile;
    public Transform projectileSpawner;

    [Header("Colliders Setup")]
    public Collider2D groundHit;
    public Collider2D dashHit;
    public Collider2D slashHit;

    public int slashes = 0;

    void Awake()
    {
        playerAttacks = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (PlayerMovement.playerMovement.dashDirection != 0)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            dashHit.gameObject.SetActive(true);
            //Dash down mechanic to make an area attack
            if (PlayerMovement.playerMovement.isGrounded)
            {
                if (PlayerMovement.playerMovement.dashDirection == 4)
                {
                    // Place where the dash down attack is activated
                    FeedbackManager.feedbackManager.StartCoroutine(FeedbackManager.feedbackManager.InstantiateParticles(transform.position, FeedbackManager.feedbackManager.dashGroundParticles));
                    groundHit.gameObject.SetActive(true);
                    FeedbackManager.feedbackManager.ShakeCamera(FeedbackManager.feedbackManager.groundDashNoise);
                }
            }
            else
            {
                groundHit.gameObject.SetActive(false);
            }
        }
        else
        {
            groundHit.gameObject.SetActive(false);
            dashHit.gameObject.SetActive(false);
            Physics2D.IgnoreLayerCollision(8, 9, false);
        }
    }

    public IEnumerator Slash()
    {
        slashHit.gameObject.SetActive(true);
        slashHit.enabled = true;
        yield return new WaitForSeconds(0.1f);
        slashHit.enabled = false;
        slashHit.gameObject.SetActive(false);
    }

    public void Shoot()
    {
        GameObject go = Instantiate(currentProjectile, projectileSpawner.position, projectileSpawner.rotation);
        go.GetComponent<Rigidbody2D>().AddForce(transform.right * go.GetComponent<SCR_ProjectileBehaviour>().projectile.speed);
        Destroy(go, 2f);
    }
}
