using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] public EnemyData enemyData;
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody rb;
    [SerializeField] public Animator anim;
    public Transform currentPoint;
    public float speed;
    public Slider heartSlider;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private GameObject attackCheck;
    private bool isMoney = true;

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

        if(enemyData.enemyCurHP < 0)
        {
            attackCheck.SetActive(false);
            enemyData.enemyState = EnemyData.EnemyState.dead;
            if (isMoney)
            {
                uiManager.MoneyUp(enemyData.enemyMoney);
                isMoney = false;
            }
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetBool("isRunning", false);
            anim.SetBool("isDead", true);
            Destroy(gameObject, 1.5f);
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

    public void flip()
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

    public void AttackDamage(float attack)
    {
        enemyData.enemyCurHP -= attack;
        heartSlider.value = enemyData.enemyCurHP / enemyData.enemyMaxHP;
    }
}
