using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    [SerializeField] GUIStyle style =  new GUIStyle();
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2.0F, _camera.pixelHeight / 2.0F , 0.0F);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.transform.name);
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget reactiveTarget = hitObject.GetComponent<ReactiveTarget>();

                if (reactiveTarget != null)
                {
                    reactiveTarget.ReactToHit(20);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point, 0.2F));
                }
            }
        }
        
    }

    private IEnumerator SphereIndicator(Vector3 position, float radius)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        sphere.transform.localScale = new Vector3(radius, radius, radius);
        
        yield return new WaitForSeconds(0.2F);
        Destroy(sphere);
    }

    private void OnGUI()
    {
        int size = 20;
        float posX = Screen.width * 0.5F - size * 0.5F;
        float posY = Screen.height * 0.5F - size * 0.5F;
        GUI.Label(new Rect(posX,posY,size,size),"+", style);
    }
}
