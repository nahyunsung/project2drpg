using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    run,
    attack,
    death
}

public enum EnemyParrying
{
    noParrying,
    upParrying,
    frontParrying
}

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public EnemyData enemyData;
    public EnemyState enemyState;
    public EnemyParrying enemyParrying;
    public Animator ani;
    [SerializeField] public EnemySkill[] enemySkills;


    void Start()
    {
        enemyState = EnemyState.run;
        enemyParrying = EnemyParrying.noParrying;
        enemyData.enemyMoney = (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + enemyData.enemyLv)) / (1 - 1.06f)));
        enemyData.enemyMaxHP = enemyData.enemyMoney * 2;
        enemyData.enemyCurHP = enemyData.enemyMaxHP;
        enemyData.enemyDamage = enemyData.enemyMoney * 0.4f;
    }

    void Update()
    {
        if(!(enemyState == EnemyState.idle))
        {
            return;
        }

        int skillidx = Random.Range(0, enemySkills.Length);
        enemyState = EnemyState.attack;
        ani.SetBool(enemySkills[skillidx].aniParameterName, true);
    }



}
