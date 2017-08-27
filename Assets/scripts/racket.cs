using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 150;
    public GameObject score;
    private int expanded = 0;
    private int speeded = 0;

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across X plane
            transform.Translate(touchDeltaPosition.x, 0, 0);
        }
        else
        {
            float h = Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
        }
    }
    public void applyBonus(Bonus.BonusType type)
    {
        switch (type)
        {
            default:
                score.SendMessage("addPoints", 50);
                break;
            case Bonus.BonusType.EXPAND:
                StartCoroutine(expand());
                break;
            case Bonus.BonusType.SPEED:
                StartCoroutine(speedup());
                break;
        }
    }
    IEnumerator speedup()
    {
        speeded++;
        speed = 400;
        yield return new WaitForSeconds(5);
        speeded--;
        if(speeded == 0)
            speed = 150;
    }
    IEnumerator expand()
    {
        expanded++;
        transform.localScale = new Vector3(1.5f, 1, 0);
        yield return new WaitForSeconds(5);
        expanded--;
        if (expanded == 0)
            transform.localScale = new Vector3(1, 1, 0);
    }
}
