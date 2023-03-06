using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Combines intrinsic values in the context class with the squadron class to instantiate squadron objects, 
/// which follow the player around and can shoot weapons. 
/// </summary>
public class SquadFactory : MonoBehaviour
{

    //[SerializeField] GameObject squadronObject;      // testing values used for setting context values in the inspector
    //[SerializeField] GameObject projectileObject; 
    //[SerializeField] float maxSpeed = 5;             

    List<Squadron> squadronList = new List<Squadron>(); // list for squadron components, used to call their update with intrinsic data passed in
    SquadContext context = new SquadContext(); // the intrinsic data for the squad


    void Awake()
    {
        // Resources.Load loads the object at the given path name in the resources folder.
        // needs to be called in a Start/Awake function, so these are set here
        context.squadronObject = (GameObject)Resources.Load("Prefabs/Squadron");
        context.projectileObject = (GameObject)Resources.Load("Prefabs/ProjectileObject");
    }

    void Start()
    {
        
        //squadronList.Add(Instantiate(squadronObject));
        //context.projectileObj = projectileObject;
        //context.maxSpeed = maxSpeed; 
        
        // same as CreateNewSquadron below, just using two lines instead
        GameObject squadInstantiation = Instantiate(context.squadronObject, Vector2.zero, Quaternion.identity);
        squadronList.Add(squadInstantiation.GetComponent<Squadron>());
    }

    void Update()
    {
        context.playerReference = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get our reference to the player position


        // call each squadron's update function, passing in intrinsic values
        for (int i = 0; i < squadronList.Count; i++){
            squadronList[i].UpdateSquadron(context);
        }


        if (Input.GetKeyDown(KeyCode.B)){
            CreateNewSquadron();
        }

    }

    public void CreateNewSquadron()
    {

        // add to our squadron instance reference list by instantiating a gameobject, then using getcomponent on that object
        squadronList.Add(Instantiate(context.squadronObject, 
                    Vector2.zero, Quaternion.identity).GetComponent<Squadron>());

        Debug.Log("Button clicked.");

        //GameObject squadInstantiation = Instantiate(squadronObject, Vector2.zero, Quaternion.identity);
        //squadronList.Add( new Squadron((SquadContext.WeaponTypes)weaponToSet) );
    }

}
