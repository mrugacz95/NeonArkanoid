using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricksGenerator : MonoBehaviour
{
    public GameObject simpleBrick;
    private string[] lvl1 = { "xxxxxxxxxxxxx",
                              "xxxxxxxxxxxxx",
                              "xxxxxxxxxxxxx"};
    private void renderLvl(string[] lvl)
    {
        BoxCollider2D collider = simpleBrick.GetComponent<BoxCollider2D>();
        float width = collider.size.x;
        float height = collider.size.y;
        for (int row = 0; row < lvl.Length; row++)
            for (int col = 0; col < lvl[row].Length; col++)
                switch (lvl[row][col])
                {
                    case 'x':
                        GameObject singleBrick = Instantiate(simpleBrick);
                        singleBrick.transform.position = new Vector2(transform.position.x + width * col, transform.position.y + height * row);
                        break;
                }
    }
    void Start()
    {
        renderLvl(lvl1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
