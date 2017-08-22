using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public int points = 0;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }
    public void addPoints(int points)
    {
        this.points += points;
        text.text = this.points.ToString();
    }
}
