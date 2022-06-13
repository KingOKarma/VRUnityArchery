using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreArrow : MonoBehaviour
{

    [SerializeField]
    GameObject scorecnavas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector3.Distance(collision.gameObject.transform.position, collision.contacts[0].point);
            //make ui send distance *10 

            float playerDistance = Vector3.Distance(playerRef.transform.position, collision.transform.position);
            int scoresimple = (int)(10 - (distance * 10));
            Debug.Log("Simple Score: " + scoresimple);
            int compoundscore = (int)((10 - (distance * 10)) + playerDistance / 10);

            Debug.Log("Compound Score: " + compoundscore);
            compoundscore *= 10;

            Vector3 targetVector = playerRef.transform.position - transform.position;

            GameObject scoreC = Instantiate(scorecnavas, collision.transform.position + new Vector3(Random.Range(0, 1f), 0.5f, 0.5f), 
            Quaternion.LookRotation(targetVector, Vector3.up));
            scoreC.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = compoundscore.ToString();
        }


    }
}
