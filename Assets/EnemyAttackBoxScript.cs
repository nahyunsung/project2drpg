using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBoxScript : MonoBehaviour
{
    public EnemyManager enemyManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControllerExample>().AttackDamage(enemyManager.enemyData.enemyDamage);
        }
    }
}
