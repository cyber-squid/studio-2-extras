using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra script for the enemy object which pushes the player back.
public class EnemyBounceback : MonoBehaviour
{
    [SerializeField] float bouncebackForce = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            // get the player's direction relative to this object
            Vector2 directionToFling = playerBody.transform.position - transform.position;

            // negate the y value and normalise, because we only want to get where the player is on x
            directionToFling.y = 1;
            directionToFling.Normalize();

            // push player in the direction they contacted the enemy
            playerBody.velocity += directionToFling * bouncebackForce; //new Vector2(directionToFling.x * bouncebackForce, 5f);
            //Debug.Log("the new calc value is " + directionToFling * bouncebackForce);
        }
    }
}
