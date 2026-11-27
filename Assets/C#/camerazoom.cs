using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera Cam;

    public float TargetZoom = 3;
    private float ScrollData;
    public float ZoomSpeed = 3;

    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize;
    }

    void Update()
    {
        // 0 when still, +ve when scrolling forward, -ve when scrolling backward
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        // Change the target zoom by however much we scroll
        TargetZoom = TargetZoom - ScrollData;

        // Limit zooming in and out
        TargetZoom = Mathf.Clamp(TargetZoom, 3, 10);

        // Smooth transition from the current size to the target size
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
