using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public static PlayerMovement playerMovement;

    [Header("General Movement")]
    public float speed;

    [Header("Jump Stats")]
    public float jumpForce;
    public float fallMultiplier;
    public int jumpCount;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    [Header("Dash Stats")]
    public float dashForce;
    private float dashTime;
    public float startDashTime;
    [HideInInspector]public int dashDirection;
    public EchoEffect echo;

    private Rigidbody2D rigi;

    private void Awake()
    {
        playerMovement = this;
    }

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        echo = GetComponent<EchoEffect>();
        echo.enabled = false;
    }
    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.1f, groundLayer);

        if (rigi.velocity.y < 0)
        {
            rigi.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Dash();
    }

    public void Move(float xAxis)
    {
        rigi.velocity = new Vector2(xAxis * speed * Time.deltaTime, rigi.velocity.y);
    }

    public void Jump()
    {
        rigi.velocity = Vector2.up * jumpForce;
    }

    public void Dash()
    {
        if (dashDirection != 0)
        {
            echo.enabled = true;
            if (dashTime <= 0)
            {
                dashDirection = 0;
                dashTime = startDashTime;
                rigi.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (dashDirection == 1)
                    rigi.velocity = Vector2.left * dashForce;           // Dash Left
                else if (dashDirection == 2)
                    rigi.velocity = Vector2.right * dashForce;          // Dash Right
                else if (dashDirection == 3)
                    rigi.velocity = Vector2.up * dashForce;             // Dash Up
                else if (dashDirection == 4)
                    rigi.velocity = Vector2.down * dashForce;           // Dash Down

                else if (dashDirection == 5)
                    rigi.velocity = new Vector2(1, 1) * dashForce;      // Dash Up Right
                else if (dashDirection == 6)
                    rigi.velocity = new Vector2(1, -1) * dashForce;     // Dash Down Right
                else if (dashDirection == 7)
                    rigi.velocity = new Vector2(-1, -1) * dashForce;    // Dash Down Left
                else if (dashDirection == 8)
                    rigi.velocity = new Vector2(-1, 1) * dashForce;     // Dash Up Left
            }
        }
        else
        {
            echo.enabled = false;
        }
    }

    public IEnumerator StartDash()
    {
        FeedbackManager.feedbackManager.ShakeCamera(FeedbackManager.feedbackManager.dashNoise);
        yield return null;
    }
}
