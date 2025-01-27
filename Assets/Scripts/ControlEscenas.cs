using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour {
    public void OnJugar() {
        Debug.Log("jugar");
        SceneManager.LoadScene("");
    }

    public void OnCreditos() {
        Debug.Log("creditos");
        SceneManager.LoadScene("05CreditsScene");
    }

    public void OnVictoria() {
        Debug.Log("victoria");
        SceneManager.LoadScene("04VictoryScene");
    }
    
    public void OnDerrota() {
        Debug.Log("derrota");
        SceneManager.LoadScene("03DerrotaScene");
    }

    public void OnSalir() {
        Application.Quit();
    }

    public void OnMenu() {
        Debug.Log("menu");
        SceneManager.LoadScene("01InicioScene");
    }
}

