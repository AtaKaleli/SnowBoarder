using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float delayAmount;
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private ParticleSystem snowEffect;

    [SerializeField] private GameObject achivementPanel;

    [SerializeField] private Camera mainCamera;

    private bool hasCrashed;

    private bool[] gotLevelAchivements = { false, false, false, false };

    
    private void Awake()
    {

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.tag == "Ground" && !hasCrashed)
        {
            LevelTransition.instance.PlayEndTransition();
            hasCrashed = true;
            FindObjectOfType<PlayerController>().changeMove();
            crashEffect.Play();
            AudioManager.instance.PlayCrashSFX();
            Invoke("OnCollisionEnterCrash", delayAmount);
        }
            
        else if (collision.tag == "FinishLine")
        {
            LevelTransition.instance.PlayEndTransition();
            finishEffect.Play();
            AudioManager.instance.PlayFinishSFX();
            Invoke("OnCollisionEnterFinishLine", delayAmount);

        }


        if(collision.tag == "ScoreObject")
        {
            AudioManager.instance.PlayCollectScoreObjectSFX();
            Destroy(collision.gameObject);
        }


        if(collision.tag == "level1Achivement" && !gotLevelAchivements[0])
        {
            AudioManager.instance.PlayLevel1AchivementSFX();

            achivementPanel.SetActive(true);
            gotLevelAchivements[0] = true;
            StartCoroutine(CloseAchivementPanel());

        }

        else if (collision.tag == "Level2Achivement" && !gotLevelAchivements[1])
        {


            AudioManager.instance.PlayLevel1AchivementSFX();
            achivementPanel.SetActive(true);
            gotLevelAchivements[1] = true;
            StartCoroutine(CloseAchivementPanel());

        }

        else if (collision.tag == "Level3Achivement" && !gotLevelAchivements[2])
        {
            

            Destroy(collision.gameObject);
            mainCamera.backgroundColor = Color.black;
            gotLevelAchivements[2] = true;
            StartCoroutine(CloseAchivementPanel());

        }




    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            snowEffect.Stop();
            AudioManager.instance.PauseSnowBoardAudio();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            snowEffect.Play();
            AudioManager.instance.PlaySnowBoardAudio();
            
        }
    }


    IEnumerator CloseAchivementPanel()
    {
        yield return new WaitForSeconds(5f);
        achivementPanel.SetActive(false);
    }
    

    private void OnCollisionEnterFinishLine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnterCrash()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
