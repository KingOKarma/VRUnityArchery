using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldScoreScript : MonoBehaviour
{
    [SerializeField]
    private bool isHighScore = false;
    [SerializeField]
    private GameEvents.difficulty difficultyHighScore;

    private TMP_Text uiText;


    void Start()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    void FixedUpdate()
    {

        uiText = gameObject.GetComponent<TMP_Text>();

        if (isHighScore)
        {
            switch (difficultyHighScore.ToString())
            {
                case "easy":
                    uiText.SetText(PlayerPrefs.GetInt("easyHighScore").ToString());

                    break;

                case "normal":
                    uiText.SetText(PlayerPrefs.GetInt("normalHighScore").ToString());

                    break;

                case "hard":
                    uiText.SetText(PlayerPrefs.GetInt("hardHighScore").ToString());

                    break;
            }

        }
        else
        {
            uiText.SetText(PlayerPrefs.GetInt("CurrentScore").ToString());
        }
    }
}
