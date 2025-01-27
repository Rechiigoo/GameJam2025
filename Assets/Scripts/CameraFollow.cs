using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float tiempoAlgo = 0.3f;
    public Vector3 offest;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            Vector3 targetPosition = target.position + offest;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, tiempoAlgo);
        }
    }
}
