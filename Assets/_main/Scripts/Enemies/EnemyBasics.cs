using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    [Header("Basic Stats")]
    public int hp;
    public bool inmunity;

    [Header("Setup")]
    public SpriteRenderer spriteRend;

    void Start()
    {
        
    }
    
    void Update()
    {
        
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
