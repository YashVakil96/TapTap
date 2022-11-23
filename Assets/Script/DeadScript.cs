using UnityEngine;
using TMPro;

public class DeadScript : MonoBehaviour
{
    public TMP_Text scoreDead;
    public TMP_Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        Color alpha=highscoreText.color;
        alpha.a=1f;

        scoreDead.text=Colliders.scorePoints.ToString("0");
        if(ScoreManager.isHighscore)
        {
            highscoreText.color=alpha;
            ScoreManager.isHighscore=false;
        }
    }
}
