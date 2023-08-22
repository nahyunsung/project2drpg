using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireBallOner
{
    enemy,
    player
}

public class FireBallScript : MonoBehaviour
{
    public float moveSpeed = .5f;
    public FireBallOner fireBallOner;
    public float FireBallDamage = 10;

    void Start()
    {
        fireBallOner = FireBallOner.enemy;
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

        if(transform.position.y  < -2.6 || transform.position.y > 8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && fireBallOner == FireBallOner.enemy)
        {
            other.GetComponent<PlayerControllerExample>().AttackDamage(FireBallDamage);

            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy") && fireBallOner == FireBallOner.player)
        {
            other.GetComponent<EnemyManager>().AttackDamage(FireBallDamage);

            Destroy(this.gameObject);
        }

    }
}
