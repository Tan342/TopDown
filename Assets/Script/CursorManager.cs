using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursor;
    Vector2 cursorSize; 
    // Start is called before the first frame update
    void Start()
    {
        cursorSize = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorSize, CursorMode.Auto);
    }

}
