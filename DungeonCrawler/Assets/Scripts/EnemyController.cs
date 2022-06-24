using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int damage = 20;
    [SerializeField] int health = 50;

    public bool stunned = false;

    public GameObject Player;

    public AudioClip enemyAttackSound;
    public AudioClip enemyDeathSound;
    public AudioClip enemyDamageSound;
    public AudioClip playerDamageSound;

    public static float stunTime = 3f;
    float stunTimer = 0f;

    private void Update()
    {
        if(ShopUIControl.StunDurUp == true)
        {
            stunTime = 5f;
        }

        if(stunned == true)
        {
            GetComponent<AIPath>().enabled = false;
            stunTimer += Time.deltaTime;
            if(stunTimer >= stunTime)
            {
                GetComponent<AIPath>().enabled = true;
                stunned = false;
                stunTimer = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Player.GetComponent<AudioSource>().PlayOneShot(enemyDamageSound);
        if (stunned == false)
        {
            GetComponent<AIPath>().enabled = true;
        }
        health -= damage;

        if (health <= 0)
        {
            Player.GetComponent<AudioSource>().PlayOneShot(enemyDeathSound);
            Destroy(this.gameObject);
        }
    }

    private void Attack()
    {
        if (stunned == false)
        {
            Player.GetComponent<AudioSource>().PlayOneShot(enemyAttackSound);
            GameManager.Instance.ReduceHealth(damage);
            Player.GetComponent<AudioSource>().PlayOneShot(playerDamageSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 0, 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke("Attack");
    }
}
