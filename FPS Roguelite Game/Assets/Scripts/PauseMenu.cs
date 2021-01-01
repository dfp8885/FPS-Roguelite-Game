using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public FloorProgressBar progress;
    public GameObject pauseMenuUI;
    public GameObject HUD;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
        if (FloorProgressBar.floorComplete) {
            LoadNextFloor();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void LoadNextFloor() {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        TileGeneration.BossFloor = !TileGeneration.BossFloor;
        progress.progressReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}