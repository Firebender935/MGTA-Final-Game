using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WizardController : MonoBehaviour
{
    [SerializeField] int health = 70;

    public bool stunned = false;

    public GameObject Player;

    public AudioClip enemyDeathSound;
    public AudioClip enemyDamageSound;

    public static float stunTime = 3f;
    float stunTimer = 0f;

    private void Update()
    {
        if (ShopUIControl.StunDurUp == true)
        {
            stunTime = 5f;
        }

        if (stunned == true)
        {
            GetComponent<AIPath>().enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
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
}
