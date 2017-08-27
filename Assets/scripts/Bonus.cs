using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    public int speed = 50;
    public enum BonusType { POINTS, EXPAND, SPEED }
    public Sprite speedBouns;
    public Sprite pointsBouns;
    public Sprite expandBouns;
    private BonusType type;
    void startMovement()
    {
        Rigidbody2D rgbody = GetComponent<Rigidbody2D>();
        rgbody.velocity = Vector2.down * speed;
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "racket")
        {
            trigger.gameObject.SendMessage("applyBonus", type);
            Destroy(gameObject);
        }
        else if (trigger.gameObject.name == "basement")
        {
            Destroy(gameObject);
        }
    }
    void setType(BonusType type)
    {
        this.type = type;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        switch (type)
        {
            default:
                spriteRenderer.sprite = pointsBouns;
                break;
            case BonusType.SPEED:
                spriteRenderer.sprite = speedBouns;
                break;
            case BonusType.EXPAND:
                spriteRenderer.sprite = expandBouns;
                break;

        }
    }
}
