using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.PixelPerfectCamera pixelPerfect;

    [Space, SerializeField]
    int minZoom;
    [SerializeField]
    int maxZoom;
    [SerializeField]
    int zoomSpeed;

    [SerializeField]
    bool zoomBool = false;
    [SerializeField]
    float speedToZoom;
    float setSpeedToZoom;

    void Start()
    {
        setSpeedToZoom = speedToZoom;
    }
    void Update()
    {
        if (speedToZoom >= 0)
        {
            speedToZoom -= Time.deltaTime;
        }        
        if (zoomBool && speedToZoom <= 0)
        {
            pixelPerfect.assetsPPU += zoomSpeed;
            pixelPerfect.assetsPPU = Mathf.Clamp(pixelPerfect.assetsPPU, minZoom, maxZoom);
            speedToZoom = setSpeedToZoom;
        }
    }
    public void ZoomCamera(InputAction.CallbackContext context)
    {
        zoomSpeed = (int)context.ReadValue<Vector2>().y;
        if (context.phase == InputActionPhase.Started)
        {
            zoomBool = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        { 
            zoomBool = false;
        }
        //pixelPerfect.assetsPPU += (int)context.ReadValue<Vector2>().y;
        //pixelPerfect.assetsPPU = Mathf.Clamp(pixelPerfect.assetsPPU, minZoom, maxZoom);
    }
    public void ResetZoom(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            pixelPerfect.assetsPPU = 20;
        }        
    }
}
