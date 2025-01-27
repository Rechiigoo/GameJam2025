using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    
    public int vidaMaxima = 12;
    public int vidaTanque = 0;
    
    private int vida66;
    private int vida33 = 3;

    private bool fase1;
    private bool fase2;
    private bool fase3;
    private bool derrota;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaTanque = vidaMaxima;
        vida66 = (vidaTanque/3)*2;
        vida33 = vidaTanque/3;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaTanque >= vida66 ){
            fase1=true;
            fase2=false;
            fase3=false;
        };
        if(vidaTanque < vida66 && vidaTanque >= vida33){
            fase2=true;
            fase1=false;
            fase3=false;
        };
        if(vidaTanque < vida33 && vidaTanque > 0){
            fase3=true;
            fase1=false;
            fase2=false;
        };
        if(vidaTanque <= 0){
            fase1=false;
            fase2=false;
            fase3=false;
            derrota=true;
        };
    }
    public void quitaVidaTanque(int daño){
        vidaTanque = vidaTanque - daño;
    }
    public void regenerarVida(int vida){
        if(vidaMaxima >= vidaTanque + vida){
            vidaTanque = vidaTanque + vida;
        }else{
            vidaTanque = vidaMaxima;
        }
    }
}
