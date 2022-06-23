using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private TMP_Text uiText;

    [SerializeField]
    private int startTime = 60;

    private float interval;

    [SerializeField]
    private bool timerStart = false;
    void Start()
    {
        interval = startTime;
        uiText = gameObject.GetComponent<TMP_Text>();
        GameEvents.current.onStartGame += StartGame;
        GameEvents.current.onEndGame += EndGame;


    }

    // Update is called once per frame
    float Update()
    {
        if (timerStart)
        {
            interval -= Time.deltaTime;

            uiText.SetText(((int)interval).ToString());

            if (interval <= 0)
            {
                timerStart = false;
                GameEvents.current.EndGame();
            }

        }

        return interval;

    }

    public void AddTime(int amount)
    {
        interval += amount;
    }

    public void StartCountdown(bool start, int? newStartTime)
    {
        if (start)
        {
            timerStart = true;
            if (newStartTime != null)
            {
                interval = (int)newStartTime + 1;
            }
            else
            {
                interval = 120;
            }
        }
        else
        {
            interval = 0;
            timerStart = false;
        }
    }

    void StartGame()
    {
        int diffStartTime = 60;
        string diff = PlayerPrefs.GetString("Difficulty");

        switch (diff)
        {
            case "easy":
                diffStartTime = 90;
                break;

            case "normal":
                diffStartTime = 60;
                break;

            case "hard":
                diffStartTime = 30;
                break;

        }
        StartCountdown(true, diffStartTime);
    }

    void EndGame()
    {
        interval = 0;
        uiText.SetText(((int)interval).ToString());

        StartCountdown(false, 0);
    }

}
