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

    [SerializeField] private Text timeText;    //  CANVAS TAKÝ TÝME TEXTÝNÝ TANIMLIYORUZ

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

            foreach (GameObject allObjects in destroyAfterGame)   // çoðul olduðu için s olaný seçtik
            {
                Destroy(allObjects);       // kazanýnca bütün destroyAfterGame elemanlarý yok edilecek.
            }

        }

        if (gameOver == true)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);

            UptadeObjectList("Objects");
            UptadeObjectList("Enemy");


            // Sadece belirli bir tag üzerinden yapýlacaksa böyle yapýlyýor.

            foreach (GameObject allObjects in GameObject.FindGameObjectsWithTag("Enemy"))  //yukarýdaki tek farký burda doðrudan tag üzerinde, yukarýda ise taglerle doldurdupumuz liste üzerinden yapýyor.
            {
                Destroy(allObjects);       // kaybedince bütün Enemy tagina sahip elemanlar yok edilecek.
            }

            foreach (GameObject allObjects in GameObject.FindGameObjectsWithTag("Objects"))  //yukarýdaki tek farký burda doðrudan tag üzerinde, yukarýda ise taglerle doldurdupumuz liste üzerinden yapýyor.
            {
                Destroy(allObjects);       // kaybedince bütün Objects tagina sahip elemanlar yok edilecek.
            }

        }

        

    }

    private void UptadeTheTimer()
    {
        
        timeText.text = "Time: "+(int)Time.timeSinceLevelLoad;
    }


    private void UptadeObjectList(string tag)        // destroyAfterGame listesine tag ile obje atýyorz.
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
        
    }

}
