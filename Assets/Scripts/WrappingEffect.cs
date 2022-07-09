using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingEffect : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Camera Cam = Camera.main;
        Vector3 ViewPort = Cam.WorldToViewportPoint(transform.position);
        Vector3 newPos = transform.position;

        if (ViewPort.x > 1 || ViewPort.x < 0)
        {
            newPos.x = -newPos.x;
        }

        if (ViewPort.y > 1 || ViewPort.y < 0)
        {
            newPos.y = -newPos.y;
        }

        transform.position = newPos;
    }
}
