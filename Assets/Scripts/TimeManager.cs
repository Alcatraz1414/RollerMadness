using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    [SerializeField] public bool gameFinish;
    [SerializeField] public bool gameOver;
    [SerializeField] private float levelFinishTime = 5f;

    [SerializeField] private Text timeText;    //  CANVAS TAK� T�ME TEXT�N� TANIMLIYORUZ

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private List<GameObject> destroyAfterGame=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        winPanel.SetActive(false);
        losePanel.SetActive(false);*/

        

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && gameFinish == false)
        {
            UptadeTheTimer();
        }


        if (levelFinishTime <= Time.timeSinceLevelLoad && gameOver==false)
        {
            gameFinish = true;      
            winPanel.SetActive(true);
            losePanel.SetActive(false);

            UptadeObjectList("Objects");
            UptadeObjectList("Enemy");

            foreach (GameObject allObjects in destroyAfterGame)   // �o�ul oldu�u i�in s olan� se�tik
            {
                Destroy(allObjects);       // kazan�nca b�t�n destroyAfterGame elemanlar� yok edilecek.
            }

        }

        if (gameOver == true)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);

            UptadeObjectList("Objects");
            UptadeObjectList("Enemy");


            // Sadece belirli bir tag �zerinden yap�lacaksa b�yle yap�ly�or.

            foreach (GameObject allObjects in GameObject.FindGameObjectsWithTag("Enemy"))  //yukar�daki tek fark� burda do�rudan tag �zerinde, yukar�da ise taglerle doldurdupumuz liste �zerinden yap�yor.
            {
                Destroy(allObjects);       // kaybedince b�t�n Enemy tagina sahip elemanlar yok edilecek.
            }

            foreach (GameObject allObjects in GameObject.FindGameObjectsWithTag("Objects"))  //yukar�daki tek fark� burda do�rudan tag �zerinde, yukar�da ise taglerle doldurdupumuz liste �zerinden yap�yor.
            {
                Destroy(allObjects);       // kaybedince b�t�n Objects tagina sahip elemanlar yok edilecek.
            }

        }

        

    }

    private void UptadeTheTimer()
    {
        
        timeText.text = "Time: "+(int)Time.timeSinceLevelLoad;
    }


    private void UptadeObjectList(string tag)        // destroyAfterGame listesine tag ile obje at�yorz.
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
        
    }

}
