using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    
    public GameObject levelObject;
    private Text level;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        level = levelObject.GetComponent<Text>();
        btn.onClick.AddListener(startLevel);

    }
    void startLevel()
    {
        SceneManager.LoadScene(1);
    }
    void nextLevel()
    {
        ApplicationModel.nextLevel();
        level.text = ApplicationModel.getLevel().ToString();
    }
    void prevLevel()
    {
        ApplicationModel.prevLevel();
        level.text = ApplicationModel.getLevel().ToString();
    }
}
