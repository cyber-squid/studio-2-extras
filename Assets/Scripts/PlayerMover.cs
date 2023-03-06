using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMover : MonoBehaviour
{
    public static int numberOfJumps;
    public static int itemsBumped;  // ints for showing the save system functionality.


    public float moveSpeed = 1;
    public float jumpHeight = 1;

    bool isGrounded;

    /*public float lungeSpeed = 3;
    Vector3 worldspaceMousePos;
    Vector2 lungeDirection;*/


    public TextMeshProUGUI onScreenCounter;
    Rigidbody2D playerBody;
    
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerBody.velocity = new Vector2(
            Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, playerBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerBody.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;

            numberOfJumps++;
            Debug.Log("Jumped " + numberOfJumps + " times.");
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Leap();
        }*/

        onScreenCounter.text = "Jumps: " + numberOfJumps + "\nBumps: " + itemsBumped;
    }

    /*void Leap()
    {
        // get the mouse position on screen relative to the player, by minusing distance from the mouse to the player..
        worldspaceMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lungeDirection = new Vector2(worldspaceMousePos.x - transform.position.x, 
                                        worldspaceMousePos.y - transform.position.y);

        // increase velocity in the direction of the mouse at click time.
        playerBody.velocity = Vector2.zero;
        playerBody.velocity += lungeDirection.normalized * lungeSpeed;
    }*/


    // trigger, so we can have a trigger box at the bottom instead of the whole player's body for collision
    public void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
    }
}
