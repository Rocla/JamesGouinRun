using UnityEngine;
using System.Collections;


// http://unity3diy.blogspot.ch/2015/02/unity-2d-camera-follow-script.html
public class CameraFollowScript : MonoBehaviour {

	/// <summary>
	/// Le joueur est la cible
	/// </summary>
	public GameObject target;

	public Vector3 offset;

	float interpVelocity;
	Vector3 targetPos;
	MoveScript msTarget;
	Vector3 offsetBack;

	void Awake () {
		msTarget = target.gameObject.GetComponent<MoveScript> ();
		offsetBack = offset;
		offsetBack.x = offsetBack.x * -1;
	}


	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}

	void FixedUpdate(){
		
		if (target){
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			Vector3 offsetEffectif = offset;

			if (msTarget.direction.x < 0) {
				offsetEffectif = offsetBack;
			}

			transform.position = Vector3.Lerp( transform.position, targetPos + offsetEffectif, 0.25f);
		}
	}
}


