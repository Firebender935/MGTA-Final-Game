using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int gems = 0;
    private int savedGems = 0;
    [SerializeField] int health = 100;

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            gems = 0;
            savedGems = 0;
            health = 100;
        }
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public int GetGems()
    {
        return gems;
    }
    public void AddGems(int amount)
    {
        gems += amount;
    }

    public void RemoveGems(int amount)
    {
        gems -= amount;
    }

    public int GetHealth()
    {
        return health;
    }
    public void ReduceHealth(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 100;
            gems = savedGems;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddHealth(int heal)
    {
        if((health + heal) > 150)
        {
            health = 150;
        }
        else if ((health + heal) <= 150)
        {
            health += heal;
        }
    }

    public void SaveGems()
    {
        savedGems = gems;
    }
}
