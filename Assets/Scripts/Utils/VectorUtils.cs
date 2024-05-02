using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static Vector2 GetWorldPositionFromMousePosition(Camera camera)
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }
    public static Vector2Int GetCoordinatesFromWorldPosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((worldPosition.x / GridConstants.DistanceBtwSlots)) , Mathf.FloorToInt((worldPosition.y / GridConstants.DistanceBtwSlots)));
    }
    public static Vector3 GetWorldPositionFromCoordinates(Vector2Int coordinates)
    {
        float distanceBtwSlots = GridConstants.DistanceBtwSlots;
        return new Vector3(coordinates.x * distanceBtwSlots , coordinates.y * distanceBtwSlots , 0);
    }
}
