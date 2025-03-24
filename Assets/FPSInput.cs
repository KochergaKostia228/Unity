using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 6.0F;
    [SerializeField] private float gravity = 9.8F;

    CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horisontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        //transform.Translate(horisontal * Time.deltaTime, 0, vertical * Time.deltaTime);
        
        Vector3 movement = new Vector3(horisontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = - gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
        
    }
}
