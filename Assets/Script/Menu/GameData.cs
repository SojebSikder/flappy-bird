
[System.Serializable]
public class GameData
{
    public int Score;
    public int maxScore;

    public GameData(GameManager gameManager)
    {
        Score = gameManager.myScore;
        maxScore = gameManager.maxScore;
    }

}