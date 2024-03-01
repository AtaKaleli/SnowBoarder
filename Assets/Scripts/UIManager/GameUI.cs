using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public static GameUI instance;
    public bool levelEnd;

    [SerializeField] private GameObject endGamePanel;
    private string[,] endLevelInfo = {
                                                        { "Level Name: Magma\n\nGravity: High\nSpeed: Low\nSpin: Low\n" },
                                                        { "Level Name: Earth\n\nGravity: Medium\nSpeed: Medium\nSpin: Medium\n" },
                                                        { "Level Name: Moon\n\nGravity: Extremely Low\nSpeed: High\nSpin: High\n" },
                                                        { "Level Name: Space\n\nGravity: Low\nSpeed: Very High\nSpin: Extremely High\n" },
                                                        { "You have successfully completed all levels!\n\n" }
                                                        };

    [SerializeField] private TextMeshProUGUI levelInfoText;
    [SerializeField] private TextMeshProUGUI scoreInfoText;
    [SerializeField] private GameObject nextLevelButton;
    private GameManager gameManager;

    private void Awake()
    {
        instance = this;
        levelEnd = false;
        gameManager = FindObjectOfType<GameManager>();
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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        scoreInfoText.text = "Your Score is: " + gameManager.overallScore.ToString("#,#");
        levelInfoText.text = endLevelInfo[currentScene-1,0];
        levelEnd = true;
    }

    public void MakeNextLevelButtonClear()
    {
        nextLevelButton.SetActive(false);
    }


}
