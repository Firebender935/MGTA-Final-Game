using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WizardStop : MonoBehaviour
{
    public GameObject Wizard;
    public bool stunned = false;

    public GameObject Player;

    public AudioClip enemyAttackSound;

    public GameObject bullet;
    public GameObject bulletParent;

    public float attackInterval = 1f;
    private float attackTimer = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Wizard.GetComponent<AIPath>().enabled = false;
            InvokeRepeating("Attack", 0, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Wizard.GetComponent<AIPath>().enabled = false;
            InvokeRepeating("Attack", 0, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Wizard.GetComponent<AIPath>().enabled = true;
            CancelInvoke("Attack");
        }
    }

    private void Attack()
    {
        if (stunned == false)
        {
            if (attackTimer >= attackInterval)
            {
                Player.GetComponent<AudioSource>().PlayOneShot(enemyAttackSound);
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                attackTimer = 0;
            }
        }
    }

    private void Update()
    {
        stunned = Wizard.GetComponent<WizardController>().stunned;
        attackTimer += Time.deltaTime;
    }
}
