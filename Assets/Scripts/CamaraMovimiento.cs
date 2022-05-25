using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    [SerializeField]
    private Transform objAseguir;
    [SerializeField]
    private float velCamara = 120;
    [SerializeField]
    private float sensibilidad = 150;

    private float mouseX;
    private float mouseY;
    private float rotY=0;
    private float rotX =0;

    private void Start()
    {
        //Vector3 rot = transform.localRotation.eulerAngles;
        //rotY = rot.y;
        //rotX = rot.x;
    }

    private void Update()
    {
        //Quitar este transform si quiero que sea en 3ra persona y descomentarizar lo demas
        transform.position = Vector3.MoveTowards(transform.position, objAseguir.position, velCamara * Time.deltaTime);

        //mouseX = Input.GetAxis("Mouse X");
        //mouseY = Input.GetAxis("Mouse Y");

        //rotY += mouseX * sensibilidad * Time.deltaTime;
        //rotX -= mouseY * sensibilidad * Time.deltaTime;

        //rotX = Mathf.Clamp(rotX, -60, 60);
        //transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    private void LateUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, objAseguir.position, velCamara * Time.deltaTime);
    }
}
