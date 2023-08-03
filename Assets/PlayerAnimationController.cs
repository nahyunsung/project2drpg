using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject attackBox;
    public Animator ani;
    public PlayerControllerExample playerControllerExample;

    public void AttackBoxTrue()
    {
        attackBox.SetActive(true);
    }

    public void AttackBoxFalse()
    {
        attackBox.SetActive(false);
    }

    public void AniIsAttackFalse()
    {
        ani.SetBool("isAttack", false);
        playerControllerExample.playerState = PlayerState.idle;
    }

    public void AniIsForntAttackFalse()
    {
        ani.SetBool("isFrontAttack", false);
        playerControllerExample.playerState = PlayerState.idle;

    }
    public void AniIsUpAttackFalse()
    {
        ani.SetBool("isUpAttack", false);
        playerControllerExample.playerState = PlayerState.idle;

    }
}
