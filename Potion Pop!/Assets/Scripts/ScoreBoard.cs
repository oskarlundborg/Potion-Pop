using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text levelScoreText;
    [SerializeField] private LevelState levelState;


    private void Update()
    {
        ShowScoreBoard();
    }

    public void ShowScoreBoard() {
        highScoreText.text = "High Score: " + levelState.GetLevelHighScore();
        levelScoreText.text = "Level Score: " + levelState.GetLevelScore();
    }
}
