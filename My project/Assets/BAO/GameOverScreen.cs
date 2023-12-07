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
   private int highscore;

    void OnEnable()
    {
        int score =(int) staticValues.playerScore;

        Debug.Log(PlayerPrefs.HasKey("highscore") + PlayerPrefs.GetInt("highscore", highscore).ToString());
        if (PlayerPrefs.HasKey("highscore") == true)
        {
            highscore = PlayerPrefs.GetInt("highscore", highscore);
            H_ScoreTextGA.text = "High Point: " + highscore.ToString() + "M";
        }
        else
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        ScoreTextGA.text = "YOUR POINTS: " + score.ToString() + "M";


        if (score > highscore)
        {
            highscore = score;
            H_ScoreTextGA.text = "High Point: " + score + "M";

            PlayerPrefs.SetInt("highscore", highscore);
        }

    }
   public void Setup(int score) {
        ScoreTextGA.text = "YOUR POINTS: " + score.ToString() + "M";


        if (score > highscore){
          highscore = score;
          H_ScoreTextGA.text = "High Point: " + score+"M";
 
          PlayerPrefs.SetInt ("highscore", highscore);
    }

   }
   public void RestartButton(){
        SceneManager.LoadScene("SampleScene1"); //게임 있는 Scene

   }
   public void ExitButton() {
        SceneManager.LoadScene("MainMenu");

   }
    public void ExitButton1()
    {
        SceneManager.LoadScene("Final_MainMenu");
        Time.timeScale = 1;

    }
}
