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
        _fpsController = GetComponent<RigidbodyFirstPersonController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFOV();
    }

    void ProcessFOV()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!_isZoomed)
            {
                _isZoomed = true;
                _mainCamera.fieldOfView = _zoomedIn;
                _fpsController.mouseLook.XSensitivity = _zoomedInSens;
                _fpsController.mouseLook.YSensitivity = _zoomedInSens;
            }

            else if (_isZoomed)
            {
                _isZoomed = false;
                _mainCamera.fieldOfView = _zoomedOut;
                _fpsController.mouseLook.XSensitivity = _zoomedOutSens;
                _fpsController.mouseLook.YSensitivity = _zoomedOutSens;
            }

        }
    }
}
