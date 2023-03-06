using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Entered chase state.");
        //manager.enemyBody.velocity = Vector2.zero;
        manager.patrolTimer = 0; // timer needs to be reset after leaving patrol.
        manager.sprite.color = manager.chaseColor;
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        Vector2 distanceToPlayer = manager.player.transform.position - manager.transform.position; // get distance to the player
        Vector3.Normalize(distanceToPlayer);

        if (manager.enemyBody.velocity.x <= manager.chasingSpeed) // cap the enemy's movement speed (so speed won't exponentiate if velocity is added to)
        {
            manager.enemyBody.velocity = new Vector2(distanceToPlayer.x * manager.chasingSpeed, 0); //* Time.deltaTime;
            //manager.enemyBody.velocity.x + distanceToPlayer.x, 
        }

        // if player is further than the chase radius, go back to patrolling
        if (Vector2.Distance(manager.transform.position, manager.player.transform.position) > manager.chaseRadius)
        {
            manager.SwitchState(manager.patrolState);
        }
    }

    
}
