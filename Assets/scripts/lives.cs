using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public int livesNum = 3;
    private string livesText;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        livesText = text.text;
        printLives();
    }
    public void takeLive()
    {
        this.livesNum--;
        printLives();
    }
    private void printLives()
    {
        text.text = livesText + this.livesNum.ToString();
    }
}
