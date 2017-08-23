using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public int points = 0;
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
        this.points += points;
        printScore();
    }
    public void printScore()
    {
        text.text = pointsText + this.points.ToString();
    }
}
