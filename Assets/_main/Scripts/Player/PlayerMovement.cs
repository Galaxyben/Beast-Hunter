using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public static PlayerMovement playerMovement;

    public float speed;
    public float jumpForce;
    public float dashForce;
    public float fallMultiplier;
    public int jumpCount;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    private Rigidbody2D rigi;

    private void Awake()
    {
        playerMovement = this;
    }

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
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
        
    }

    public void Move(float xAxis)
    {
        rigi.velocity = new Vector2(xAxis * speed * Time.deltaTime, rigi.velocity.y);
    }

    public void Jump()
    {
        rigi.velocity = Vector2.up * jumpForce;
    }

    public void Dash(float xAxis)
    {
        rigi.AddForce(new Vector2(xAxis * dashForce, rigi.velocity.y), ForceMode2D.Impulse);
    }
}
