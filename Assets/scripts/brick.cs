using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
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
        if (hitsToDestroy == 0)
        {
            score.SendMessage("addPoints", getPoints());
            GameObject b = Instantiate(bonus);
            b.transform.position = this.transform.position;
            b.SendMessage("startMovement");
            Destroy(gameObject);
        }
        setSprite();
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
