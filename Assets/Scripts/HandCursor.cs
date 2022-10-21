using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{
    public Texture2D handCursor;
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 handHotspot;
    public Vector2 NormHotspot;

    public void OnMouseInspectEnter()
    {
        Cursor.SetCursor(handCursor, handHotspot, cursorMode);
    }

    public void OnMouseInspectExit()
    {
        Cursor.SetCursor(normalCursor, NormHotspot, cursorMode);
    }
}
