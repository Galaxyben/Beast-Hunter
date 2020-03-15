using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    SWORD,
    BOW,
    STAFF
}

public class PlayerAttacks : MonoBehaviour
{
    [HideInInspector] public static PlayerAttacks playerAttacks;

    public Weapon currentWeapon;

    [Header("Colliders Setup")]
    public Collider2D groundHit;
    public Collider2D dashHit;

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
}
