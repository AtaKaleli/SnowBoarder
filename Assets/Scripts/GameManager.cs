using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Tutorial")]
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private GameObject infoObject;


    public float overallScore;

    
    private void Awake()
    {
      
        
        overallScore = 0;

    }


    private void Update()
    {

        
        overallScore += Time.deltaTime;
        CalculateScore(overallScore);
        


    }


    



  


    






    public void CalculateScore(float score)
    {
        scoreText.text = score.ToString("#,#");
    }


    IEnumerator DisableInfoText()
    {
        yield return new WaitForSeconds(3f);
        infoObject.SetActive(false);

    }


    public void EnableInfoText() => infoObject.SetActive(true);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WelcomingInfo")
        {
            
            AudioManager.instance.PlayWelcomingSFX();
            
        }


        else if (collision.tag == "LeftShiftInfo")
        {

            EnableInfoText();
            infoText.text = "Press LEFT SHIFT to speed up ";
            AudioManager.instance.PlayLeftShiftInfoSFX();
            StartCoroutine(DisableInfoText());
        }

        else if (collision.tag == "RotateInfo")
        {

            EnableInfoText();
            infoText.text = "Press A or D to rotate your character";
            AudioManager.instance.PlayRotateInfoSFX();
            StartCoroutine(DisableInfoText());
        }

        else if (collision.tag == "RotateBackwardInfo")
        {

            EnableInfoText();
            infoText.text = "Press and hold A";
            
            StartCoroutine(DisableInfoText());
        }

        else if (collision.tag == "RotateInfoForward")
        {

            EnableInfoText();
            infoText.text = "Press and hold D";
            AudioManager.instance.PlayRotateInfoForwardSFX();
            StartCoroutine(DisableInfoText());
        }

        else if (collision.tag == "TryInfo")
        {

         
            AudioManager.instance.PlayTrySpinInfoSFX();
            
        }
        else if (collision.tag == "FinalInfo")
        {


            AudioManager.instance.PlayFinalInfoSFX();

        }


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
            
            overallScore += 100;
            CalculateScore(overallScore);

            AudioManager.instance.PlayCollectScoreObjectSFX();
            Destroy(collision.gameObject);
        }


        if(collision.tag == "level1Achivement" && !gotLevelAchivements[0])
        {
            AudioManager.instance.PlayLevel1AchivementSFX();
            overallScore += 10000;
            Destroy(collision.gameObject);
            achivementPanel.SetActive(true);
            gotLevelAchivements[0] = true;
            StartCoroutine(CloseAchivementPanel());

        }

        else if (collision.tag == "Level2Achivement" && !gotLevelAchivements[1])
        {

            overallScore += 10000;
            Destroy(collision.gameObject);
            AudioManager.instance.PlayLevel2AchivementSFX();
            achivementPanel.SetActive(true);
            gotLevelAchivements[1] = true;
            StartCoroutine(CloseAchivementPanel());

        }

        else if (collision.tag == "Level3Achivement" && !gotLevelAchivements[2])
        {
            AudioManager.instance.PlayLevel3AchivementSFX();
            achivementPanel.SetActive(true);
            overallScore += 10000;
            Destroy(collision.gameObject);
            mainCamera.backgroundColor = Color.black;
            gotLevelAchivements[2] = true;
            StartCoroutine(CloseAchivementPanel());

        }

        else if (collision.tag == "Level4Achivement" && !gotLevelAchivements[3])
        {
            AudioManager.instance.PlayLevel4AchivementSFX();
            achivementPanel.SetActive(true);
            overallScore += 10000;
            Destroy(collision.gameObject);
            gotLevelAchivements[3] = true;
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
