using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onStartGame += GameStarted;
        GameEvents.current.onEndGame += GameEnded;

    }

    void GameStarted()
    {
        gameObject.SetActive(false);
    }

    void GameEnded()
    {
        gameObject.SetActive(true);
    }

}
