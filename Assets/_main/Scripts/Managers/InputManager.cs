using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager;

    float xAxis;
    float yAxis;

    private void Awake()
    {
        inputManager = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if(GameStateManager.gameStateManager.gameState == GameState.GAMEPLAY)
        {
            xAxis = Input.GetAxis("Horizontal");
            yAxis = Input.GetAxis("Vertical");

            if(Input.GetButtonDown("Jump"))
            {
                PlayerMovement.playerMovement.Jump();
            }
            if(Input.GetButtonDown("Dash"))
            {
                PlayerMovement.playerMovement.StartCoroutine(PlayerMovement.playerMovement.DashSpriteDuplication());
                if (xAxis < 0 && yAxis == 0)
                    PlayerMovement.playerMovement.dashDirection = 1;
                else if (xAxis > 0 && yAxis == 0)
                    PlayerMovement.playerMovement.dashDirection = 2;
                else if (xAxis == 0 && yAxis > 0)
                    PlayerMovement.playerMovement.dashDirection = 3;
                else if (xAxis == 0 && yAxis < 0)
                    PlayerMovement.playerMovement.dashDirection = 4;

                else if (xAxis > 0 && yAxis > 0)
                    PlayerMovement.playerMovement.dashDirection = 5;
                else if (xAxis > 0 && yAxis < 0)
                    PlayerMovement.playerMovement.dashDirection = 6;
                else if (xAxis < 0 && yAxis < 0)
                    PlayerMovement.playerMovement.dashDirection = 7;
                else if (xAxis < 0 && yAxis > 0)
                    PlayerMovement.playerMovement.dashDirection = 8;
            }
        }
    }
    void FixedUpdate()
    {
        if (GameStateManager.gameStateManager.gameState == GameState.GAMEPLAY)
        {
            PlayerMovement.playerMovement.Move(xAxis);
        }
    }
}
