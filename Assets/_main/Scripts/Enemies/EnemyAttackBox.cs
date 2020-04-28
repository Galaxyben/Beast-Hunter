using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FeedbackManager.feedbackManager.FB_Hit();
            PlayerStats.playerStats.ReceiveHit(damage);
            PlayerStats.playerStats.StartCoroutine(PlayerStats.playerStats.Knockback(0.02f, 350f, new Vector2(InputManager.inputManager.xAxis, InputManager.inputManager.yAxis)));
        }
    }
}
