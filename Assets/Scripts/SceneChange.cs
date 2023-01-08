using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;

    // Game States
    // 1) Game Over
    private bool isGameOver;
    // 2) Game Play: Fever Time
    private bool isFeverTime;


    void Awake()
    {
        if(!isGameOver) {
            instance=this;
        }
    }

    void Start()
    {
        isGameOver = false;
        isFeverTime = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

       // Change scene
    public void playGame() {
        isGameOver = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void showMenu(){
        isGameOver = true;
        SceneManager.LoadScene("StartScene");
    }

    public void quitGame(){
        Application.Quit();
    }

}
