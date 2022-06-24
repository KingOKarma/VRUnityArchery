using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject uiTextObject;
    private TMP_Text uiText;

    private GameObject timer;


    void Start()
    {
        Destroy(this.gameObject, 3f);
        timer = GameObject.FindGameObjectWithTag("Timer");
        uiText = uiTextObject.GetComponent<TMP_Text>();

        if (!uiText)
        {
            Debug.Log("Could not find Text");
            return;
        }

        int score;
        bool didParse = int.TryParse(uiText.text, out score);

        if (!didParse) return;

        if (score < 80)
        {
            // +1 Sec everytime you score
            timer.gameObject.GetComponent<Timer>().AddTime(1);
            // Set text to grey when low score
            uiText.color = Color.gray;
        }
        else if (score < 100)
        {
            // +5 Secs everytime you score
            timer.gameObject.GetComponent<Timer>().AddTime(2);
            // Set text to green when good score
            uiText.color = Color.green;
        }
        else
        {
            // +10 Secs everytime you score
            timer.gameObject.GetComponent<Timer>().AddTime(5);
            // Set text to gold when high score
            Color gold = new Color(255, 215, 0);
            uiText.color = gold;
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

        if (!playerRef) return;

        Vector3 targetVector = playerRef.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, Vector3.up);
    }
}
