using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExit : MonoBehaviour
{
    public GameObject Exit;
    public GameObject ExitOpenText;
    public GameObject ExitClosedText;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                ExitOpenText.SetActive(true);
                ExitClosedText.SetActive(false);
                Exit.SetActive(true);
            }
            else
            {
                ExitOpenText.SetActive(false);
                ExitClosedText.SetActive(true);
                Exit.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 19)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                ExitOpenText.SetActive(true);
                ExitClosedText.SetActive(false);
                Exit.SetActive(true);
            }
            else
            {
                ExitOpenText.SetActive(false);
                ExitClosedText.SetActive(true);
                Exit.SetActive(false);
            }
        }
    }
}
