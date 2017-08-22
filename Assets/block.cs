using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    public GameObject score;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        score.SendMessage("addPoints", 10);
        Destroy(gameObject);
    }
}
