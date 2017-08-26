using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(exitGame);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            exitGame();


    }
    void exitGame()
    {
        Application.Quit();
    }
}