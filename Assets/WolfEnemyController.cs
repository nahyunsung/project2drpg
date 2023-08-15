using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemyController : MonoBehaviour
{
    public EnemyManager enemyManager;
    public GameObject enemyAttackBox;

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

    public void AttackBoxTrue()
    {
        enemyAttackBox.SetActive(true);
    }

    public void AttackBoxFalse()
    {
        enemyAttackBox.SetActive(false);
    }

    public void UpParring()
    {
        enemyManager.enemyParrying = EnemyParrying.upParrying;
    }

    public void FrontParring()
    {
        enemyManager.enemyParrying = EnemyParrying.frontParrying;
    }
    
    public void NoParring()
    {
        enemyManager.enemyParrying = EnemyParrying.noParrying;
    }


    public void StiffnessFalse()
    {
        enemyManager.ani.SetBool("isStiffness", false);
        enemyManager.enemyState = EnemyState.idle;
    }
}
