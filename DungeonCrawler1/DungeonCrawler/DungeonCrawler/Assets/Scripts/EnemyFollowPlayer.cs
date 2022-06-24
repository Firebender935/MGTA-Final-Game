using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public bool stunned = false;
    private float stunTime = 3f;
    private float stunTimer = 0f;

    private Transform player;
    public GameObject bullet;
    public GameObject bulletParent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        if (stunned == false)
        {
            if (distFromPlayer < lineOfSight && distFromPlayer > shootingRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distFromPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
        else if(stunned == true)
        {
            stunTimer += Time.deltaTime;
            if(stunTimer >= stunTime)
            {
                stunned = false;
                stunTimer = 0;
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}