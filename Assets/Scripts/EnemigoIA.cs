using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigosIA : MonoBehaviour {

    
    public Transform player;
    public NavMeshAgent agent;
    public int vidaEnemigoNormal = 2;
    public int dañoEnemigoNormal = 1;
    public int vidaEnemigoTocho = 10;

    private Vida vida;
    private Bala bala;
    private PlayerMovement atropello;
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        vida = FindObjectOfType<Vida>();
    }

    // Update is called once per frame
    void Update() {
        agent.SetDestination(player.position);
        //agent.destination = player.position;
        atropello = FindObjectOfType<PlayerMovement>();
        
    }

    private void OnCollisionEnter(Collision collision) {
        /*if (collision.gameObject.CompareTag("atropello")) {
            Debug.Log("atropello");
           //atropello = FindObjectOfType<PlayerMovement>();
            if(atropello.atropello){
                Destroy(gameObject);
                Debug.Log("Enemigo eliminado");
            }
        }else{
            Debug.Log("XD");
        }
        
        if (collision.gameObject.CompareTag("Barco")) {
            /*vida = FindObjectOfType<Vida>();
            vida.vidaTanque -= 1;*/
            /*if(gameObject.CompareTag("EnemigoTocho")){
                vida.quitaVidaTanque(3);
            }else {
                vida.quitaVidaTanque(dañoEnemigoNormal);
            }
            Destroy(gameObject);
            Debug.Log(vida.vidaTanque);
        }*/
        
        
        if(collision.gameObject.CompareTag("Barco") && atropello.atropello == false){
            //Debug.Log("HOLA");
            //Si es un bicho tocho HACER IF AQUI
            if(gameObject.CompareTag("EnemigoTocho")){
                vida.quitaVidaTanque(3);
                Debug.Log("tocho");
            }else {
                vida.quitaVidaTanque(dañoEnemigoNormal);
                Debug.Log("normal");
            }
                
            Destroy(gameObject);
                        
            Debug.Log(vida.vidaTanque);
            Debug.Log("Se resta vida");

            
        }else if(collision.gameObject.CompareTag("Barco") && atropello.atropello == true){
            //Debug.Log("ADIOS");
            //Si es tocho se hace esto
            if(gameObject.CompareTag("EnemigoTocho")){
                vida.quitaVidaTanque(3);
                Debug.Log("tocho atropello");
            }else{
                Debug.Log("normal atropellado");
            }
                Destroy(gameObject);
                Debug.Log("Enemigo eliminado");
        }



        if (collision.gameObject.CompareTag("Bala")) {
            Debug.Log("disparo");
            bala = FindObjectOfType<Bala>();
            vidaEnemigoNormal = vidaEnemigoNormal - bala.daño;
            if(vidaEnemigoNormal <= 0){
                Destroy(gameObject);
                Debug.Log("Enemigo eliminado por bala");
            }
        }
    }
}
