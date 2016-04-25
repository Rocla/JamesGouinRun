using UnityEngine;
using System.Collections;

public class MoveToLeft : MonoBehaviour {

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
