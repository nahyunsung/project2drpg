using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody rb;
    [SerializeField] private Animator anim;
    private Transform currentPoint;
    public float speed;
    public Slider heartSlider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
        enemyData.enemyMoney = (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + enemyData.enemyLv)) / (1 - 1.06f)));
        enemyData.enemyMaxHP = enemyData.enemyMoney * 2;
        enemyData.enemyCurHP = enemyData.enemyMaxHP;
        enemyData.enemyDamage = enemyData.enemyMoney * 0.4f;
        heartSlider.value = enemyData.enemyCurHP / enemyData.enemyMaxHP;
    }

    void Update()
    {
        if(enemyData.enemyState == EnemyData.EnemyState.idle)
        {
            Idle();
        }
    }

    private void Idle()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
