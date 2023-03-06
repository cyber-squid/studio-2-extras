using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] GameObject target;
    Vector3 targetPos;
    Rigidbody2D targetRB;

    [SerializeField] float maxSpeed = 1.0f;
    //[SerializeField] float chaseRadius = 1.0f;

    [SerializeField] float predictionLength = 2.0f; // how far ahead the seeker should try to predict position

    //[SerializeField] float chaseRadius = 5.0f;

    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
        targetRB = target.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        // to predict target position, take its current position and add its velocity (likely future position) to it
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y) 
                            + targetRB.velocity.normalized * predictionLength;

        Seek();
        //if (Vector2.Distance(this.transform.position, targetPos) < chaseRadius)
    }

    void Seek()
    {
        // get the distance from our position to the target's position
        Vector2 desiredVelocity = targetPos - this.transform.position;

        // clamping magnitude makes sure it won't be any greater than our max speed value.
        // to move toward the target, minus current velocity by our desired velocity (toward the predicted target pos).
        Vector2 steeringForce = desiredVelocity - body.velocity;

        //steeringForce.Normalize(); 
        //steeringForce *= maxSpeed;
        Vector2.ClampMagnitude(steeringForce, maxSpeed);
        
        body.AddForce(steeringForce);
    }

        //desiredVelocity.Normalize(); // magnitude will determine the length of the vector, which determines speed, so magnitude
        //desiredVelocity *= maxSpeed; // should be normalised (set to 1) first, then multiply the desired velocity by max speed

        //transform.rotation = Quaternion.LookRotation(desiredVelocity, Vector3.forward);
        //transform.up = new Vector2(desiredVelocity.x, desiredVelocity.y);
        //transform.LookAt(target.transform, desiredVelocity);
}
