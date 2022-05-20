using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public int maxScore;
    public int Score;
    public Text maxScoreGUI;
    public Text ScoreGUI;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = 0;
        Score = 0;

        maxScoreGUI = GameObject.Find("MaxScoreText")
            .GetComponent<Text>();

        ScoreGUI = GameObject.Find("ScoreText")
            .GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        LoadGame();
    }
    public void LoadGame()              //Load First all the variable (Important)
    {
        GameData data = SaveSystem.LoadGame();


        maxScore = data.maxScore;
        maxScoreGUI.text = "Max Score: "+ maxScore.ToString();

        Score = data.Score;
        ScoreGUI.text = "Current Score: " + Score.ToString();
    }
}
