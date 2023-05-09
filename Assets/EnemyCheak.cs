using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    float crtime = 1;
    [SerializeField] private PlayerControllerExample plConEx;

    private void OnTriggerStay(Collider other)
    {
        crtime -= Time.deltaTime;

        if(other.tag == "Enemy")
        {
            if(crtime < 0)
            {
                other.GetComponent<EnemyPatrol>().AttackDamage(plConEx.playerAttack);
                crtime = 1;
            }
        }
    }

}
