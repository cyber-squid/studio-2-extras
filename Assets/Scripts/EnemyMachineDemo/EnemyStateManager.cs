using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the switching between and updating of states for an enemy gameobject, keeping one active state 
/// and setting it depending on the SwitchState function calls it makes. Also provides context to states with variables.
/// </summary>
public class EnemyStateManager : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public Rigidbody2D enemyBody;     // references to the player and the enemy's own rigidbody

    [HideInInspector] public bool isMovingLeft;
    [HideInInspector] public Vector3 leftwardsPosition;
    [HideInInspector] public Vector3 rightwardsPosition; // determines where the enemy will move to in the patrol state.
    public float movementRange = 5;  // determines spacing between the left and right patrol points.

    public float patrollingSpeed;
    public float chasingSpeed;
    public float chaseRadius;

    [HideInInspector] public float patrolTimer;
    [HideInInspector] public float durationOfPatrol = 10; // how long the enemy should patrol before going to sleep.
    //float wakeToPatrolRadius;
    //float wakeToChaseRadius;

    [HideInInspector] public SpriteRenderer sprite;
    [HideInInspector] public Color baseColor = new Color(0.6961585f, 0.4269758f, 0.8962264f);
    [HideInInspector] public Color chaseColor = new Color(0.8207547f, 0.3017496f, 0.2671324f);
    [HideInInspector] public Color sleepColor = new Color(0.259523f, 0.4888585f, 0.6792453f);   // colours to distinguish the states


    EnemyState currentState;  // need a generic enemystate instance, so we can set it equal to inheriting states (sleep, patrol, chase)

    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public SleepState sleepState = new SleepState();  // instantiate states beforehand so we don't need to keep creating new ones

    
    void Awake()
    {
        player = GameObject.Find("Player");
        enemyBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        //patrolPoints = new Vector2[2];
    }

    void Start()
    {
        // set the patrol points to the left and right of the enemy
        leftwardsPosition = new Vector2(transform.position.x + movementRange, transform.position.y);
        rightwardsPosition = new Vector2(transform.position.x - movementRange, transform.position.y);

        currentState = patrolState;
        currentState.EnterState(this); // set up the active state
    }


    void Update()
    {
        currentState.UpdateState(this); // using the "this" keyword to pass in this instance as the reference to values needed for the states.
                                        // (states need to be able to reference the machine calling their functions to use any associated data.)
    }

    // take in a state and set our current active state to the passed one, calling its start in the process
    public void SwitchState(EnemyState nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

}
