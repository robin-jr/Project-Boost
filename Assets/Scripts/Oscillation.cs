using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    [SerializeField] float period=1f;
    [SerializeField] float range=20f;
    [SerializeField] Vector3 movementVector=Vector3.right;
    // Start is called before the first frame update
    Vector3 initialPosition;
    void Start()
    {
        initialPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float sin= Mathf.Sin((Time.timeSinceLevelLoad/period)*Mathf.PI);
        float oscilation = sin/2+0.5f;
        transform.position=initialPosition+movementVector*oscilation*range;
        
    }
}
