using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public static Action<GameState> onGameStateChanged;
    GameState gameState;


    protected override void Awake()
    {
        base.Awake();
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;

        onGameStateChanged?.Invoke(gameState);


        Debug.Log("Game state changed" + gameState);
    }
}
