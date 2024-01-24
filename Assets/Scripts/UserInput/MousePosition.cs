using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition : MonoBehaviour
{
    [Header("Player Locations")]
    [Space, SerializeField]
    Vector3 screenPosition;
    [SerializeField]
    Vector3 worldPosition;

    void Update()
    {
        screenPosition = Mouse.current.position.ReadValue();
        screenPosition.z = Camera.main.nearClipPlane + 1;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0;
    }
    public Vector3 WorldPos
    {
        get { return worldPosition; }
    }
}
