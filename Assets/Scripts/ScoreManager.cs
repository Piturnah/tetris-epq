using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int lines;
    public static int level;
    public static int topScore;
    public static int startLevel;
    int previousLines;

    [SerializeField] Text scoreText;
    [SerializeField] Text linesText;
    [SerializeField] Text levelText;

    private void Update()
    {
        //Write stats to the screen
        scoreText.text = "top\n" + topScore.ToString("000000000") + "\n\nscore\n" + score.ToString("000000000");
        linesText.text = "lines - " + lines.ToString("000");
        levelText.text = "level\n " + level.ToString("00");

        if (score > topScore)
        {
            topScore = score;
            GameManager.topScore = topScore;
        }
        //Check if levelled up for starting level
        if (lines - previousLines >= startLevel * 10 + 10 || lines - previousLines >= Mathf.Max(100,startLevel*10-50) && level == startLevel)
        {
            level++;
            previousLines = lines;
        }
        //Check if levelled up for all subsequent levels
        if (lines - previousLines >= 10 && level != startLevel)
        {
            level++;
            previousLines = lines;
        }
    }
}
