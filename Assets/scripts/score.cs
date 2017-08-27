using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private static int playerScore = 0;

    internal static int getScore()
    {
        return playerScore;
    }

    private string pointsText;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        pointsText = text.text;
        printScore();
    }
    public void addPoints(int points)
    {
        playerScore += points;
        printScore();
    }
    public void printScore()
    {
        text.text = pointsText + playerScore.ToString();
    }
}
