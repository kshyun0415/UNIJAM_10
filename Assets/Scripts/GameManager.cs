using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int playerHP;
    public float gameSpeed = 6f;
    static float A_y = 7;
    static float B_y = 0;
    static float C_y = -7;


    // public GameObject DomidPannel;
    public GameObject Domidman;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHP = player.HP;
        if (playerHP == 10)
        {
            caughtByDomidman();
            player.HP -= 1;
        }
        Debug.Log(player.HP);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }


    void caughtByDomidman()
    {
        Time.timeScale = 0f;
        Debug.Log("CaughtByDomidman" + player.HP);
        Domidman.SetActive(true);


    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Domidman.SetActive(false);
    }

    public void AddHealth()
    {
        player.HP += 10;
        Time.timeScale = 1f;
        Domidman.SetActive(false);
    }
    public void SubHealth()
    {
        player.HP -= 9;
        Time.timeScale = 1f;

        Domidman.SetActive(false);
    }



}

