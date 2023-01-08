using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenuUI;

    // Sound
    public AudioSource musicSource;
    public AudioSource effectSource1;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = false;

    }

    void Update()
    {
        if(GameIsPaused) {
            pauseGame();
        }
        else {
            resumeGame();
        }        
    }

    public void showMenu(){
        SceneManager.LoadScene("StartScene");
    }

    public void pauseGame() {
        PauseMenuUI.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;  // Freeze the time
        GameIsPaused = true;        
    }

    public void resumeGame() {
        PauseMenuUI.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;  // Unfreeze the time
        GameIsPaused = false;
    }

    public void quitGame(){
        Debug.Log("Game Over");
        Application.Quit();
    }

    // Sound
    public void SetMusicVolume(float volume){
        musicSource.volume = volume;
    }
    public void SetEffectVolume(float volume){
        effectSource1.volume = volume;
    }
}

