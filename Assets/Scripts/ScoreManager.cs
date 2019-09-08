using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int startingLevel = 0;

    public static int score;
    public static int lines;
    public static int level;
    int topScore;
    int startLevel;
    int previousLines;

    [SerializeField] Text scoreText;
    [SerializeField] Text linesText;
    [SerializeField] Text levelText;

    private void Start()
    {
        level = startingLevel;
    }
    private void Update()
    {
        scoreText.text = "top\n" + topScore.ToString("000000000") + "\n\nscore\n" + score.ToString("000000000");
        linesText.text = "lines - " + lines.ToString("000");
        levelText.text = "level\n " + level.ToString("00");

        if (score > topScore)
        {
            topScore = score;
        }
        if (lines - previousLines >= startLevel * 10 + 10 || lines - previousLines >= Mathf.Max(100,startLevel*10-50))
        {
            level++;
            previousLines = lines;
        }
    }
}
