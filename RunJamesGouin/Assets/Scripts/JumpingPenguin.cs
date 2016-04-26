﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpingPenguin : MonoBehaviour {

	private Collider2D collider2D;
	private Rigidbody2D rigidbody2D;
	private Animator animator;
	public AudioSource jumpAudio;
	public AudioSource failAudio;
	public Text scoreText;

	public float jumpForce = 400.0f;
	private float failTime = -1.0f;
	private float startingTime = 0.0f;

	private const int maxJumpsAtOnce = 2;
	private int jumpsLeft = maxJumpsAtOnce;

	// Use this for initialization
	void Start () {
		collider2D = GetComponent<Collider2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		startingTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		//TODO add a button in the interface to return
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("main");
		}


		if (failTime == -1.0f)
		{
			if ((Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1")) && jumpsLeft > 0)
			{
				if (rigidbody2D.velocity.y < 0)
				{
					rigidbody2D.velocity = Vector2.zero;
				}

				if (jumpsLeft == 1)
				{
					rigidbody2D.AddForce(transform.up * jumpForce * 0.75f);
				}
				else
				{
					rigidbody2D.AddForce(transform.up * jumpForce);
				}

				jumpsLeft--;

				jumpAudio.Play();
			}

			animator.SetFloat("velocity", rigidbody2D.velocity.y);
			scoreText.text = (Time.time - startingTime).ToString("0.0");
		}
		else
		{
			if (Time.time > failTime + 2)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
//		Debug.Log("colliding with: " + collision.collider.gameObject.layer);
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			foreach (Spawner spawner in FindObjectsOfType<Spawner>())
			{
				spawner.enabled = false;
			}

			foreach (MoveToLeft moveToLeft in FindObjectsOfType<MoveToLeft>())
			{
				moveToLeft.enabled = false;
			}


			failTime = Time.time;
			animator.SetBool("fail", true);
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(transform.up * jumpForce);
			collider2D.enabled = false;

			failAudio.Play();
		}
		else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			jumpsLeft = maxJumpsAtOnce;
		}
	}
}
