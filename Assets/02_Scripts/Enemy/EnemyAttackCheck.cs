using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    [SerializeField] EnemyPatrol enemyPatrol;
    [SerializeField] ShaderScript shaderScript;
    [SerializeField] float crtime = 1.2f;

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
                crtime = 1.2f + 0.15f;
            }
            if (crtime < 0.5)
            {
                shaderScript.OutlineTrue();
            }
            else
            {
                shaderScript.OutlineFalse();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        crtime = 1.2f;
        shaderScript.OutlineFalse();
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;
        enemyPatrol.anim.SetBool("isAttack", false);
    }

    private void OnDisable()
    {
        crtime = 1.25f;
        shaderScript.OutlineFalse();
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;
        enemyPatrol.anim.SetBool("isAttack", false);
    }
}
