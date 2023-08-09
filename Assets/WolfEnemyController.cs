using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemyController : MonoBehaviour
{
    public EnemyManager enemyManager;
    public void AttackFalse()
    {
        enemyManager.ani.SetBool("isAttack", false);
        enemyManager.enemyState = EnemyState.idle;
    }



    public void HowlFalse()
    {
        enemyManager.ani.SetBool("isHowl", false);
        enemyManager.enemyState = EnemyState.idle;
    }

    public void SpAttackFalse()
    {
        enemyManager.ani.SetBool("isSpAttack", false);
        enemyManager.enemyState = EnemyState.idle;
    }
}
