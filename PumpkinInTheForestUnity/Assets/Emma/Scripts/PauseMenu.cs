using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
        }

        if (gameIsPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }

    }

    void ActivateMenu()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }

}
