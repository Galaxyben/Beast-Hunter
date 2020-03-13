using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager;

    private void Awake()
    {
        inputManager = this;
    }

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if(GameStateManager.gameStateManager.gameState == GameState.GAMEPLAY)
        {
            float xAxis = Input.GetAxis("Horizontal");
            PlayerMovement.playerMovement.Move(xAxis);

            if(Input.GetButtonDown("Jump"))
            {
                PlayerMovement.playerMovement.Jump();
            }

            if(Input.GetAxis("Horizontal") != 0)
            {
                if(Input.GetButtonDown("Dash"))
                {
                    PlayerMovement.playerMovement.Dash(xAxis);
                }
            }
        }
    }
}
