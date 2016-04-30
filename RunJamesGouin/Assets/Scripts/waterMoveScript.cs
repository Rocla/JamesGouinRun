using UnityEngine;
using System.Collections;

public class waterMoveScript : MonoBehaviour {



	/// <summary>
	/// Vitesse de déplacement
	/// </summary>
	public Vector2 speed = new Vector2(1, 1);

	/// <summary>
	/// Stockage du mouvement
	/// </summary>
	private Vector2 movement;

	/// <summary>
	/// Direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);

	float timeLimit = 0.5f; // 0.5 seconde

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);

		if (timeLimit > 0) {
			// Decrease timeLimit.
			timeLimit -= Time.deltaTime;

		} else {
			direction.x = direction.x * -1;
			timeLimit = 0.5f;
		}
	}
		
	void FixedUpdate()
	{
		transform.Translate(movement);
	}


}
