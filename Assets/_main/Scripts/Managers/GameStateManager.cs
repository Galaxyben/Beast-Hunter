using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MAIN_MENU,
    PAUSE,
    GAMEPLAY,
    INVENTORY
}

public class GameStateManager : MonoBehaviour
{
    [HideInInspector] public static GameStateManager gameStateManager;

    public GameState gameState;

    private void Awake()
    {
        gameStateManager = this;
    }

    void Start()
    {
        gameState = GameState.GAMEPLAY;
    }
    
    void Update()
    {
        
    }

    public void SetGameplay()
    {
        Time.timeScale = 1f;
    }

    public void SetPause()
    {
        Time.timeScale = 0f;
    }

    public void SetMainMenu()
    {

    }
}
