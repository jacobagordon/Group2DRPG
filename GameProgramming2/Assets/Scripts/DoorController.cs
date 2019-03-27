using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    float levelLoadDealay = 2f;
    [SerializeField]
    float levelExitSlowMo = 0.2f;
    [SerializeField]
    string levelToLoad;

    //private LevelLoader levelLoadScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowMo;
        yield return new WaitForSecondsRealtime(levelLoadDealay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelToLoad);
        //levelLoadScript.LoadNextScene();
    }
}
