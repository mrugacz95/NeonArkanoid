using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private static int livesNum = 3;
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
        livesNum--;
        printLives();
        if (livesNum <= 0)
            SceneManager.LoadScene(0);
    }
    private void printLives()
    {
        text.text = livesNum.ToString() + livesText;
    }
    public static int getLives()
    {
        return livesNum;
    }
}
