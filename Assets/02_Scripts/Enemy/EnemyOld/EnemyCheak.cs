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

        if (other.CompareTag("InteractionObject") && plConEx.anim.GetBool("isUpAttack"))
        {
            Transform obj = other.GetComponent<Transform>();
            obj.transform.localEulerAngles = new Vector3(0, 0, 90);
            other.GetComponent<FireBallScript>().fireBallOner = FireBallOner.player;
        }
    }
}
