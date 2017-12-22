using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfo {

    private static int Winner;

	public static int Win
    {
        get
        {
            return Winner;
        }
        set
        {
            Winner = value;
        }
    }
}
