using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyMove : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float traceDistance = 2f;

    public Transform player;
    public EnemyManager enemyManager;
    public DragonAniController dragonAniController;
    public GameObject fireBall;
    public float collDownTime = 1;
    public float setCollDownTime = 4;
    Vector3 targetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(enemyManager.enemyData.enemyCurHP < enemyManager.enemyData.enemyMaxHP - enemyManager.enemyData.enemyMaxHP/5)
        {
            targetPosition = transform.position;
            targetPosition.y = 0f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed+0.3f);
            dragonAniController.DragonFallTrue();
            return;
        }

        Vector2 direction = player.position - transform.position;
        if (direction.magnitude > traceDistance)
            return;
        collDownTime -= Time.deltaTime;

        targetPosition = transform.position;
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
        else if(collDownTime < 0)
        {
            GameObject FireBallObject = Instantiate(fireBall);
            FireBallObject.transform.position = transform.position - new Vector3(0, 1, 0);
            FireBallObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            collDownTime = setCollDownTime;
        }
        
    }

    public void flip(int x)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = x;
        transform.localScale = localScale;
    }
}
