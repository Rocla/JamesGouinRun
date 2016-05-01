using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class MoveScript : MonoBehaviour {

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

	/// <summary>
	/// Stockage du mouvement
	/// </summary>
    private Vector2 movement;

    private bool onSurface=false;
	private bool onCollideWall=false;

    public AudioClip bananaSound;

	/// <summary>
	/// Stockage des spirites
	/// </summary>
	public SpriteRenderer sprender_wall;
	public SpriteRenderer sprender_run;
	private SpriteRenderer foot_l;
	private SpriteRenderer foot_r;

    private bool alreadyDied;

    void Start()
    {
        //Needed when starting the game
        Score.getInstance();

        alreadyDied = false;
		sprender_wall.enabled = false;

		Transform ts = sprender_run.GetComponent<Transform>();
		foot_l = ts.Find("foot_left/penguin_foot").GetComponent<SpriteRenderer>(); 
		foot_r = ts.Find("foot_right/penguin_foot").GetComponent<SpriteRenderer>();
    }

    void Update() {
        // Calcul du mouvement
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);

		if (!onSurface && onCollideWall)
		{
			movement = new Vector2(0,0);
		}
    }

    // cool pour la physique
    void FixedUpdate()
	{
        // Déplacement
        // rigidbody2D.velocity = movement;
		transform.GetComponent<Rigidbody2D> ().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Banana")
        {
            AudioSource audio = collision.transform.GetComponent<AudioSource>();
            audio.PlayOneShot(bananaSound, 0.7F);

            Destroy(collision.transform.gameObject);
            Score.getInstance().incBanana();
        }
        else if(collision.transform.tag == "Fish")
        {
            Destroy(collision.transform.gameObject);
            Score.getInstance().incFish();
        }
        else if(collision.transform.tag == "Life")
        {
            Destroy(collision.transform.gameObject);
            Score.getInstance().incLife();
        }
        else if(collision.transform.tag == "Water" && !alreadyDied)
        {
            alreadyDied = true;
            Debug.Log("WATER WATER WATER");
            String restart = Score.getInstance().decLife();
            StartCoroutine(restart);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Platform")
		{

			//Vector2 contactPoint = collision.contacts[0].point;
			//Vector2 minCollidePoint = transform.GetComponent<Collider2D> ().bounds.min;
			//Vector2 maxCollidePoint = transform.GetComponent<Collider2D> ().bounds.max;

			Debug.Log ("COLLIDE SURFACE!");
			onSurface = true;
		}

        if (collision.transform.tag == "Wall")
		{

			Debug.Log ("COLLIDE WALL!");
			direction.x = direction.x * -1;

			transform.Rotate(0.0f, 180, 0.0f);
			onCollideWall = true;

			sprender_wall.enabled = true;
			sprender_run.enabled = false;
			foot_l.enabled = false;
			foot_r.enabled = false;

			//Vector2 contactPoint = collision.contacts[0].point;
			/*Vector2 minCollidePoint = transform.GetComponent<Collider2D> ().bounds.min;
			Vector2 maxCollidePoint = transform.GetComponent<Collider2D> ().bounds.max;

			foreach (ContactPoint2D c in collision.contacts) {
				Vector2 contactPoint = c.point;

				if (!(contactPoint.x > minCollidePoint.x && contactPoint.x < maxCollidePoint.x) && contactPoint.y > minCollidePoint.y) {
					Debug.Log ("COLLIDE WALL!");
					onCollideWall = true;
					direction.x = direction.x * -1;
					break;
				} else if (contactPoint.y < minCollidePoint.y) {
					Debug.Log ("COLLIDE SURFACE!");
					onSurface = true;
					break;
				}
			}*/
		}


	}

	void OnCollisionExit2D(Collision2D collision) {

		if (collision.transform.tag == "Platform") {

			/*Vector2 contactPoint = collision.contacts[0].point;
			Vector2 minCollidePoint = transform.GetComponent<Collider2D> ().bounds.min;

			if (contactPoint.y > minCollidePoint.y)
			{
				Debug.Log ("UNCOLLIDE WALL!");
				onCollideWall = false;
			}
			else
			{
				Debug.Log ("UNCOLLIDE Surface!");
				onSurface = false;
			}*/

			Debug.Log ("UNCOLLIDE SURFACE!");
			onSurface = false;

		}
		if (collision.transform.tag == "Wall") {

			Debug.Log ("UNCOLLIDE WALL!");

			sprender_wall.enabled = false;
			sprender_run.enabled = true;
			foot_l.enabled = true;
			foot_r.enabled = true;
			onCollideWall = false;
		}
	}

    IEnumerator RestartLevel()
    {
        Debug.Log("RESTART LEVEL");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("game_over");
    }
    
}