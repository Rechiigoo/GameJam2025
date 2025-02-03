using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 15f; // Velocidad de movimiento
    public float gravity = -9.81f; // Fuerza de gravedad
    public float velocityRotate = 140; // velocidad de giro
    
    private CharacterController controller;
    private Vector3 velocity;

    public bool atropello;
    public float verticalAnterior;


    void Start() {
        // Obtener el componente CharacterController
        controller = GetComponent<CharacterController>();
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
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //Debug.Log("Gola");

        if(vertical == verticalAnterior){
            vertical= verticalAnterior;
            atropello = false;
            //Debug.Log("no atropello");
        }else{
            vertical= verticalAnterior;
            //Debug.Log("movimiento");
            atropello = true;
        }
    }
}