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

    }

    // Update is called once per frame
    float Update()
    {
        if (timerStart)
        {
            interval -= Time.deltaTime;

            uiText.SetText(((int) interval).ToString());

            if (interval <= 0) timerStart = false;

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
                interval = (int)newStartTime;
            }
            else
            {
                interval = 120;
            }
        }
        else
        {
            timerStart = false;
            interval = 0;
        }
    }

}
