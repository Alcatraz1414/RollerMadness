using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    [SerializeField] private Text scoreText; //CANVAS TAKÝ SCORE TEXTÝNÝ TANIMLIYORUZ
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UptadeTheScore();
    }

    private void UptadeTheScore()
    {
        scoreText.text="Score: "+ score.ToString();
    }

}
