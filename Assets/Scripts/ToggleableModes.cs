using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToggleableModes : MonoBehaviour
{
    public delegate void CurrentMode(bool mode);
    public event CurrentMode UserMode;

    bool mode;

    public void ToggleMode()
    {
        mode = !mode;
        UserMode?.Invoke(mode);
    }
}
