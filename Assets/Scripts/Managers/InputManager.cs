using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private Camera mainCamera;
    private Transform _cameraParentTransform;
    [SerializeField]private Vector2 _mousePosition;

    public Vector2 MousePosition { get => _mousePosition;}
    private bool _isOnUI = false;
    public EventPublisher<Vector2Int> OnLeftMouseButtonClick;
    private Vector2Int _xEdge, _yEdge;
    
    public void Initialize()
    {
        OnLeftMouseButtonClick = new EventPublisher<Vector2Int>();
        _cameraParentTransform = mainCamera.transform.parent;
        SetCameraPositionToCenter();
        SetEdges();
    }
    public void SetCameraPositionToCenter()
    {
        float[] centerOfGrid = GridManager.Instance.GetWorldPositionCenterOfGrid;
        _cameraParentTransform.position = new Vector3(centerOfGrid[0], centerOfGrid[1], 0f);
    }
    public void SetEdges()
    {
        Vector2Int rowAndColumn = GridManager.Instance.RowAndColumn;
        _xEdge = new Vector2Int(0, rowAndColumn.x);
        _yEdge = new Vector2Int(0, rowAndColumn.y);
    }
    private void Update()
    {
        _mousePosition = VectorUtils.GetWorldPositionFromMousePosition(mainCamera);
        _isOnUI = EventSystem.current.IsPointerOverGameObject();
        if (IsClicked())
        {
            if (!IsMouseOverOnUI())
            {
                if (IsMouseInGridArea(VectorUtils.GetCoordinatesFromWorldPosition(_mousePosition)))
                {
                    OnLeftMouseButtonClick.Publish(VectorUtils.GetCoordinatesFromWorldPosition(_mousePosition));
                }
            }
        }
    }
    private bool IsClicked()
    {
        return Input.GetMouseButtonDown(0);
    }
    private bool IsMouseInGridArea(Vector2Int mouseCoordinates)
    {
        return  mouseCoordinates.x >= _xEdge.x &&
                mouseCoordinates.x <= _xEdge.y - 1 &&
                mouseCoordinates.y >= _yEdge.x &&
                mouseCoordinates.y <= _yEdge.y - 1;
    }
    private bool IsMouseOverOnUI()
    {
        return _isOnUI;
    }

 

}
