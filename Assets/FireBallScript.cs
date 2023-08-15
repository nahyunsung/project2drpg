using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float moveSpeed = .5f;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
