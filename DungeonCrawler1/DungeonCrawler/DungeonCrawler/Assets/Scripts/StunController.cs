using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().stunned = true;
        }
        if (collision.CompareTag("Wizard"))
        {
            collision.GetComponent<WizardController>().stunned = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().stunned = true;
        }
        if (collision.CompareTag("Wizard"))
        {
            collision.GetComponent<WizardController>().stunned = true;
        }
    }
}
