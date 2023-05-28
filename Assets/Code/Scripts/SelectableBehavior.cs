using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBehavior : MonoBehaviour
{
    public Texture2D cursorTexture;
    public static CursorMode cursorMode = CursorMode.Auto;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
