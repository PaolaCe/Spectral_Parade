using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour
{
    public GameObject objPuntos;
    public int puntosQueDa;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objPuntos.GetComponent<Puntos>().puntos += puntosQueDa;
            Destroy(gameObject);
        }
    }
}
