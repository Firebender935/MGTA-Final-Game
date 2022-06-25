using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIControl : MonoBehaviour
{
    public GameObject player;
    public GameObject ShopUI;
    public GameObject FirePoint;

    public GameObject dmgButton;
    public GameObject dmgUpLack;

    public GameObject StunDurButton;
    public GameObject StunDurLack;

    public GameObject StunRadButton;
    public GameObject StunRadLack;

    public GameObject healGemLack;
    public AudioClip buttonSound;

    public GameObject OverHeal;

    public static bool DmgUP = false;
    public static bool StunDurUp = false;
    public static bool StunRadUp = false;

    private void Update()
    {
        if(DmgUP == true)
        {
            dmgButton.SetActive(false);
        }
        if(StunDurUp == true)
        {
            StunDurButton.SetActive(false);
        }
        if(StunRadUp == true)
        {
            StunRadButton.SetActive(false);
        }
    }

    private void Start()
    {
        FirePoint.GetComponent<FirePoint>().enabled = false;
        dmgUpLack.SetActive(false);
        StunDurLack.SetActive(false);
        StunRadLack.SetActive(false);
        healGemLack.SetActive(false);
        OverHeal.SetActive(false);
    }

    public void ButtonPress()
    {
        player.GetComponent<AudioSource>().PlayOneShot(buttonSound);
    }

    public void Play()
    {
        ShopUI.SetActive(false);
        FirePoint.GetComponent<FirePoint>().enabled = true;
        Time.timeScale = 1f;
    }

    public void DamageUp()
    {
        if (GameManager.Instance.gems >= 25)
        {
            DmgUP = true;
            dmgButton.SetActive(false);
            dmgUpLack.SetActive(false);
            GameManager.Instance.RemoveGems(25);
        }
        else if(GameManager.Instance.gems < 25)
        {
            dmgUpLack.SetActive(true);
        }
    }

    public void HealGem()
    {
        if (GameManager.Instance.GetHealth() < 150)
        {
            if (GameManager.Instance.gems >= 10)
            {
                healGemLack.SetActive(false);
                GameManager.Instance.AddHealth(10);
                GameManager.Instance.RemoveGems(10);
            }
            else if (GameManager.Instance.gems < 10)
            {
                healGemLack.SetActive(true);
            }
        }
        else if(GameManager.Instance.GetHealth() >= 150)
        {
            healGemLack.SetActive(false);
            OverHeal.SetActive(true);
        }
    }

    public void StunDuration()
    {
        if (GameManager.Instance.gems >= 20)
        {
            StunDurUp = true;
            StunDurButton.SetActive(false);
            StunDurLack.SetActive(false);
            GameManager.Instance.RemoveGems(20);
        }
        else if (GameManager.Instance.gems < 20)
        {
            StunDurLack.SetActive(true);
        }
    }

    public void StunRadius()
    {
        if (GameManager.Instance.gems >= 20)
        {
            StunRadUp = true;
            StunRadButton.SetActive(false);
            StunRadLack.SetActive(false);
            GameManager.Instance.RemoveGems(20);
        }
        else if (GameManager.Instance.gems < 20)
        {
            StunRadLack.SetActive(true);
        }
    }
}
