using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunActivation : MonoBehaviour
{
    public GameObject stunAoE;
    public static float stunInterval = 6f;
    float nextStunTimer = 0f;
    public AudioClip stunSound;

    public static bool stunReady = false;

    float upTime = 1f;
    float upTimer = 0f;

    bool stunned = false;

    void Update()
    {
        if(ShopUIControl.StunRadUp == true)
        {
            stunAoE.GetComponent<CircleCollider2D>().radius = 4.5f;
        }

        nextStunTimer += Time.deltaTime;

        if (nextStunTimer >= stunInterval)
        {
            stunReady = true;
            if (Input.GetKey(KeyCode.E))
            {
                Stun();
            }
        }
        if(stunned == true)
        {
            upTimer += Time.deltaTime;
        }
        if(upTimer >= upTime)
        {
            stunned = false;
            stunAoE.SetActive(false);
            upTimer = 0;
        }
    }

    private void Stun()
    {
        GetComponent<AudioSource>().PlayOneShot(stunSound);
        stunReady = false;
        stunned = true;
        stunAoE.SetActive(true);

        nextStunTimer = 0;
    }
}
