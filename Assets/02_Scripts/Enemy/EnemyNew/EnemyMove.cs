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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

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
            Playeridle();
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
    }

    public void Playeridle()
    {
        rb.velocity = new Vector2(0, 0);
        enemyManager.ani.SetBool("isRun", false);
    }

    public void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(!(enemyManager.enemyState == EnemyState.run))
        {
            return;
        }

        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
            flip();
        }
    }
}
