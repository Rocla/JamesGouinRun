using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TouchScript : MonoBehaviour {

    bool jumping;
	bool falling;
    public AudioClip jump_sound;
	AudioSource audio;

	// Use this for initialization
	void Start () {
        this.jumping = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

		audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        //MOVE
        transform.Translate(Vector2.right * Time.deltaTime * 3);
         
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if(!this.jumping)
            {
				audio.PlayOneShot(jump_sound, 0.7F);
                this.jumping = true;
                float i = 0.0f;

                while (i < GetComponent<Collider2D>().bounds.size.y * 60)
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
        
    }
}
