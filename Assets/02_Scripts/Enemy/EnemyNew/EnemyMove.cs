using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody rb;
    private bool isMovingRight = true;

    public EnemyManager enemyManager;

    public float traceDistance = 1f;
    private Transform player;

    public Vector3 EnemyOriPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyOriPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        if(enemyManager.enemyState == EnemyState.attack || enemyManager.enemyState == EnemyState.death)
        {
            return;
        } 

        Vector2 direction = player.position - (transform.position + new Vector3(transform.localScale.x * 1,0, 0));
        if (direction.magnitude > traceDistance)
        {
            enemyManager.enemyState = EnemyState.run;
        }
        else if(enemyManager.enemyState == EnemyState.run)
        {
            enemyManager.enemyState = EnemyState.idle;
        }

        if(enemyManager.enemyState == EnemyState.run)
        {
            EnemyRun();
        }
        else if(enemyManager.enemyState == EnemyState.idle)
        {
            Enemyidle();
        }

        
    }

    public void EnemyRun()
    {
        enemyManager.ani.SetBool("isRun", true);
        if (isMovingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if(this.gameObject.transform.position.x > EnemyOriPosition.x + 7)
        {
            isMovingRight = false;
            flip(-1);
        }
        else if(this.gameObject.transform.position.x < EnemyOriPosition.x - 7)
        {
            isMovingRight = true;
            flip(1);
        }
    }

    public void Enemyidle()
    {
        rb.velocity = new Vector2(0, 0);
        enemyManager.ani.SetBool("isRun", false);
    }

    public void flip(int x)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = x;
        transform.localScale = localScale;
    }
}
