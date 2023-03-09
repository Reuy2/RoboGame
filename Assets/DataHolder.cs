using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder : object
{
    private static float dificulty = 1f;
    private static float sound = 1f;

    public static float Sound 
    { 
        get {return sound; } 
        set {sound = value; } 
    }

    public static float Dificulty
    {
        get { return dificulty; }
        set { dificulty = value; }
    }

}
