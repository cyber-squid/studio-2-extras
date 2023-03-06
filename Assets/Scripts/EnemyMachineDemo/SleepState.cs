using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : EnemyState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Entered sleep state.");
        manager.enemyBody.velocity = Vector2.zero; // stop the enemy so he can sleep
        manager.patrolTimer = 0;
        manager.sprite.color = manager.sleepColor;
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        // if the player is within half the normal radius, start chasing
        if (Vector2.Distance(manager.player.transform.position, manager.transform.position) < (manager.chaseRadius / 2))
        {
            manager.SwitchState(manager.chaseState);
        }
    }

}
