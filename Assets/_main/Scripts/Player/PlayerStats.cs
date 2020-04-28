using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public static PlayerStats playerStats;

    [Header("Basic Stats")]
    public int hp;
    public int armor;
    public bool inmunity;

    [Header("Settings")]
    public SpriteRenderer playerSprite;

    private void Awake()
    {
        playerStats = this;
    }

    void Start()
    {
        inmunity = false;
    }
    
    void Update()
    {
        
    }

    public IEnumerator ReceiveHit(int _amount)
    {
        if(!inmunity)
        {
            hp -= _amount;
            SetInmunity(1.5f);
            playerSprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = Color.white;
        }
    }

    public IEnumerator Knockback(float knockdur, float knockbackPwr, Vector2 knockbackDir)
    {
        float timer = 0;
        while(knockdur > timer)
        {
            timer += Time.deltaTime;
            PlayerMovement.playerMovement.rigi.AddForce(new Vector2(knockbackDir.x * knockbackPwr, knockbackDir.y * knockbackPwr));
        }
        yield return 0;
    }

    public IEnumerator SetInmunity(float time)
    {
        playerSprite.color = Color.blue;
        inmunity = true;
        yield return new WaitForSeconds(time);
        inmunity = false;
        playerSprite.color = Color.white;
    }
}
