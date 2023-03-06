using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class which contains extrinsic values for the squadron. A full squadron object is comprised of this class
/// and an instance of the squadron class - all squadrons need to reference this class for any data shared between them.
/// </summary>
public class SquadContext
{
    public Vector2 playerReference;
    public GameObject squadronObject;
    public GameObject projectileObject; 

    //public GameObject playerReference; // decided to represent the player with the mouuse instead
    public float maxSpeed = 5;
    public float projectileSpeed = 15;

    public enum WeaponTypes 
    { 
        ice,
        fire,
        electric,
        none
    }

}

