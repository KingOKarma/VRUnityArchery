using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scorearrow : MonoBehaviour
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
        if(collision.gameObject.tag=="Target")
        {
            float distance = Vector3.Distance ( collision.gameObject.transform.position, collision.contacts[0].point);
           //make ui send distance *10 

           float playerDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, collision.transform.position);
           int scoresimple=(int)(10 - (distance*10));
           Debug.Log("Simple Score: " + scoresimple);
           int compoundscore = (int)((10- (distance*10))+playerDistance/10);

           Debug.Log("Compound Score: " +compoundscore );
           GameObject scoreC = Instantiate(scorecnavas,collision.transform.position + new Vector3(Random.Range(0,1f),0.5f,0.5f), Quaternion.identity); 
           scoreC.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text=compoundscore.ToString();
        }


    }
}
