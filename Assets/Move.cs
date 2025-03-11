using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }
}
