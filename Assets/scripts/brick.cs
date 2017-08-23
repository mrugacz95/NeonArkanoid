using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    public GameObject score;
    public GameObject bonus;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        score.SendMessage("addPoints", 10);
        GameObject b = Instantiate(bonus);
        b.transform.position = this.transform.position;
        b.SendMessage("startMovement");
        Destroy(gameObject);
    }
}
