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
            other.GetComponent<EnemyPatrol>().AttackDamage(plConEx.playerAttack);
        }
    }
}
