using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenu : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("SampleScene");
    }
 
    public void options() {
        
    }
 
    public void exitGame() {
        Application.Quit();
    }
}