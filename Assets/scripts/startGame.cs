using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(startLevel);
    }
	
	// Update is called once per frame
	void startLevel () {
        ApplicationModel.restartLevel();
        SceneManager.LoadScene(ApplicationModel.getLevel());
	}
}
