using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    [SerializeField] EnemyPatrol enemyPatrol;
    float crtime = 1.1f;

    private void OnTriggerEnter(Collider other)
    {
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.attack;
        enemyPatrol.anim.SetBool("isAttack", true);
        enemyPatrol.rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        crtime -= Time.deltaTime;

        if (other.tag == "Player")
        {
            if (crtime < 0)
            {
                other.GetComponent<PlayerControllerExample>().AttackDamage(enemyPatrol.enemyData.enemyDamage);
                crtime = 1.1f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;
        enemyPatrol.anim.SetBool("isAttack", false);
    }
}
