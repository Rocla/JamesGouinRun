using UnityEngine;
using System.Collections;

public class MoveToRight : MonoBehaviour {

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;
	}
}
