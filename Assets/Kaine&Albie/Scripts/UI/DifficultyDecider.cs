using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDecider : MonoBehaviour
{
    public GameEvents.difficulty difficulty;

    public void BeginSelection()
    {
        gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            PlayerPrefs.SetString("Difficulty", difficulty.ToString());
            GameEvents.current.StartGame();
            PlayerPrefs.SetInt("CurrentScore", 0);

            foreach (Transform child in transform.parent)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

}
