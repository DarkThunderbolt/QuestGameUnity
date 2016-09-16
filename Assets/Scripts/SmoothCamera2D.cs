using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.15f;

    public bool verticalMaxEnabled = false;
    public float verticalMax = 0f;
    public bool verticalMinEnabled = false;
    public float verticalMin = 0f;

    public bool horizontalMaxEnabled = false;
    public float horizontalMax = 0f;
    public bool horizontalMinEnabled = false;
    public float horizontalMin = 0f;


    // Use this for initialization
    void Awake()
    {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    void Update()
    {
        if (target)
        {
            Vector3 targetPosition = target.position;

            if (verticalMinEnabled && verticalMaxEnabled)
            {
                targetPosition.y = Mathf.Clamp(target.position.y, verticalMin, verticalMax);
            }
            else if (verticalMinEnabled)
            {
                targetPosition.y = Mathf.Clamp(target.position.y, verticalMin, target.position.y);
            }
            else if (verticalMaxEnabled)
            {
                targetPosition.y = Mathf.Clamp(target.position.y, target.position.y, verticalMax);
            }

            if (horizontalMinEnabled && horizontalMaxEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, horizontalMax);
            }
            else if (horizontalMinEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, horizontalMin, target.position.x);
            }
            else if (horizontalMaxEnabled)
            {
                targetPosition.x = Mathf.Clamp(target.position.x, target.position.x, horizontalMax);
            }

            targetPosition.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}