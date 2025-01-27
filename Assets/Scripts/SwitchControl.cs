using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class SwitchControl : MonoBehaviour {
    public GameObject mainCharacter; // El personaje inicial que controlamos
    public GameObject secondaryCharacter; // El personaje al que cambiamos el control

    public string switchKey = "e";
    public string recargaKey = "r";
    public string disparoKey = "t";
    public string reparacionKey = "y";

    public float speed = 5f; // Velocidad de movimiento
    public float gravity = -9.81f; // Fuerza de gravedad
    public float velocityRotate = 140; // velocidad de giro

    private CharacterController activeController; // Controlador del personaje activo
    private Vector3 velocity;
    private bool isGrounded;
    private bool canSwitch = false;
    private bool canRecarga = false;
    private bool canDisparo = false;
    private bool canReparacion = false;

    void Start() {
        // Comenzamos controlando el personaje principal
        activeController = mainCharacter.GetComponent<CharacterController>();
    }

    void Update() {
        // Obtener la entrada del teclado
        float horizontal = Input.GetAxis("Horizontal"); // Flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // Flechas arriba/abajo

        // Calcular la direccion del movimiento
        Vector3 move = transform.forward * vertical;

        // Rotación pesonaje
        Vector3 rotation = new Vector3(0, horizontal * velocityRotate * Time.deltaTime, 0);
        this.transform.Rotate(rotation);

        // Mover al personaje
        activeController.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        activeController.Move(velocity * Time.deltaTime);

        // Cambiar el control si estamos en el trigger y pulsamos la tecla
        if (canSwitch && Input.GetKeyDown(switchKey)) {
            SwitchCharacter();
        }

        // Recarga
        if (canRecarga && Input.GetKeyDown(recargaKey)) {
            Debug.Log("Recarga");
        }

        // Disparar
        if (canDisparo && Input.GetKeyDown(disparoKey)) {
            Debug.Log("Disparo");
        }

        // Reparacion
        if (canReparacion && Input.GetKeyDown(reparacionKey)) {
            Debug.Log("Reparacion");
        }
    }

    // Cambiar el control entre personajes
    void SwitchCharacter() {
        if (activeController == mainCharacter.GetComponent<CharacterController>()) {
            activeController = secondaryCharacter.GetComponent<CharacterController>();
        } else {
            activeController = mainCharacter.GetComponent<CharacterController>();
        }
    }

    // Detectar si estamos dentro del trigger
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Conductor")) {
            canSwitch = true; // Podemos cambiar de personaje
        }

        if (other.gameObject.CompareTag("Recarga")) {
            canRecarga = true; // Podemos cambiar de personaje
        }

        if (other.gameObject.CompareTag("Artillero")) {
            canDisparo = true; // Podemos cambiar de personaje
        }

        if (other.gameObject.CompareTag("Mecanico")) {
            canReparacion = true; // Podemos cambiar de personaje
        }
    }

    // Detectar si salimos del trigger
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Conductor")) {
            canSwitch = false; // Ya no podemos cambiar de personaje
        }
    }

}
