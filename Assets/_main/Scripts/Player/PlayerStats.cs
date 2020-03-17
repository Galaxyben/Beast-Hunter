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

    public void ReceiveHit(int _amount)
    {
        if(!inmunity)
        {
            hp -= _amount;
            SetInmunity(1.5f);
        }
    }

    public IEnumerator SetInmunity(float time)
    {
        inmunity = true;
        yield return new WaitForSeconds(time);
        inmunity = false;
    }
}
