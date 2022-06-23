using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject TargetPrefab;
    public int spawnAmountEasy = 10;
    public int spawnAmountNormal = 5;
    public int spawnAmountHard = 1;
    void Start()
    {
        GameEvents.current.onStartGame += GameStarted;
        GameEvents.current.onEndGame += GameEnded;
    }

    void GameStarted()
    {
        string diff = PlayerPrefs.GetString("Difficulty");

        switch (diff)
        {
            case "easy":
                for (int i = 0; i < spawnAmountEasy; i++)
                {
                    SpawnTarget(TargetPrefab);
                }
                break;

            case "normal":
                for (int i = 0; i < spawnAmountNormal; i++)
                {
                    SpawnTarget(TargetPrefab);

                }
                break;

            case "hard":
                for (int i = 0; i < spawnAmountHard; i++)
                {
                    SpawnTarget(TargetPrefab);

                }
                break;

        }
    }

    void GameEnded()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (var target in targets)
        {
            Destroy(target);
        }
    }


    public static void SpawnTarget(GameObject TargetPrefab)
    {

        if (!TargetPrefab)
        {
            Debug.LogError("TargetPrefab has not been assigned for the game manager");
            return;
        }

        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

        Vector3 Loc = playerRef.transform.position + new Vector3(Random.Range(-15, 15), Random.Range(-0.5f, 10), Random.Range(-15, 15));

        // // Get the vector look vector from the player and target
        Vector3 targetVector = playerRef.transform.position - Loc;

        // // Look at player
        Quaternion lookAtRot = Quaternion.LookRotation(targetVector, Vector3.up);

        bool rotateOnSpawn = false;

        GameObject newTarget = Instantiate(TargetPrefab, Loc, lookAtRot);

        float percentValue = 0.5f;
        int rotSpeed = Random.Range(5, 20);

        string diff = PlayerPrefs.GetString("Difficulty");

        switch (diff)
        {
            case "easy":
                rotSpeed = Random.Range(5, 20);
                percentValue = 0.75f;
                break;

            case "normal":
                rotSpeed = Random.Range(10, 25);
                percentValue = 0.5f;
                break;

            case "hard":
                rotSpeed = Random.Range(25, 50);
                percentValue = 0.25f;
                break;

        }


        if (Random.value >= percentValue)
        {
            rotateOnSpawn = true;
        }
        else
        {
            rotateOnSpawn = false;
        }

        if (rotateOnSpawn)
        {
            ArrowTargetScript selfScript = newTarget.GetComponent<ArrowTargetScript>();
            selfScript.StartRotate(true);
            selfScript.SetRotateSpeed(rotSpeed);

        }

        newTarget.transform.GetChild(0).GetChild(0).GetComponent<Collider>().isTrigger = false;
        newTarget.transform.GetChild(0).GetComponent<Animator>().SetBool("ShouldSpin", false);
    }


}
