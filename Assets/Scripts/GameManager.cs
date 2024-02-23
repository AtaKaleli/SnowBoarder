using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float delayAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Invoke("OnCollisionEnterFinishLine", delayAmount);
        }
            
        else if (collision.tag == "FinishLine")
        {
            Invoke("OnCollisionEnterCrash", delayAmount);

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
