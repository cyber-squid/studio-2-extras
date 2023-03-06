using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public abstract void EnterState(EnemyStateManager manager);

    public abstract void UpdateState(EnemyStateManager manager);

}
