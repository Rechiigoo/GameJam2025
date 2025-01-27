using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roles : MonoBehaviour
{

    public GameObject mainCharacter; // El personaje inicial que controlamos
    public GameObject secondaryCharacter; // El personaje al que cambiamos el control
    private CharacterController activeController; // Controlador del personaje activo

    public string switchKey = "e";
    private bool canSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cambiar el control si estamos en el trigger y pulsamos la tecla
        if (canSwitch && Input.GetKeyDown(switchKey)) {
            SwitchCharacter();
        }
    }

    // Cambiar el control entre personajes
    void SwitchCharacter() {
        if (activeController == mainCharacter.GetComponent<CharacterController>()) {
            activeController = secondaryCharacter.GetComponent<CharacterController>();
            Debug.Log("a");
        } else {
            activeController = mainCharacter.GetComponent<CharacterController>();
            Debug.Log("b");
        }
    }

    // Detectar si estamos dentro del trigger
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Conductor")) {
            canSwitch = true; // Podemos cambiar de personaje
            Debug.Log("Cambiioooo");
        }
    }

    // Detectar si salimos del trigger
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Conductor")) {
            canSwitch = false; // Ya no podemos cambiar de personaje
        }
    }
}
