using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksGenerator : MonoBehaviour
{
    public GameObject simpleBrick;

    private string[][] levels = {
    new string[] { "oooooooooooo",
                   "oooooooooooo",
                   "oooooooooooo"},
    new string[] { "oxoxoxoxoxox",
                   "xoxoxoxoxoxo",
                   "oxoxoxoxoxox"},
    new string[] { "xxxxoooooxxx",
                   "xxxoxxoxxoxx",
                   "xxxxoooooxxx"},
    new string[] { "oooooooooooo",
                   "xxxxxxxxxxxx",
                   "XXXXXXXXXXXX"},
    new string[] { "xxxxXxxXxxxx",
                   "xxxXxxxxXxxx",
                   "XoXooooooXoX"},
    new string[] { "ooxxxooxxxoo",
                   "XxooxooxooxX",
                   "XxXxxooxxXxX"},
    new string[] { "XXxxooooxxXX",
                   "ooXXxxxxXXoo",
                   "xxooXXXXooXX"},
    new string[] { "XxXoxxxxoXxX",
                   "xXoXxooxXoXx",
                   "XxXoxxxxoXxX"},
    new string[] { "XxxXxxXxxXxx",
                   "oXooXooXooXo",
                   "ooXooXooXooX",
                   "XooXooXooXoo"},
    new string[] { "XXXXXXXXXXXX",
                   "XXXXXXXXXXXX",
                   "XXXXXXXXXXXX",
                   "XXXXXXXXXXXX"},
    };

    private void generateLevel(int levelNumber)
    {
        string[] lvl = levels[levelNumber];
        BoxCollider2D collider = simpleBrick.GetComponent<BoxCollider2D>();
        float width = collider.size.x;
        float height = collider.size.y;
        for (int row = 0; row < lvl.Length; row++)
            for (int col = 0; col < lvl[row].Length; col++)
                switch (lvl[row][col])
                {
                    case 'o':
                        GameObject singleHitBrick = Instantiate(simpleBrick);
                        singleHitBrick.transform.position = new Vector2(transform.position.x + width/2+ width * col, transform.position.y + height * row);
                        singleHitBrick.SendMessage("setType", Brick.Type.SINGLE_HIT);
                        break;
                    case 'x':
                        GameObject doubleHitBrick = Instantiate(simpleBrick);
                        doubleHitBrick.transform.position = new Vector2(transform.position.x+ width / 2 + width * col, transform.position.y + height * row);
                        doubleHitBrick.SendMessage("setType", Brick.Type.DOUBLE_HIT);
                        break;
                    case 'X':
                        GameObject trippleHitBrick = Instantiate(simpleBrick);
                        trippleHitBrick.transform.position = new Vector2(transform.position.x + width / 2 + width * col, transform.position.y + height * row);
                        trippleHitBrick.SendMessage("setType", Brick.Type.TRIPPLE_HIT);
                        break;
                }
    }
    void Start()
    {
        generateLevel(ApplicationModel.getLevel() - 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
