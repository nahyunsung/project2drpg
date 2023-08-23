using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAniController : MonoBehaviour
{
    public Animator ani;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DragonFallTrue()
    {
        ani.SetBool("isDragonFall", true);
    }

    public void DragonFallFalse()
    {
        ani.SetBool("isDragonFall", false);
    }
}
