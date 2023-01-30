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

    public void RestartLevel() // restartbutonuna onclick k�sm�ndan at�yoruz LevelManager � orndan da bunu se�iyoruz
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }


    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;   // �u anki sahnemizin indexinin 1 att�r�lm�� hali
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;      // toplam sahne say�s�n�n 1 eksi�i

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



