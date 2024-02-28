using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void OnClickSkipTutorial()
    {
        LevelTransition.instance.PlayEndTransition();
        StartCoroutine(StartGame());

    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
