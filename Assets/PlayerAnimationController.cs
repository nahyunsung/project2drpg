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
        if(playerControllerExample.playerState == PlayerState.comboattack1)
        {
            ani.SetBool("isAttack", false);
            playerControllerExample.playerState = PlayerState.idle;
        }
        else if(playerControllerExample.playerState == PlayerState.comboattack2)
        {
            ani.SetBool("isAttack2", true);
        }
    }

    public void AniIsAttack2Start()
    {
        ani.SetBool("isAttack", false);
    }

    public void AniIsAttack2End()
    {
        if (playerControllerExample.playerState == PlayerState.comboattack2)
        {
            ani.SetBool("isAttack2", false);
            playerControllerExample.playerState = PlayerState.idle;
        }
        else if (playerControllerExample.playerState == PlayerState.comboattack3)
        {
            ani.SetBool("isAttack3", true);
        }
    }

    public void AniIsAttack3Start()
    {
        ani.SetBool("isAttack2", false);
    }

    public void AniIsAttack3End()
    {
        ani.SetBool("isAttack3", false);
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
