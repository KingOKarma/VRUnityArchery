using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldScoreScript : MonoBehaviour
{
    [SerializeField]
    private bool isHighScore = false;

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
            uiText.SetText(PlayerPrefs.GetInt("HighScore").ToString());

        }
        else
        {
            uiText.SetText(PlayerPrefs.GetInt("CurrentScore").ToString());
        }
    }
}
