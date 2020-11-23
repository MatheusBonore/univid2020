using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TomaDano(int dano)
    {
        if (vida == 0)
        {
            GameOver();
        }
        else
        {
            vida -= dano;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("ZombieBasicos");
    }
}
