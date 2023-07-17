using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Transform mCursorVisual;
    public Vector3 mDisplacement;
    void Start()
    { 
        Cursor.visible = false;
    }

    
}
