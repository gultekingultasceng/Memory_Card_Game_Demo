using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    private int rowCount;
    private int columnCount;
    public Vector2Int RowAndColumn => new Vector2Int(rowCount, columnCount);
    [SerializeField] private GameObject SlotPrefab;
    public float[] GetWorldPositionCenterOfGrid => new float[2] {
        ((Mathf.CeilToInt((rowCount) * .5f) * GridConstants.DistanceBtwSlots) - GridConstants.DistanceBtwSlots * .5f) + 1,
        ((Mathf.CeilToInt((columnCount) * .5f) * GridConstants.DistanceBtwSlots) - GridConstants.DistanceBtwSlots * .5f) + 1,
    };
    public List<SlotInfo> slotInfos = new List<SlotInfo>();
    private void GenerateGrid()
    {
        for (int i = 0; i < rowCount; i++)
        {
            for(int j = 0; j < columnCount; j++)
            {
                GameObject slotObj = Instantiate(SlotPrefab,this.transform);
                float distanceBtwSlots = GridConstants.DistanceBtwSlots;
                slotObj.transform.localPosition = new Vector3(i* distanceBtwSlots, j* distanceBtwSlots, 0);
            }
        }
    }
    public void Initialize(int rowCount, int columnCount)
    {
        this.rowCount = rowCount;
        this.columnCount = columnCount;
        GenerateGrid();
    }
    [System.Serializable]
    public class SlotInfo
    {
        public Vector2Int slotCoordinate;
        public CardScript holdedCard;
    }
}


