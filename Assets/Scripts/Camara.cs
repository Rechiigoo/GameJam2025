using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    public Transform tanque;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 0, 0);
        this.transform.Rotate(rotation);

        Vector3 posicion = tanque.transform.position;
        transform.localPosition = new Vector3(posicion[0], 0, posicion[2]);
        //transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
   
               
    }
}