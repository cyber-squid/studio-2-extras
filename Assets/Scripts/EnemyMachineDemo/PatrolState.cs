using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Entered patrol state.");
        //manager.enemyBody.velocity = Vector2.zero;
        manager.sprite.color = manager.baseColor;
    }

    // need a reference back to the manager to use its variables, doable by passing it as a parameter in the functions
    public override void UpdateState(EnemyStateManager manager)
    {
        
        manager.patrolTimer += Time.deltaTime;

        // check whether the enemy should be moving left or right, and call the corresponding function
        if (manager.isMovingLeft)
        {
            PatrolLeft(manager);
        }
        if (!manager.isMovingLeft)
        {
            PatrolRight(manager);
        }
        /*
        // move between each point in the vector array, one by one. in this case, we only need two.
        for (int i = 0; i < manager.patrolPoints.Length; i++)
        {
            Vector3 currentPoint = manager.patrolPoints[i];

            while (manager.transform.position != currentPoint)
                Vector3.MoveTowards(manager.transform.position, currentPoint, 0);
        }*/

        // go to chase mode if player gets too close.
        if (Vector2.Distance(manager.player.transform.position, 
                            manager.transform.position) < manager.chaseRadius)
        {
            manager.SwitchState(manager.chaseState);
        }

        // go to sleep mode if the enemy has patrolled longer than 10 secs.
        if (manager.patrolTimer >= manager.durationOfPatrol)
        {
            manager.SwitchState(manager.sleepState);
        }

    }

    // get the distance from the enemy to the patrol point, then add velocity in the direction of the patrol point (times speed)
    void PatrolLeft(EnemyStateManager manager)
    {
        Vector2 directionToMove = manager.leftwardsPosition - manager.transform.position;
        manager.enemyBody.velocity += directionToMove.normalized * manager.patrollingSpeed * Time.deltaTime;

        if (manager.transform.position == manager.leftwardsPosition) // set the bool so the update function can call the other function
            //manager.enemyBody.velocity = Vector2.zero;
            manager.isMovingLeft = false;
    }
    void PatrolRight(EnemyStateManager manager)
    {
        Vector2 directionToMove = manager.rightwardsPosition - manager.transform.position;
        manager.enemyBody.velocity += directionToMove.normalized * manager.patrollingSpeed * Time.deltaTime;

        if (manager.transform.position == manager.rightwardsPosition)
            //manager.enemyBody.velocity = Vector2.zero;
            manager.isMovingLeft = true;
    }
    // note: I'm currently still trying to figure out a bug that's been an issue here for a few days, 
    // that being the distance the enemy moves back and forth seems to depend on its position when it enters this state.
    // the further the enemy is when returning to patrolling, the further it moves, and vice versa. I'm not sure how or why,
    // though I feel like it'll be one of those solutions that are painfully obvious in retrospect ><
    // I'll continue working on this though even past a deadline, since I would like to try and figure it out, and make the enemy feel a bit more natural.
    /*void Patrol(EnemyStateManager manager)
    {
        if (manager.isMovingLeft)
        {
            if(manager.transform.position != manager.leftwardsPosition)
            {
                Vector3.MoveTowards(manager.transform.position, manager.leftwardsPosition, 0);
            }
            manager.isMovingLeft = false;
        }
        else
        {
            if(manager.transform.position != manager.rightwardsPosition)
            {
                Vector3.MoveTowards(manager.transform.position, manager.rightwardsPosition, 0);
            }
            manager.isMovingLeft = true;
        }
    }*/
}
