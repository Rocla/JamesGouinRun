using UnityEngine;
using System.Collections;


public class MoveScript : MonoBehaviour {

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);


    /// <summary>
    /// Direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    // Stockage du mouvement
    private Vector2 movement;

    void Update()
    {
        // Calcul du mouvement
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);

    }

    // cool pour la physique
    void FixedUpdate()
    {
        // Déplacement
        // rigidbody2D.velocity = movement;
        transform.GetComponent<Rigidbody2D>().velocity = movement;
    }

}
