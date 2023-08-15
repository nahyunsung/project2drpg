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
    public List<int> sumSkillWeight;
    public float skillCoolDown = 0;

    void Start()
    {
        enemyState = EnemyState.run;
        enemyParrying = EnemyParrying.noParrying;
        enemyData.enemyMoney = (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + enemyData.enemyLv)) / (1 - 1.06f)));
        enemyData.enemyMaxHP = enemyData.enemyMoney * 2;
        enemyData.enemyCurHP = enemyData.enemyMaxHP;
        enemyData.enemyDamage = enemyData.enemyMoney * 0.4f;
        for (int i = 0; i < enemySkills.Length; i++)
        {
            for(int z = 0; z < enemySkills[i].skilWeight; z++)
            {
                sumSkillWeight.Add(i);
            }
        }
    }

    void Update()
    {
        skillCoolDown -= Time.deltaTime;

        if(!(enemyState == EnemyState.idle) || skillCoolDown > 0 || ani.GetBool("isStiffness"))
        {
            return;
        }

        int skillidx = Random.Range(0, sumSkillWeight.Count);
        skillidx = sumSkillWeight[skillidx];
        enemyState = EnemyState.attack;
        ani.SetBool(enemySkills[skillidx].aniParameterName, true);
        skillCoolDown = enemySkills[skillidx].skilCoolDown;
    }

    public void AttackDamage(float attackDamage)
    {
        enemyData.enemyCurHP -= attackDamage;
        if(enemyData.enemyCurHP < 0)
        {
            ani.SetBool("isDeath", true);
            enemyState = EnemyState.death;
        }
    }

    public void EnemyStiffness()
    {
        ani.SetBool("isHowl", false);
        ani.SetBool("isSpAttack", false);
        ani.SetBool("isStiffness", true);
    }
}
