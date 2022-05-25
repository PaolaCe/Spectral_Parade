using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int numeroEscena;
    public GameObject fondoOpciones;

    public void cambiarEscena()
    {
        SceneManager.LoadScene(numeroEscena);
    }

    public void opciones()
    {
        fondoOpciones.SetActive(true);
    }

    public void volver()
    {
        fondoOpciones.SetActive(false);
    }

   public void Salir()
    {
        Application.Quit();
        Debug.Log("Si estamos saliendo del jueguin");
    }
}
