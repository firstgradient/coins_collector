using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraResolution : MonoBehaviour
{
    private float _targetaspect = 0;

    void Awake()
    {
        _targetaspect = 1920f / 1080f;
    }

    private void Update()
    {
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / _targetaspect;

        if (scaleheight < 1.0f)
        {
            Rect rect = GetComponent<Camera>().rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            GetComponent<Camera>().rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;
            Rect rect = GetComponent<Camera>().rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
            GetComponent<Camera>().rect = rect;
        }
    }
}
