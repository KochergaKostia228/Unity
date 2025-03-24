using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ReactiveTarget))]
public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0F;
    [SerializeField] private float obstacleRange = 5.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        ReactiveTarget obj = GetComponent<ReactiveTarget>();
        if(obj.IsUnityNull() || !obj.isAlive()) return;
        
        transform.Translate(0,0,speed*Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75F ,out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110.0F, 110.0F);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
