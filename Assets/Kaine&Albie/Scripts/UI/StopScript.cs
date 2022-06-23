using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScript : MonoBehaviour
{


    public void ShowStopButton()
    {
        gameObject.SetActive(true);
    }

        public void HideStopButton()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            gameObject.SetActive(false);
            GameEvents.current.EndGame();
        }
    }
}
