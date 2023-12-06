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

   public void Setup(int score) {
        gameObject.SetActive(true);
        ScoreTextGA.text = "YOUR POINTS: " + score.ToString() + "M";
   }
   public void RestartButton(){
        SceneManager.LoadScene("SampleScene"); //게임 있는 Scene

   }
   public void ExitButton() {
        SceneManager.LoadScene("MainMenu");

   }
}
