using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform objectToSpawn;
    public AnimationCurve spawnCurve;

	private float startingTime = 0.0f;
	private float timeToSpawn = 0.0f;
    public float curveTime = 30.0f;
    public float interval = 0.25f;


	// Use this for initialization
	void Start () {
		startingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time > timeToSpawn)
        {
			Instantiate(objectToSpawn, transform.position, Quaternion.identity);

			float curvePosition = (Time.time - startingTime) / curveTime;
			if (curvePosition > 1.0f)
            {
				curvePosition = 1.0f;
				startingTime = Time.time;
            }

			timeToSpawn = Time.time + spawnCurve.Evaluate(curvePosition) + Random.Range(-interval, interval);

        }

	}
}
