using UnityEngine;

/// <summary>
/// Parallax scrolling
/// </summary>
public class ScrollingScript : MonoBehaviour
{
	/// <summary>
	/// Vitesse du défilement
	/// </summary>
	public Vector2 speed = new Vector2(2, 2);

	/// <summary>
	/// Direction du défilement
	/// </summary>
	//public Vector2 directionRight = new Vector2(-1, 0);



	/// <summary>
	/// Va dans le sens inverse du pingouin
	/// </summary>
	public GameObject targetPenguin;
	MoveScript msTarget;


	void Awake () {
		msTarget = targetPenguin.gameObject.GetComponent<MoveScript> ();
	}

	void FixedUpdate()
	{
		Vector2 direction;
		if (msTarget.direction.x < 0) {
			direction = new Vector2(1, 0);
		}
		else{
			direction = new Vector2(-1, 0);
		}

		// Mouvement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate(movement);
	}

	void Update()
	{
		


	}
}