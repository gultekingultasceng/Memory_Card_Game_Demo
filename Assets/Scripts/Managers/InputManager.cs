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
    
    public void Initialize()
    {
        OnLeftMouseButtonClick = new EventPublisher<Vector2Int>();
        _cameraParentTransform = mainCamera.transform.parent;
        SetCameraPositionToCenter();
    }
    public void SetCameraPositionToCenter()
    {
        float[] centerOfGrid = GridManager.Instance.GetWorldPositionCenterOfGrid;
        _cameraParentTransform.position = new Vector3(centerOfGrid[0], centerOfGrid[1], 0f);
    }
    private void Update()
    {
        _mousePosition = VectorUtils.GetWorldPositionFromMousePosition(mainCamera);
        _isOnUI = EventSystem.current.IsPointerOverGameObject();
        if (Input.GetMouseButton(0))
        {
            if (isAvailableToShareInputData())
                OnLeftMouseButtonClick.Publish(VectorUtils.GetCoordinatesFromWorldPosition(_mousePosition));
        }
    }

    private bool isAvailableToShareInputData()
    {
        return !_isOnUI;
    }
 

}
