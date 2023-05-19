using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuCanvas;
    GameObject backgroundMusic;
    AudioSource gameBGM;

    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    private void Awake()
    {
        backgroundMusic = GameObject.Find("AudioManager");
        gameBGM = backgroundMusic.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        gameBGM.Play();
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        gameBGM.Pause();
    }
}
