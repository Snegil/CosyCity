using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    void Update()
    {
        if (zoomBool)
        {
            pixelPerfect.assetsPPU += zoomSpeed;
            pixelPerfect.assetsPPU = Mathf.Clamp(pixelPerfect.assetsPPU, minZoom, maxZoom);
        }
    }
    public void ZoomCamera(InputAction.CallbackContext context)
    {
        Debug.Log("BUTTON PRESSED");
        zoomSpeed = (int)context.ReadValue<Vector2>().y;
        Debug.Log(zoomSpeed);
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("TROO");
            zoomBool = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        { 
            zoomBool = false;
            Debug.Log("NOT TROO");
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
