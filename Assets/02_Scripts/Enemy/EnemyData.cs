using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public enum EnemyState
    {
        idle,
        targetmove,
        attack
    }
    public EnemyState enemyState = EnemyState.idle;

    public int enemyLv;
    public float enemyMaxHP;
    public float enemyCurHP;
    public float enemyDamage;
    public float enemyMoney;
}
