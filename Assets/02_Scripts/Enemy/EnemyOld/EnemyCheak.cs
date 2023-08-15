using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    float crtime = 1.2f;
    [SerializeField] private PlayerControllerExample plConEx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyManager enemyManager = other.GetComponent<EnemyManager>();


            if (plConEx.anim.GetBool("isFrontAttack") && enemyManager.enemyParrying == EnemyParrying.frontParrying ||
                plConEx.anim.GetBool("isUpAttack") && enemyManager.enemyParrying == EnemyParrying.upParrying)
            {
                enemyManager.EnemyStiffness();
            }
            else
            {
                //other.GetComponent<EnemyPatrol>().AttackDamage(plConEx.playerAttack);
                enemyManager.AttackDamage(plConEx.playerAttack);
            }
        }
    }
}
