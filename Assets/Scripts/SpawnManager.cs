using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float repeatRate = 2;
    public float startDelay = 2;
    public PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {   
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {

         Vector3 spawnLocation = new Vector3(20, 0, 0);

        int index = Random.Range(0, obstaclePrefab.Length);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[index], spawnLocation, obstaclePrefab[index].transform.rotation);
        }
      
    }
}
