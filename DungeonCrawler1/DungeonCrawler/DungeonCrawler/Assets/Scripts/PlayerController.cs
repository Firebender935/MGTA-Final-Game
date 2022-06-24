using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] GameObject projectile;


    public AudioClip fireballSound;
    public AudioClip gemSound;
    public AudioClip healSound;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector2 v = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        v.Normalize();
        v *= speed;
        rb.velocity = v;
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            GetComponent<AudioSource>().PlayOneShot(gemSound);
            GameManager.Instance.AddGems(1);
            Destroy(collision.gameObject);
        }

        if(GameManager.Instance.GetHealth() < 150) { 
            if (collision.CompareTag("HealItem"))
            {
                GetComponent<AudioSource>().PlayOneShot(healSound);
                if ((GameManager.Instance.GetHealth() + collision.GetComponent<HealItemControl>().HealAmount()) > 150)
                {
                    GameManager.Instance.AddHealth(150 - GameManager.Instance.GetHealth());
                    Destroy(collision.gameObject);
                }
                else
                {
                    GameManager.Instance.AddHealth(collision.GetComponent<HealItemControl>().HealAmount());
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
