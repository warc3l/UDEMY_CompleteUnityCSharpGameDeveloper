using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera fpsCamera;

    [SerializeField] private float zoomedOutFOV = 60f;

    [SerializeField] private float zommedInFOV = 20f;

    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    
    private bool someStateInToggle = false;

    private FirstPersonController fpsController;

    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !someStateInToggle)
        {
            // Not currently working using the new asset FirstPersonController. It would require some changes based on the comments in
            // 15027224#questions/19208222 from the lecture
            Debug.Log("Zooming in");
            fpsCamera.fieldOfView = zommedInFOV;
            someStateInToggle = true;
            if (fpsController != null)
            {
                fpsController.RotationSpeed = zoomInSensitivity;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            someStateInToggle = false;
            fpsCamera.fieldOfView = zoomedOutFOV;
            if (fpsController != null)
            {
                fpsController.RotationSpeed = zoomOutSensitivity;
            }
        }
    }
}
