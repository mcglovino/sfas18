using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfo {

    private static int winner;

    private static int level;

    private static int quality;

    private static bool practice;

    private static Material mat1;
    private static Material mat2;

    public static int Win
    {
        get
        {
            return winner;
        }
        set
        {
            winner = value;
        }
    }

    public static int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public static int Quality
    {
        get
        {
            return quality;
        }
        set
        {
            quality = value;
        }
    }

    public static bool Practice
    {
        get
        {
            return practice;
        }
        set
        {
            practice = value;
        }
    }

    public static Material Material_P1
    {
        get
        {
            return mat1;
        }
        set
        {
            mat1 = value;
        }
    }

    public static Material Material_P2
    {
        get
        {
            return mat2;
        }
        set
        {
            mat2 = value;
        }
    }
}
