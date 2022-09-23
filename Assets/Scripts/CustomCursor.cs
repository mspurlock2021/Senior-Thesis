using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D investigateCursor;
    public Texture2D normalCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 InvestHotspot;
    public Vector2 NormHotspot;

    public void OnMouseInspectEnter()
    {
        Cursor.SetCursor(investigateCursor, InvestHotspot, cursorMode);
    }

    public void OnMouseInspectExit()
    {
        Cursor.SetCursor(normalCursor, NormHotspot, cursorMode);
    }
}
