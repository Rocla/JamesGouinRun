using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {

    bool jumping;
    bool falling;

	// Use this for initialization
	void Start () {
        this.jumping = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update () {
        //MOVE
        transform.Translate(Vector2.right * Time.deltaTime * 3);
         
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if(!this.jumping)
            {
                this.jumping = true;
                float i = 0.0f;

                while (i < GetComponent<Collider2D>().bounds.size.y * 50)
                {
                    // FOR PC TEST : 0.1f * 70 * Time.deltaTime
                    // FOR ANDROID TEST : 0.1f * 20 * Time.deltaTime
                    transform.Translate(0, 0.1f * Time.deltaTime, 0);
                    i += 0.1f;
                }

                falling = true;
            }
        }
        else
        {
            /*if(!this.falling)
            {*/
                this.jumping = false;
            //}

            //Debug.Log("BOUH!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLIDE enter!");
        if (collision.transform.tag == "Platform")
        {
            Debug.Log("COLLIDE!");
            falling = false;
        }
        else
        {
            Debug.Log("COLLIDE ELSE!");
        }
    }
}
