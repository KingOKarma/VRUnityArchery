using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreArrow : MonoBehaviour
{

    [SerializeField]
    GameObject scorecnavas;
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            
            
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector3.Distance(collision.gameObject.transform.position, collision.contacts[0].point);
            //make ui send distance *10 

            float playerDistance = Vector3.Distance(playerRef.transform.position, collision.transform.position);

            int scoresimple = (int)(10 - (distance * 10));

            int compoundscore = (int)(scoresimple + playerDistance / 3);

            compoundscore *= 10;
            Debug.Log("Compound Score: " + compoundscore);

            Vector3 targetVector = playerRef.transform.position - transform.position;

            GameObject scoreC = Instantiate(scorecnavas, collision.transform.position + new Vector3(Random.Range(0, 1f), 0.5f, 0.5f),
            Quaternion.LookRotation(targetVector, Vector3.up));
            scoreC.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = compoundscore.ToString();
        }


    }
}
