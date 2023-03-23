using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowMouse : MonoBehaviour
{
    // Update position of tooltip based on mousePosition
    void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
