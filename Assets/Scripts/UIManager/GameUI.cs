using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public static GameUI instance;
    public bool levelEnd;

    [SerializeField] private GameObject endGamePanel;

    private void Awake()
    {
        instance = this;
        levelEnd = false;
    }

    public void OnClickNextLevel()
    {
        Time.timeScale = 1;
        LevelTransition.instance.PlayEndTransition();
        StartCoroutine(MoveNextLevel());
        
    }

    public void OnClickRestartLevel()
    {
        Time.timeScale = 1;
        LevelTransition.instance.PlayEndTransition();
        StartCoroutine(MoveRestartLevel());
    }

    public void OnClickReturnMenu()
    {
        Time.timeScale = 1;
        LevelTransition.instance.PlayEndTransition();
        StartCoroutine(MoveReturnMenu());

    }

    public void OnClickExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    IEnumerator MoveNextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    IEnumerator MoveRestartLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator MoveReturnMenu()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");

    }

    public void MakeEndGamePanelSet()
    {
        endGamePanel.SetActive(true);
        levelEnd = true;
    }

    

}
