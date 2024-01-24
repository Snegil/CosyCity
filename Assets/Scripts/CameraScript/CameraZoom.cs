using System.Collections;
using System.Collections.Generic;
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

    public void ZoomCamera(InputAction.CallbackContext context)
    {
        pixelPerfect.assetsPPU += (int)context.ReadValue<Vector2>().y;
        pixelPerfect.assetsPPU = Mathf.Clamp(pixelPerfect.assetsPPU, minZoom, maxZoom);
    }
    public void ResetZoom(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            pixelPerfect.assetsPPU = 20;
        }        
    }
}
