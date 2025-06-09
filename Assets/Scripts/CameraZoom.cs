using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoomSpeed = 5f;
    private float zoomAmount = 0.5f;
    public float minSize = 1f;
    private float maxSize = 20f;
    private float currentOrthographicSize;
    private float targetOrthographicSize;

    // Start is called before the first frame update
    void Start()
    {
        // CameraZoom: Get the initial orthographic size
        currentOrthographicSize = GetComponent<Camera>().orthographicSize;
        targetOrthographicSize = currentOrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();
    }
    void HandleZoom()
    {
        targetOrthographicSize -= Input.mouseScrollDelta.y * zoomAmount;

        // Clamp the target size to be within the allowed range
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minSize, maxSize);

        // Lerp to the target size for smooth zooming
        currentOrthographicSize = Mathf.Lerp(currentOrthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);
        GetComponent<Camera>().orthographicSize = currentOrthographicSize;
    }
}
