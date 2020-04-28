using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager;

    public float xAxis;
    public float yAxis;

    float dashCharge;

    private void Awake()
    {
        inputManager = this;
    }

    void Start()
    {
        dashCharge = 0f;
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

            if (Input.GetButton("Dash"))
            {
                dashCharge += 1f * Time.deltaTime;
            }

            if (Input.GetButtonUp("Dash"))
            {
                if(dashCharge >= PlayerMovement.playerMovement.dashChargeTime)
                {
                    if (PlayerMovement.playerMovement.dashEnabled)
                    {
                        PlayerMovement.playerMovement.StartCoroutine(PlayerMovement.playerMovement.StartDash());
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
                dashCharge = 0;
            }
            if(Input.GetButtonDown("Fire1"))
            {
                switch(PlayerAttacks.playerAttacks.currentWeapon)
                {
                    case Weapon.BOW:
                        break;
                    case Weapon.GUN:
                        PlayerAttacks.playerAttacks.Shoot();
                        break;
                    case Weapon.STAFF:
                        break;
                    case Weapon.SWORD:
                        PlayerAttacks.playerAttacks.StartCoroutine(PlayerAttacks.playerAttacks.Slash());
                        break;
                    default:
                        break;
                }
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                if ( PlayerAttacks.playerAttacks.currentWeapon != Weapon.SWORD)
                    PlayerAttacks.playerAttacks.currentWeapon = Weapon.SWORD;
                else
                    PlayerAttacks.playerAttacks.currentWeapon = Weapon.GUN;
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
