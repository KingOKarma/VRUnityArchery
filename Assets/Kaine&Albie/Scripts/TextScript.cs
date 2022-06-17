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

    void Start()
    {
        Destroy(this.gameObject, 3f);

        uiText = uiTextObject.GetComponent<TMP_Text>();

        if (!uiText)
        {
            Debug.Log("Could not find Text");
            return;
        }

        Debug.Log(uiText.text);
        int score;
        bool didParse = int.TryParse(uiText.text, out score);

        if (!didParse) return;

        if (score < 80)
        {
            uiText.color = Color.gray;
        }
        else if (score < 100)
        {
            uiText.color = Color.green;
        }
        else
        {
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
