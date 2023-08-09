using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    [SerializeField] EnemyPatrol enemyPatrol;
    [SerializeField] ShaderScript shaderScript;
    [SerializeField] float crtime;
    [SerializeField] float chcrtime;

    private void OnTriggerEnter(Collider other)
    {
        chcrtime = crtime;
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.attack;
        enemyPatrol.anim.SetBool("isAttack", true);
        enemyPatrol.rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        chcrtime -= Time.deltaTime;

        if (other.tag == "Player")
        {
            
            if (chcrtime < 0)
            {
                other.GetComponent<PlayerControllerExample>().AttackDamage(enemyPatrol.enemyData.enemyDamage);
                chcrtime = crtime + 0.2f;
            }
            if (chcrtime < 0.6)
            {
                shaderScript.OutlineFrontTrue();
            }
            else
            {
                shaderScript.OutlineFalse();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chcrtime = crtime;
        shaderScript.OutlineFalse();
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;
        enemyPatrol.anim.SetBool("isAttack", false);
    }

    private void OnDisable()
    {
        chcrtime = crtime;
        shaderScript.OutlineFalse();
        enemyPatrol.enemyData.enemyState = EnemyData.EnemyState.idle;
        enemyPatrol.anim.SetBool("isAttack", false);
    }
}
