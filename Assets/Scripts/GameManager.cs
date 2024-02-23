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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("OnCollisionEnterFinishLine", delayAmount);
        }
            
        else if (collision.tag == "FinishLine")
        {
            finishEffect.Play();
            Invoke("OnCollisionEnterCrash", delayAmount);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            snowEffect.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            snowEffect.Play();
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
