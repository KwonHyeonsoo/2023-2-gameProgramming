using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum cubeTag { cube1, cube2 };
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void resetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fianl");
        Time.timeScale = 1;
    }
}
