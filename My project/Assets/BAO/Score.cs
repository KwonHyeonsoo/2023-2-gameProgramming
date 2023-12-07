using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;


public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TextMeshProUGUI ScoreText;

    public GameOverScreen GameOverScreen;
    public float distance;
    public Transform player;

    void Start() {
        transform.position=player.position;
        distance=0;
    }
    void Update() {
        distance=Vector3.Distance(player.position, transform.position);

        ScoreText.text = "Score: " + ((int)(distance)).ToString();
        GameOverScreen.Setup((int)distance);
    }

    /*
    void OnGUI() {
        GUI.Label(new Rect(750, 10, 100, 20), distance.ToString(),TextStyle);
    }
    */

}
