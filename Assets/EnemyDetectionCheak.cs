using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionCheak : MonoBehaviour
{
    [SerializeField]EnemyPatrol enemyPatrol;

    private void OnTriggerStay(Collider other)
    {
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.targetmove;
    }
}
