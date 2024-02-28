using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private GameObject infoObject;

    



    public void EnableInfoText() => infoObject.SetActive(true);
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LeftShiftInfo")
        {
            print("yes");
            /*
            EnableInfoText();
            AudioManager.instance.PlayLeftShiftInfoSFX();
            StartCoroutine(DisableInfoText());*/
        }

    }


    IEnumerator DisableInfoText()
    {
        yield return new WaitForSeconds(3f);
        infoObject.SetActive(false);

    }
}
