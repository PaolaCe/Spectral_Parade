using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioG : MonoBehaviour
{
    public GameObject[] planetas;
    float velocidad = 3;
    float velRotacion = 100;
    public Rigidbody rbody;
    float fuerzaSalto = 10; //50000;


    void Update()
    {
        //Buscar el planeta mas cercano a Mario:
        float distanciaCercana = Vector3.Distance(transform.position, planetas[0].transform.position);
        int planetaCercano = 0;
        for (int i = 1; i < planetas.Length; i++)
        {
            float distAux = Vector3.Distance(transform.position, planetas[i].transform.position);
            if (distAux< distanciaCercana) { distanciaCercana = distAux; planetaCercano = i;  }

        }

        //Sentirse atraido por el planeta mas cercano 
        Physics.gravity = planetas[planetaCercano].transform.position - transform.position;

        //Rotar en funcion de ese planeta para tener los pies en direccion a su suelo:
        transform.rotation = Quaternion.FromToRotation(transform.up, - Physics.gravity)*transform.rotation;


        //Controles debug:
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Rotate (0,- velRotacion * Time.deltaTime,0); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Rotate(0, velRotacion * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.Space)) { rbody.AddForce(transform.up * fuerzaSalto); }
    }
}
