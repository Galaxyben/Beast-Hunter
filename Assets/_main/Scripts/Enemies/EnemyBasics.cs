﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    public GameObject target;

    [Header("Basic Stats")]
    public int hp;
    public bool inmunity;
    public float moveSpeed;

    [Header("Setup")]
    public SpriteRenderer spriteRend;
    public Rigidbody2D rigi;

    public float distanceFromTarget;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = PlayerStats.playerStats.gameObject;
    }
    
    void Update()
    {
        distanceFromTarget = Vector2.Distance(transform.position, target.transform.position);

        if (distanceFromTarget < 10f)
        {
            if ((transform.position.normalized - target.transform.position.normalized).x < 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HitCollider"))
        {
            StartCoroutine(GetHit());
        }
    }

    public IEnumerator GetHit()
    {
        spriteRend.color = Color.red;
        FeedbackManager.feedbackManager.StartCoroutine(FeedbackManager.feedbackManager.FB_Hit());
        yield return new WaitForSeconds(0.2f);
        spriteRend.color = Color.white;
    }
}
