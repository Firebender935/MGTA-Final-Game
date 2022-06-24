using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text gemsText;
    [SerializeField] Text healthText;
    [SerializeField] GameObject stunReadyText;
    [SerializeField] GameObject stunNotReadyText;

    void Update()
    {
        gemsText.text = "GEMS: " + GameManager.Instance.GetGems();
        healthText.text = "HEALTH: " + GameManager.Instance.GetHealth();
        if(StunActivation.stunReady == true)
        {
            stunReadyText.SetActive(true);
            stunNotReadyText.SetActive(false);
        }
        else if (StunActivation.stunReady == false)
        {
            stunReadyText.SetActive(false);
            stunNotReadyText.SetActive(true);
        }
    }
}
