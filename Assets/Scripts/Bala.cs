using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour

{
    public int daño = 1;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemigo1")) {
            Debug.Log("colision enemigo normal");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemigoTocho")){
            Debug.Log("colision enemigo Tocho");
            Destroy(gameObject);
        }
    }


}
