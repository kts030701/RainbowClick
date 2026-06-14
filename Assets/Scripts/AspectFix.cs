using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectFix : MonoBehaviour
{
    public float targetAspect = 16f / 9f;

    Camera cam;
    int lastWidth;
    int lastHeight;

    void Start()
    {
        cam = GetComponent<Camera>();
        Apply();
    }

    void Update()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            Apply();
        }
    }

    void Apply()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Rect rect = cam.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        cam.rect = rect;

        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }
}