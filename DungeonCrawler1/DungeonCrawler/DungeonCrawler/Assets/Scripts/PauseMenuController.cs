using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject FirePoint;
    public GameObject Player;

    public AudioClip buttonSound;

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                GetComponent<AudioSource>().PlayOneShot(buttonSound);
                Resume();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(buttonSound);
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        FirePoint.SetActive(false);
        Player.GetComponent<StunActivation>().enabled = false;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FirePoint.SetActive(true);
        Player.GetComponent<StunActivation>().enabled = false;
        GameIsPaused = false;
    }
}
