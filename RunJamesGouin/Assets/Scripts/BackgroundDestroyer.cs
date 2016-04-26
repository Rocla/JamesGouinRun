using UnityEngine;
using System.Collections;

public class BackgroundDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
