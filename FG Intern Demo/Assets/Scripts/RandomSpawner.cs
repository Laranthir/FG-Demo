using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;

	public float spawnRate = 4f;
	private float nextSpawn;
	private int whatToSpawn;
	
	//Moving platform variables

	public Transform startMarker;
	public Transform EndMarker;

	public float speed = 1.0f;
	public float journeyLength = 1.0f;
	private float startTime = 0;

	public bool loop = false;

    void Update()
    {
	    //Moving platform loop
	    if (!loop)
	    {
		    float distCovered = (Time.time - startTime) * speed;
		    transform.position = Vector3.Lerp(startMarker.position, EndMarker.position, distCovered / journeyLength);
	    }
	    if (loop)
	    {
		    float distCovered = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
		    transform.position = Vector3.Lerp(startMarker.position, EndMarker.position, distCovered / journeyLength);
	    }
	    
	    
	    
	    //Random Spawner Loop
     if (Time.time > nextSpawn ){
		whatToSpawn = Random.Range (1,6);

		switch (whatToSpawn)
		{
			case 1:
				Instantiate(prefab1, transform.position, Quaternion.identity);
				break;
			case 2:
				Instantiate(prefab2, transform.position, Quaternion.identity);
				break;
			case 3:
				Instantiate(prefab3, transform.position, Quaternion.identity);
				break;
			case 4:
				Instantiate(prefab4, transform.position, Quaternion.identity);
				break;
		}

		nextSpawn = Time.time + spawnRate;
     }
    }
}
