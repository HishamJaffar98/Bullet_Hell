using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public bool isGamePaused = false;
    [SerializeField] GameObject myPauseMenu;
    MusicPlayer myMusicPlayer;
    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void LoadGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game");
    }

    public void StartGame()
    {
        StartCoroutine(WaitAndLoadGameForFirstTime());
    }

    public IEnumerator WaitAndLoadGameForFirstTime()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad());
    }

    public IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOverScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        myMusicPlayer = FindObjectOfType<MusicPlayer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == false)
        {
            PauseFuntion(true, 0f, 0.2f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == true)
        {
            PauseFuntion(false, 1f, 1f);
        }
    }

    public void ResumeGame()
    {
        PauseFuntion(false, 1f, 1f);
    }

    void PauseFuntion(bool activator, float timeStop, float volumeLevel)
    {
        myPauseMenu.SetActive(activator);
        Time.timeScale = timeStop;
        myMusicPlayer.GetComponent<AudioSource>().volume = volumeLevel;
        isGamePaused = activator;
    }
}
