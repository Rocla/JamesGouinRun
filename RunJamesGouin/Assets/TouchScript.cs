using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

    bool move;

	// Use this for initialization
	void Start () {
        move = false;
	}

    // Update is called once per frame
    void Update () {

        if(!transform.GetComponent<Animation>().IsPlaying("JumpAnimation"))
        {
            move = false;
        }
           
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            transform.GetComponent<Animation>().Play();
            /*
            if (!move)
            {
                transform.GetComponent<Animation>().Play();
                move = true;
            }
            else
            {
                transform.GetComponent<Animation>().Stop();
                move = false;
            }*/
        }
    }
}
