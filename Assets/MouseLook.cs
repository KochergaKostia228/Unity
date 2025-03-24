using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY, 
        MouseX, 
        MouseY
    }
    
    [SerializeField] RotationAxes rotationAxes = RotationAxes.MouseXAndY;

    [SerializeField] private float sensitivityHor = 9.0F;
    [SerializeField] private float sensitivityVer = 9.0F;
    [SerializeField] private float minVertAngle = -45.0F;
    [SerializeField] private float maxVertAngle = 45.0F;

    private float _rotationX = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationAxes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (rotationAxes == RotationAxes.MouseY)
        {
            _rotationX += Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);

            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0.0F);
        }
        else
        {
            _rotationX += Input.GetAxis("Mouse Y") * sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0.0F);
        }
        
    }
}
