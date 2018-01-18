using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfo {

    private static int winner;

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
