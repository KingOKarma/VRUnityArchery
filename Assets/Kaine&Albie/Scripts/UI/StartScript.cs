using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    void Start()
    {
        GameEvents.current.onEndGame += StopGame;
    }

    void StopGame()
    {
        gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            gameObject.SetActive(false);
            GameEvents.current.StartButton();
        }
    }
}
