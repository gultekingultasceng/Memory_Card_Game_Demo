using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSettings : MonoBehaviour
{
    private int roundTime = 60; // a minute
    private int roundCount = 1;
    private int gridRowCount = 4,gridColumnCount = 4;

    
    public int RoundTime
    {
        set { roundTime = value; }
        get { return roundTime; }
    }
    public int RoundCount
    {
        set { roundCount = value; }
        get { return roundCount; }
    }
    public int GridRowCount
    {
        set { gridRowCount = value; }
        get { return gridRowCount; }
    }
    public int GridColumnCount
    {
        set { gridColumnCount = value; }
        get { return gridColumnCount; }
    }
}
