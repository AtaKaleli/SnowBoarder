using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float delayAmount;
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private ParticleSystem snowEffect;

    private bool hasCrashed;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().changeMove();
            crashEffect.Play();
            AudioManager.instance.PlayCrashSFX();
            Invoke("OnCollisionEnterFinishLine", delayAmount);
        }
            
        else if (collision.tag == "FinishLine")
        {
            finishEffect.Play();
            AudioManager.instance.PlayFinishSFX();
            Invoke("OnCollisionEnterCrash", delayAmount);

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



    

    private void OnCollisionEnterFinishLine()
    {
        SceneManager.LoadScene("Level1");
    }

    private void OnCollisionEnterCrash()
    {
        SceneManager.LoadScene("Level1");
    }
}
