using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionCheak : MonoBehaviour
{
    [SerializeField]EnemyPatrol enemyPatrol;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.targetmove;
            Debug.Log("stay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            /*
            if (Vector2.Distance(enemyPatrol.transform.position, enemyPatrol.currentPoint.position) < 0.5f && enemyPatrol.currentPoint == enemyPatrol.pointB.transform)
            {
                enemyPatrol.flip();
                enemyPatrol.currentPoint = enemyPatrol.pointA.transform;
            }
            if (Vector2.Distance(enemyPatrol.transform.position, enemyPatrol.currentPoint.position) < 0.5f && enemyPatrol.currentPoint == enemyPatrol.pointA.transform)
            {
                enemyPatrol.flip();
                enemyPatrol.currentPoint = enemyPatrol.pointB.transform;
            }
            */
            enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;

        }
    }
}
