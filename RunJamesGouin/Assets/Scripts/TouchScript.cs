using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

    bool jumping;

	// Use this for initialization
	void Start () {
        this.jumping = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * 3);
           
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if(!this.jumping)
            {
                this.jumping = true;
                float i = 0.0f;

                while (i < GetComponent<Collider>().bounds.size.y * 2)
                {
                    // FOR PC TEST : 0.1f * 70 * Time.deltaTime
                    // FOR ANDROID TEST : 0.1f * 20 * Time.deltaTime
                    transform.Translate(0, 0.1f * 70 * Time.deltaTime, 0);
                    i += 0.1f;
                }
                this.jumping = false;
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.transform.tag == "Platform")
        {
            Debug.Log("COLLIDE!");
            move = false;
        }*/
    }
}
