using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
   public TMPro.TextMeshProUGUI ScoreTextGA;
   public TMPro.TextMeshProUGUI H_ScoreTextGA;
   public int highscore;
   public int score;
   void Start()
{
    score = 0;
 
    highscore = PlayerPrefs.GetInt ("highscore", highscore);
    H_ScoreTextGA.text = "High Point: " + highscore.ToString();
}

   public void Setup(int score) {
        gameObject.SetActive(true);
        ScoreTextGA.text = "YOUR POINTS: " + score.ToString() + "M";
     if (score > highscore){
        highscore = score;
        H_ScoreTextGA.text = "HighScore: " + score;

        PlayerPrefs.SetInt ("highscore", highscore);
    }
   }
   public void Update(){

   }
   public void RestartButton(){
        SceneManager.LoadScene("SampleScene"); //게임 있는 Scene

   }
   public void ExitButton() {
        SceneManager.LoadScene("MainMenu");

   }
}
