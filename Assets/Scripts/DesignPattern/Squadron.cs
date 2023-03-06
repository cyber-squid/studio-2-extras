using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class provides the functions and extrinsic values for creating a squadron object.
/// Note: the class needs a handler (providing the context with intrinsic values) to function.
/// </summary>
public class Squadron : MonoBehaviour
{
    
    Rigidbody2D body;

    Vector2 desiredVelocity; // is used in both moving and firing functions
    SquadContext.WeaponTypes weaponType = SquadContext.WeaponTypes.none;

    /*public Squadron(SquadContext.WeaponTypes weaponToSet)
    {
        weaponType = weaponToSet;
    }*/

    void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();

        if (weaponType == SquadContext.WeaponTypes.none){
            int weaponToSet = Random.Range(0, 3);
            weaponType = (SquadContext.WeaponTypes)weaponToSet; //randomise weapon selection by casting int to enum.
        }
    }

    public void UpdateSquadron(SquadContext context)
    {
        // calculate distance and direction to the player (see PursuitController)
        desiredVelocity = new Vector2(context.playerReference.x - this.transform.position.x,
                                            context.playerReference.y - this.transform.position.y);

        MoveToPlayer(context);


        if (Input.GetKeyDown(KeyCode.F)){ 
            FireWeapon(context);
        }

    }


    // simplified version of the seek function ussed in the PursuitController script.
    void MoveToPlayer(SquadContext context)
    {
        Vector2 steeringForce = desiredVelocity - body.velocity;
        Vector2.ClampMagnitude(steeringForce, context.maxSpeed);

        body.AddForce(steeringForce);
    }

    void FireWeapon(SquadContext context)
    {
        Projectile projectile;  // create a projectile instance to set color and velocity
                                // then instantiate a gameobject, while fetching its component and setting the instance to it
        projectile = Instantiate(context.projectileObject, 
                    transform.position, Quaternion.identity).GetComponent<Projectile>();


        // rotate the projectile to face the player before firing. 
        // get the angle between the x and y axes of the vector to rotate towards,
        // multiply with Rad2Deg value to convert to degrees, then set rotation to that angle.
        float angleToRotateTo = Mathf.Atan2(desiredVelocity.y, desiredVelocity.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, angleToRotateTo);
        // originally the seeksrs were also meant to rotate, but this ended up interfering with the vector calculations for seeking. ^^"

        switch (weaponType)
        {
            case SquadContext.WeaponTypes.ice:
                projectile.projectileSprite.color = Color.blue;
                break;

            case SquadContext.WeaponTypes.fire:
                projectile.projectileSprite.color = Color.red;
                break;

            case SquadContext.WeaponTypes.electric:
                projectile.projectileSprite.color = Color.yellow;
                break;

            default:
                break;
        }

        // add velocity in the direction of the player's position (normalise to ensure consistent speed)
        projectile.projectileRB.velocity = projectile.projectileRB.velocity + desiredVelocity.normalized * context.projectileSpeed;
    }

}
