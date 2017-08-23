using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouns : MonoBehaviour
{

    public int speed = 50;

    void startMovement()
    {
        Rigidbody2D rgbody = GetComponent<Rigidbody2D>();
        rgbody.velocity = Vector2.down * speed;
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "racket")
        {
            trigger.gameObject.SendMessage("applyBonus");
            Destroy(gameObject);
        }
        else if (trigger.gameObject.name == "basement")
        {
            Destroy(gameObject);
        }
    }
}
