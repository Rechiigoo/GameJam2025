using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour {

    public float speed;
    private Vector2 move;

    public Transform spawnPointl1; //punto de salida de la bala
    public Transform spawnPointl2; //punto de salida de la bala
    public Transform spawnPointb; //punto de salida de la bala
    public Transform respawn; //punto de salida de la bala
    public GameObject bullet; // bala

    private int balasL = 300;
    private int balasB = 300;
    public float shotForce;  //fuerza disparo
    public float shotRate = 0.5f;  // tiempo hasta proxino disparo 
    private float shotRateTime = 0;  //tiempo desde que se disparo

    private bool canSwitch = false;
    private bool canRecarga = false;
    private bool canDisparol1 = false;
    private bool canDisparol2 = false;
    private bool canDisparob = false;
    private bool canReparacion = false;

    // Update is called once per frame
    void Update() {
        //transform.Translate(movimiento.x * Time.deltaTime, movimiento.y * Time.deltaTime, 0);
        movePlayer();
    }

    public void EnMovimiento(InputAction.CallbackContext ctx) {
        move = ctx.ReadValue<Vector2>();
    }

    public void movePlayer() {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void recargaMuncion() {
        if (canRecarga) {
            balasL = 90000;
            balasB = 90000;
            Debug.Log("Recarga");
        }
    }

    public void reparacion() {
        if (canReparacion) {
            Debug.Log("Reparacion");
        }
    }

    public void disparol1() {
        if (canDisparol1  && balasL > 0) {

            if (Time.time > shotRateTime) {
                GameObject newBullet = Instantiate(bullet, spawnPointl1.position, spawnPointl1.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPointl1.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }

            balasL--;
            Debug.Log("Disparol1 " + balasL);
            Debug.Log("Puede disparar? " + canDisparol1);
        }
    }

    public void disparol2() {
        if (canDisparol2 && balasL > 0) {

            if (Time.time > shotRateTime) {
                GameObject newBullet = Instantiate(bullet, spawnPointl2.position, spawnPointl2.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPointl2.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }

            balasL--;
            Debug.Log("Disparol2 " + balasL);
        }
    }

    public void disparob() {
        if (canDisparob && balasB > 0) {

            if (Time.time > shotRateTime) {
                GameObject newBullet = Instantiate(bullet, spawnPointb.position, spawnPointb.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPointb.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }

            balasB--;
            Debug.Log("Disparob " + balasB);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Reespawn")) {
            gameObject.transform.position = respawn.position;
        }
    }

        // Detectar si estamos dentro del trigger
        private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Conductor")) {
            canSwitch = true;
        }

        if (other.gameObject.CompareTag("Recarga")) {
            canRecarga = true;
        }

        if (other.gameObject.CompareTag("Artillerol1")) {
            canDisparol1 = true;
        }

        if (other.gameObject.CompareTag("Artillerol2")) {
            canDisparol2 = true;
        }
        
        if (other.gameObject.CompareTag("Artillerob")) {
            canDisparob = true;
        }

        if (other.gameObject.CompareTag("Mecanico")) {
            canReparacion = true;
        }
    }

    // Detectar si salimos del trigger
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Recarga")) {
            canSwitch = false;

            if (other.gameObject.CompareTag("Recarga")) {
                canRecarga = false;
            }

            if (other.gameObject.CompareTag("Artillerol1")) {
                canDisparol1 = false;
            }
            
            if (other.gameObject.CompareTag("Artillerol2")) {
                canDisparol2 = false;
            }
            
            if (other.gameObject.CompareTag("Artillerob")) {
                canDisparob = false;
            }

            if (other.gameObject.CompareTag("Mecanico")) {
                canReparacion = false;
            }
        }
    }
}
