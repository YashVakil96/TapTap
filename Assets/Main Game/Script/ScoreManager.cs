using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public static bool isHighscore = false;

    private int score;
    public static int easyHighScore;
    public static int mediumHighScore;
    public static int hardHighScore;

    private void Start()
    {
        if (GameManager.instance.level == GameManager.Level.Easy)
        {
            if (PlayerPrefs.HasKey("easyHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("easyHighScorePref");
                easyHighScore = PlayerPrefs.GetInt("easyHighScorePref");
            }
        }

        if (GameManager.instance.level == GameManager.Level.Normal)
        {
            if (PlayerPrefs.HasKey("mediumHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("mediumHighScorePref");
                mediumHighScore = PlayerPrefs.GetInt("mediumHighScorePref");
            }
        }

        if (GameManager.instance.level == GameManager.Level.Hard)
        {
            if (PlayerPrefs.HasKey("hardHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("hardHighScorePref");
                hardHighScore = PlayerPrefs.GetInt("hardHighScorePref");
            }
        }
    }


    void Update()
    {
        if (GameManager.instance.level == GameManager.Level.Easy)
        {
            if (PlayerPrefs.HasKey("easyHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("easyHighScorePref");
                easyHighScore = PlayerPrefs.GetInt("easyHighScorePref");
            }
        }

        if (GameManager.instance.level == GameManager.Level.Normal)
        {
            if (PlayerPrefs.HasKey("mediumHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("mediumHighScorePref");
                mediumHighScore = PlayerPrefs.GetInt("mediumHighScorePref");
            }
        }

        if (GameManager.instance.level == GameManager.Level.Hard)
        {
            if (PlayerPrefs.HasKey("hardHighScorePref"))
            {
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("hardHighScorePref");
                hardHighScore = PlayerPrefs.GetInt("hardHighScorePref");
            }
        }

        score = Colliders.scorePoints;
        scoreText.text = score.ToString("0");

        if (GameManager.instance.level == GameManager.Level.Easy)
        {
            if (score > easyHighScore)
            {
                easyHighScore = score;
                PlayerPrefs.SetInt("easyHighScorePref", easyHighScore);
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("easyHighScorePref");
                PlayerPrefs.Save();
                isHighscore = true;
            }
        }

        if (GameManager.instance.level == GameManager.Level.Normal)
        {
            if (score > mediumHighScore)
            {
                mediumHighScore = score;
                PlayerPrefs.SetInt("mediumHighScorePref", mediumHighScore);
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("mediumHighScorePref");
                PlayerPrefs.Save();
                isHighscore = true;
            }
        }

        if (GameManager.instance.level == GameManager.Level.Hard)
        {
            if (score > hardHighScore)
            {
                hardHighScore = score;
                PlayerPrefs.SetInt("hardHighScorePref", hardHighScore);
                highScoreText.text = "Best\n" + PlayerPrefs.GetInt("hardHighScorePref");
                PlayerPrefs.Save();
                isHighscore = true;
            }
        }
    }
}