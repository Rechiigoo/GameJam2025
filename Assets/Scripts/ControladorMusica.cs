using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMusica : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MusicaMenu;

    public GameObject MusicaWIN;
    public GameObject MusicaLoose;
    public GameObject MusicaBatalla;
    public GameObject MusicaBatalla2;

    void Start()
    {
        //detenerTodosLosSonidos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void detenerTodosLosSonidos(){

            MusicaMenu.gameObject.SetActive(false);
            MusicaWIN.gameObject.SetActive(false);
            MusicaLoose.gameObject.SetActive(false);

            MusicaBatalla.gameObject.SetActive(false);
            MusicaBatalla2.gameObject.SetActive(false);
            //musicaBatalla1.setActive(false);
            //musicaBatalla2.setActive(false);
            Debug.Log("Musica desactivada!");

    }

    public void sonarMusica(int identificadorMusica){
        //paramos todos los sonidos
        detenerTodosLosSonidos();

        //Debug.Log("suena una musica..");
        switch(identificadorMusica){
            //musica del menu
            case 1:
                MusicaMenu.SetActive(true);
            break;

            //musica de win
            case 2:
                MusicaWIN.SetActive(true);
            break;

            //musica de loose
            case 3:
                MusicaLoose.SetActive(true);
            break;

            //musica de batalla 1
            case 4:
                MusicaBatalla.SetActive(true);

            break;

            case 5:
                MusicaBatalla2.SetActive(true);

            break;
        }

    }

    //public void controladorMusicaBatalla();
}
