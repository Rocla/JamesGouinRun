using UnityEngine;
using System.Collections;

public class GroundGC : MonoBehaviour {

    public Transform groundStart;
    public Transform groundEnd;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        if (transform.position.x < groundEnd.position.x)
        {
            float gap = groundEnd.position.x - transform.position.x;
            transform.position = new Vector3(groundStart.position.x - gap, transform.position.y, transform.position.z);
        }

	}
}
