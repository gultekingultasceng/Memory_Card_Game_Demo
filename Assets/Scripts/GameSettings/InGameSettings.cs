using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.GameSettings
{
    public class InGameSettings : MonoBehaviour
    {
        public readonly int _minRoundTime = 1;
        public readonly int _maxRoundTime = 3;
        public readonly int _minRoundCount = 1;
        public readonly int _maxRoundCount = 3;
        public readonly List<Vector2Int> gridRowColumnOptions = new List<Vector2Int>()
    {
        new Vector2Int(4, 4),
        new Vector2Int(6, 6),
    };
        private int roundTime = 1; // a minute
        private int roundCount = 3;
        private int gridRowCount = 4, gridColumnCount = 4;


        public int RoundTime
        {
            get { return roundTime; }
        }
        public int RoundCount
        {
            get { return roundCount; }
        }
        public int GridRowCount
        {
            get { return gridRowCount; }
        }
        public int GridColumnCount
        {
            get { return gridColumnCount; }
        }
        public void SettingsApply(int roundTime, int roundCount, int gridOptionsIndex)
        {
            this.roundTime = roundTime;
            this.roundCount = roundCount;
            gridRowCount = gridRowColumnOptions[gridOptionsIndex].x;
            gridColumnCount = gridRowColumnOptions[gridOptionsIndex].y;
        }
    }
}