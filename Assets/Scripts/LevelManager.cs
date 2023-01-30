using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel() // restartbutonuna onclick kýsmýndan atýyoruz LevelManager ý orndan da bunu seçiyoruz
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }


    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;   // þu anki sahnemizin indexinin 1 attýrýlmýþ hali
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;      // toplam sahne sayýsýnýn 1 eksiði

        if (nextSceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }


    }

    

}



