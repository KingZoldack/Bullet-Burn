using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] float _zoomedOut = 60f;
    [SerializeField] float _zoomedIn = 20f;
    [SerializeField] float _zoomedOutSens = 2f;
    [SerializeField] float _zoomedInSens = 0.5f;



    bool _isZoomed;

    RigidbodyFirstPersonController _fpsController;

    private void Awake()
    {
        _fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        ProcessFOV();
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    void ProcessFOV()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!_isZoomed)
            {
                ZoomIn();
            }

            else if (_isZoomed)
            {
                ZoomOut();
            }

        }
    }

    private void ZoomIn()
    {
        _isZoomed = true;
        _mainCamera.fieldOfView = _zoomedIn;
        _fpsController.mouseLook.XSensitivity = _zoomedInSens;
        _fpsController.mouseLook.YSensitivity = _zoomedInSens;
    }

    private void ZoomOut()
    {
        _isZoomed = false;
        _mainCamera.fieldOfView = _zoomedOut;
        _fpsController.mouseLook.XSensitivity = _zoomedOutSens;
        _fpsController.mouseLook.YSensitivity = _zoomedOutSens;
    }
}
