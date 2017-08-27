using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	void Start () {
		if (Score.getScore() > 0)
        {
            Text text = GetComponent<Text>();
            text.text = "GameOver\nScore: " + Score.getScore();
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
}
