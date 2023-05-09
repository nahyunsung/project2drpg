using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheak : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("1");
        }
    }

}
