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

            // Find player referance            
            GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

            // Get distance between center of colision and the point of contact
            float distance = Vector3.Distance(collision.gameObject.transform.position, collision.contacts[0].point);

            // Get distance between the player and target
            float playerDistance = Vector3.Distance(playerRef.transform.position, collision.transform.position);

            // Make score generalised from the distance var and make int
            int scoresimple = (int)(10 - (distance * 10));

            // Add onto score based on players distance from the target
            int compoundscore = (int)(scoresimple + playerDistance / 10);

            // Put score into the 100s
            compoundscore *= 10;

            // Get the vector look vector from the player and target
            Vector3 targetVector = playerRef.transform.position - transform.position;

            // Create Text pop up at child location of the collision (and then varies its horizonatal location)
            GameObject scoreC = Instantiate(scorecnavas, collision.gameObject.transform.GetChild(0).transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f),

            // Spawn text looking at player
            Quaternion.LookRotation(targetVector, Vector3.up));

            // Set text on the UI to the score the player achieved
            scoreC.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = compoundscore.ToString();

            // Get Parent object of the prefab
            GameObject targetPrefab = collision.transform.parent.parent.gameObject;

            // Get the animation component from the prefab
            Animator SpinAnim = targetPrefab.GetComponent<Animator>();

            // If no animator found, log and return
            if (!SpinAnim)
            {
                Debug.Log("Problem with getting spin animation from target prefab");
                return;
            }

            // Set bool for animation
            SpinAnim.SetBool("ShouldSpin", true);

            // Disable any kind of collison with the object
            collision.gameObject.GetComponent<Collider>().isTrigger = true;

            int currentScore = PlayerPrefs.GetInt("CurrentScore") + compoundscore;

            PlayerPrefs.SetInt("CurrentScore", currentScore);


            if (currentScore >= PlayerPrefs.GetInt("HighScore"))
            {
                Debug.Log("NEW High Score: " + PlayerPrefs.GetInt("HighScore"));

                PlayerPrefs.SetInt("HighScore", currentScore);
            }

        }


    }
}
