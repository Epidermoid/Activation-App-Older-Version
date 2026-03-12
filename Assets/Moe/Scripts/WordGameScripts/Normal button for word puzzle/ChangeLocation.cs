using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLocation : MonoBehaviour
{
    public void SetRectTransformLeftRight(float left, float right)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            Vector2 offsetMin = rectTransform.offsetMin;
            Vector2 offsetMax = rectTransform.offsetMax;
            offsetMin.x = left;    // left offset
            offsetMax.x = -right;   // right offset (should be negative for leftward move)
            rectTransform.offsetMin = offsetMin;
            rectTransform.offsetMax = offsetMax;
        }
    }

    [ContextMenu("Set RectTransform to 0, 0")]
    public void SetRectTransformZero()
    {
        SetRectTransformLeftRight(0, 0);
    }

    [ContextMenu("Set RectTransform to 1075, -1075")]
    public void SetRectTransformToGameValues()
    {
        SetRectTransformLeftRight(1075, -1075);
    }
}
