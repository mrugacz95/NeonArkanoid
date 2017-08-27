using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

    private Text levelNumber;
    public GameObject levelObject;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(startLevel);
        levelNumber = levelObject.GetComponent<Text>();
        levelNumber.text = ApplicationModel.getLevel().ToString();

    }
    void startLevel()
    {
        SceneManager.LoadScene(1);
    }
    void nextLevel()
    {
        ApplicationModel.nextLevel();
        levelNumber.text = ApplicationModel.getLevel().ToString();
    }
    void prevLevel()
    {
        ApplicationModel.prevLevel();
        levelNumber.text = ApplicationModel.getLevel().ToString();
    }
}
