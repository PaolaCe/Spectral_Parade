using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaActiva : MonoBehaviour
{
    public Transform columna;
    private Vector3 columnaBaja = new Vector3 (-87.55f,-1.19f, -4.94f);
    private Vector3 columnaAlta;
    private float velocidad = 0.5f;
    private bool activado;

    private void Start()
    {
        columnaAlta = columna.transform.position;
    }


    private void Update()
    {
        if(activado == true)
        {
            columna.transform.position = Vector3.Lerp(columna.position, columnaBaja, velocidad * Time.deltaTime);
        }
        else
        {
            columna.transform.position = Vector3.Lerp(columna.position, columnaAlta, velocidad * Time.deltaTime);
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objeto")
        {
            activado = true;
        }

    }

     private void OnCollisionExit(Collision collision)
    {
        activado = false;
    }
}
