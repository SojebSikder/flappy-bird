using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int myScore;
    public int maxScore;
	public Text myScoreGUI;

	public Transform bottomObstacle,topObstacle;

	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        // in the beginning game will be freeze. to give player proper time to prepare
        Time.timeScale = 0f;

        myScore = 0;
        maxScore = 0;

		myScoreGUI = GameObject.Find ("Text")
			.GetComponent<Text> ();

		InvokeRepeating ("ObstacleSpawner", .5f, 1.5f);

		audioSource = gameObject.GetComponent<AudioSource> ();

        // load saved game data
        LoadGame();
	}

    // Update is called once per frame
    void Update()
    {
        if (maxScore > myScore)
        {
            maxScore=myScore;
        }
        // save game data
        SaveGame();
    }
		
	public void GmAddScore(){
		this.myScore++;
		myScoreGUI.text = myScore.ToString();
		audioSource.Play ();
	}


	void ObstacleSpawner() {
		int rand = Random.Range (0, 2);
		float topObstacleMinY = 2f,
		topObstacleMaxY = 6f,
		bottomObstacleMinY = -6f,
		bottomObstacleMaxY = -2f;

		switch (rand) {
		case 0:
			Instantiate (
				bottomObstacle,
				new Vector2 (
					9f, 
					Random.Range (bottomObstacleMinY, bottomObstacleMaxY)
				), 
				Quaternion.identity);

			break;
		case 1:
			Instantiate (
				topObstacle,
				new Vector2 (
					9f, 
					Random.Range (topObstacleMinY, topObstacleMaxY)
				), 
				Quaternion.identity);

			break;
		}
	
	}


    //System Function
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()              //Load First all the variable (Important)
    {
        GameData data = SaveSystem.LoadGame();
        maxScore = data.Score;
    }
    //End for LoadGame()



}





