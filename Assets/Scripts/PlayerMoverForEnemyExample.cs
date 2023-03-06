using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script is mostly copypasted from PlayerMover, with slight changes to accommodate the enemy FSM demo (no counters, reworked movement)
public class PlayerMoverForEnemyExample : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jumpHeight = 1;

    bool isGrounded;

    
    Rigidbody2D playerBody;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // cap the player's movement so it can't go faster than half the actual movespeed. 
        // movespeed is halved in the condition check so that we accelerate and hit top speed twice as fast, to make movement feel more responsive.
        if (playerBody.velocity.x < moveSpeed / 2)
        {
            // velocity is now added to rather than set (this is so the enemy can bounce the player back).
            playerBody.velocity += new Vector2(
                Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerBody.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;
        }
    }


    // trigger, so we can have a trigger box at the bottom instead of the whole player's body for collision
    public void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
    }
}
