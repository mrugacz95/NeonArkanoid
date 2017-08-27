using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public enum Type {SINGLE_HIT, DOUBLE_HIT, TRIPPLE_HIT};
    public Sprite singleHitSprite;
    public Sprite doubleHitSprite;
    public Sprite trippleHitSprite;
    public GameObject score;
    public GameObject bonus;

    private Type type;
    private SpriteRenderer spriteRenderer;
    private int hitsToDestroy = 1;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        hitsToDestroy--;
        setSprite();
        if (hitsToDestroy == 0)
        {
            score.SendMessage("addPoints", getPoints());
            spawnBonus();
            Destroy(gameObject);
        }
    }

    private void spawnBonus()
    {
        if (UnityEngine.Random.value < 0.3) {
            Array values = Enum.GetValues(typeof(Bonus.BonusType));
            System.Random random = new System.Random();
            Bonus.BonusType randomType = (Bonus.BonusType)values.GetValue(random.Next(values.Length));
            GameObject powerup = Instantiate(bonus);
            powerup.transform.position = this.transform.position;
            powerup.SendMessage("setType", randomType);
            powerup.SendMessage("startMovement");
        }
    }

    public void setType(Type type) {
        this.type = type;
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (type)
        {
            default:
                spriteRenderer.sprite = singleHitSprite;
                hitsToDestroy = 1;
                break;
            case Type.DOUBLE_HIT:
                hitsToDestroy = 2;
                break;
            case Type.TRIPPLE_HIT:
                hitsToDestroy = 3;
                break;
        }
        setSprite();
    }
    public void setSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (hitsToDestroy)
        {
            default:
                spriteRenderer.sprite = singleHitSprite;
                break;
            case 2:
                spriteRenderer.sprite = doubleHitSprite;
                break;
            case 3:
                spriteRenderer.sprite = trippleHitSprite;
                break;
        }
    }
    private int getPoints()
    {
        switch (type)
        {
            default:
                return 10;
            case Type.DOUBLE_HIT:
                return 20;
            case Type.TRIPPLE_HIT:
                return 50;
        }
    }
}
