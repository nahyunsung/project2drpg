using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyMove : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float traceDistance = 2f;

    private Transform player;
    public EnemyManager enemyManager;
    public GameObject fireBall;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 direction = player.position - transform.position;
        if (direction.magnitude > traceDistance)
            return;

        Vector3 targetPosition = transform.position;
        targetPosition.x = player.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);

        if(transform.position.x < player.position.x)
        {
            flip(1);
        }
        else if(transform.position.x > player.position.x)
        {
            flip(-1);
        }
        else
        {
                
        }
        
    }

    public void flip(int x)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = x;
        transform.localScale = localScale;
    }
}
