using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{

    public static LevelTransition instance;

    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;

    void Start()
    {
        instance = this;
        startingSceneTransition.SetActive(true);
        StartCoroutine(DisableStartTransition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DisableStartTransition()
    {
        yield return new WaitForSeconds(3f);
        startingSceneTransition.SetActive(false);
        
    }

    public void PlayEndTransition()
    {
        endingSceneTransition.SetActive(true);
    }

}
