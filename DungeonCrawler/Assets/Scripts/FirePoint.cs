using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Camera theCam;
    public Transform firePoint;
    public GameObject player;
    public AudioClip fireballSound;

    [SerializeField] GameObject projectile;
    [SerializeField] float attackInterval = 0.5f;
    float attackTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                player.GetComponent<AudioSource>().PlayOneShot(fireballSound);
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (Vector2)((worldMousePos - transform.position));
                direction.Normalize();
                // Creates the bullet locally
                GameObject bullet = (GameObject)Instantiate(
                                        projectile,
                                        transform.position + (Vector3)(direction * 0.5f),
                                        Quaternion.identity);
                // Adds velocity to the bullet
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
                attackTimer = 0;
            }
        }

    }
    private void SpawnProjectile(Vector3 direction)
    {
        GameObject instance = Instantiate(projectile, transform.position, transform.rotation);
        instance.GetComponent<ProjectileController>().SetVelocity(direction);
        attackTimer = attackInterval;
    }
}