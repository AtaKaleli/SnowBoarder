using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject howToPlayScreen;
    [SerializeField] private GameObject creditsScreen;
    





    public void OnClickOpenHowToPlayScreen()
    {
        MenuAudio.instance.PlayButtonClick();
        menuScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void OnClickOpenCreditsScreen()
    {
        MenuAudio.instance.PlayButtonClick();
        menuScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void OnClickCloseHowToPlayScreen()
    {
        MenuAudio.instance.PlayButtonClick();
        menuScreen.SetActive(true);
        howToPlayScreen.SetActive(false);
    }

    public void OnClickCloseCreditsScreen()
    {
        MenuAudio.instance.PlayButtonClick();
        menuScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }


    public void OnClickStartGame()
    {
        MenuAudio.instance.PlayButtonClick();
        menuScreen.SetActive(false);
        
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

   

   

   

}
