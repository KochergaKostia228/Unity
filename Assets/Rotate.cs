using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float Speed_X = 0.0F;

    [SerializeField]
    private float Speed_Y = 3.0F;

    [SerializeField]
    private float Speed_Z = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Speed_X, Speed_Y, Speed_Z);
    }
}
