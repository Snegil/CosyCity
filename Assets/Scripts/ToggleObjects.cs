using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public void ToggleObject(GameObject gObject)
    {
        gObject.SetActive(!gObject.activeSelf);
    }
}
