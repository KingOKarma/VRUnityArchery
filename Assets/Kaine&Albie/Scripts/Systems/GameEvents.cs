using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;
    void Awake()
    {
        current = this;
    }


    public event Action onStartButton;
    public void StartButton()
    {
        if (onStartButton != null)
        {
            onStartButton();
        }
    }


    public event Action onStartGame;
    public void StartGame()
    {
        if (onStartGame != null)
        {
            onStartGame();
        }
    }

        public event Action onEndGame;
    public void EndGame()
    {
        if (onEndGame != null)
        {
            onEndGame();
        }
    }

    public enum difficulty
    {
        easy, normal, hard
    }

    // public event Action<difficulty> onChooseDifficulty;
    // public void ChooseDifficulty(difficulty diff)
    // {
    //     if (onChooseDifficulty != null)
    //     {
    //         onChooseDifficulty(diff);
    //     }
    // }

}
