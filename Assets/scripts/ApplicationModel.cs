using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationModel {

    static private int level = 4;
    static private int maxLevel = 10;
    static private int minLevel = 1;


    public static void prevLevel()
    {
        level -= 1;
        if (level < minLevel) level = maxLevel;
    }

    public static void nextLevel()
    {
        level += 1;
        if (level > maxLevel) level = minLevel;
    }

    public static int getLevel()
    {
        return level;
    }
    public static void restartLevel()
    {
        level = minLevel;
    }
}
