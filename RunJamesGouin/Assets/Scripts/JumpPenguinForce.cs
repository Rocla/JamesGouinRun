using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpPenguinForce : MonoBehaviour {

//	private Animator animator;
	public AudioSource jumpAudio;
//	public AudioSource failAudio;
//	public Text scoreText;
//	public Text highestScoreText;

	public float jumpForce = 600.0f;
//	private float failTime = -1.0f;
//	private float startingTime = 0.0f;
//	private float highestScore = 0.0f;
//	private bool playerDead = false;

	private const int maxJumpsAtOnce = 2;
	private int jumpsLeft = maxJumpsAtOnce;

	// Use this for initialization
	void Start () {
//		animator = GetComponent<Animator>();

//		startingTime = Time.time;

//		highestScore = PlayerPrefs.GetFloat("highestScore", 0);
//		highestScoreText.text = highestScore.ToString("0.0");
	}

	// Update is called once per frame
	void Update () {

		//TODO add a button in the interface to return
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("main");
		}


//		if (failTime == -1.0f)
//		{
			if ((Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1")) && jumpsLeft > 0)
			{
				if (GetComponent<Rigidbody2D>().velocity.y < 0)
				{
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				}

				if (jumpsLeft == 1)
				{
                    GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce * 0.75f);
				}
				else
				{
                    GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
				}

				jumpsLeft--;

				//jumpAudio.Play();
			}

//			animator.SetFloat("vVelocity", rigidbody2D.velocity.y);
//			scoreText.text = (Time.time - startingTime).ToString("0.0");
//		}
//		else
//		{
//			if (Time.time > failTime + 2 || playerDead)
//			{
//				UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
////				playerDead = false;
//			}
//
//		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
//		Debug.Log("colliding with: " + collision.collider.gameObject.layer);
//		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
//		{
//			if ((Time.time - startingTime) > highestScore) {
//				PlayerPrefs.SetFloat("highestScore", Time.time - startingTime);
//				highestScoreText.text = highestScore.ToString("0.0");
//			}
//			playerDead = true;
//
//			foreach (Spawner spawner in FindObjectsOfType<Spawner>())
//			{
//				spawner.enabled = false;
//			}
//
//			foreach (MoveToLeft moveToLeft in FindObjectsOfType<MoveToLeft>())
//			{
//				moveToLeft.enabled = false;
//			}
//
//
//			failTime = Time.time;
//			animator.SetBool("fail", true);
//			rigidbody2D.velocity = Vector2.zero;
//			rigidbody2D.AddForce(transform.up * jumpForce);
//			collider2D.enabled = false;
//
//			failAudio.Play();
//		}
//		else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.transform.tag == "Platform")
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.transform.tag == "Platform")
		{
			jumpsLeft = maxJumpsAtOnce;
		}
	}
}
