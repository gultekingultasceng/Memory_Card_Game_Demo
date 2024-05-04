using MCG.Core.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public class CameraSetups : MonoBehaviour
    {
        private Camera _camera;
        private Transform _cameraTransform;
        private const float INITIAL_ORTHOHRAPHIC_SIZE = 1.5f;

        private void Awake()
        {
            _camera = GetComponentInChildren<Camera>();
            _cameraTransform = this.transform;
        }
        private void SetCameraPosition()
        {
            float[] centerOfGrid = GridManager.Instance.GetWorldPositionCenterOfGrid;
            _cameraTransform.position = new Vector3(centerOfGrid[0], centerOfGrid[1] + .6f, 0f);
        }
        private void SetCameraOrthographicSize()
        {
            var rowCount = GameManager.Instance.GameSettings.GridRowCount;
            _camera.orthographicSize = INITIAL_ORTHOHRAPHIC_SIZE * (rowCount + 1);
        }
        public void Initialize()
        {
            SetCameraPosition();
            SetCameraOrthographicSize();
        }
    }
}