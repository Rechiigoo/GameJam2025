using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemigos;
    public float time;
    public float tiempoAleatorio;
    public int numeroEnemigos = 0;

    public ControladorMusica controladorMusica;

    // Start is called before the first frame update
    void Start() {
        tiempoAleatorio = Random.Range(1, 4);
        numeroEnemigos = 0;
        controladorMusica = FindObjectOfType<ControladorMusica>();
    }

    // Update is called once per frame
    void Update() {
        // Crear enemigo
        tiempoAleatorio -= Time.deltaTime;
        if (tiempoAleatorio <= 0) {
            CrearEnemigo();
            tiempoAleatorio = Random.Range(0, 10);
        }

        //llamamos al modulo de actualizar
        //this.ControladorMusica.actualizarEnemigos()
    }

    public void CrearEnemigo() {
        //Debug.Log("Nuevo enemigo");
        numeroEnemigos = numeroEnemigos + 1;

        if(numeroEnemigos<=6){
            Debug.Log("Suena batalla 1");

            if(controladorMusica.MusicaBatalla.activeSelf){
                //sigue sonando
            }else{
                controladorMusica.sonarMusica(4);
            }

        }else if(numeroEnemigos>=7){
            Debug.Log("Suena batalla 2");

            if(controladorMusica.MusicaBatalla2.activeSelf){
                //sigue sonando
            }else{
                controladorMusica.sonarMusica(5);
            }
        }

        Vector3 posicionEnemigo = transform.position;

        var enemigoGenerado = enemigos[Random.Range(0, enemigos.Length)];
        var nuevoEnem = Instantiate(enemigoGenerado, posicionEnemigo, Quaternion.identity);
        nuevoEnem.SetActive(true);
        //GameManager.instance.NuevoEnemigo();

    }
}
