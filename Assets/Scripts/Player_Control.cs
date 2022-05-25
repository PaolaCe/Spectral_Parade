using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private CharacterController controller;
    private GameObject camara;

    [Header("Estadisticas Normales")]
    [SerializeField] private float velocidad;
    [SerializeField] private float velCorriendo;
    [SerializeField] private float alturadeSalto;
    [SerializeField] private float tiempoalGirar;

    [Header("Datos sobre el piso")]
    [SerializeField] private Transform detectaPiso;
    [SerializeField] private float distanciaPiso;
    [SerializeField] private LayerMask mascaraPiso;

    float velocidadGiro;
    float gravedad = -9.81f;
    Vector3 velocity;
    bool tocaPiso;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");

    }

    private void Update()
    {
        tocaPiso = Physics.CheckSphere(detectaPiso.position, distanciaPiso, mascaraPiso);
        if(tocaPiso && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        if(Input.GetButtonDown("Jump")&& tocaPiso)
        {
            velocity.y = Mathf.Sqrt(alturadeSalto * -2 * gravedad);
        }

        velocity.y += gravedad * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if(direccion.magnitude >= 0.01f)
        {
            float objetivoAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y,objetivoAngulo, ref velocidadGiro, tiempoalGirar);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                controller.Move(mover.normalized * velCorriendo * Time.deltaTime);
            }
            else
            {
                Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                 controller.Move(mover.normalized * velocidad * Time.deltaTime);
            }
           
        }
   
       if (Input.anyKeyDown)
        {
            if (Input.GetKey(KeyCode.C)) //Pa hacerlo grandote
            {
                transform.localScale = Vector3.one * 3;
            }
           
        
            else if (Input.GetKey(KeyCode.V))
            {
                transform.localScale = Vector3.one * 0.2f;
            }
            else
            {
                transform.localScale = Vector3.one * 1;
            }
        }

        //if (Input.GetKey(KeyCode.C)) //Pa hacerlo grandote
        //{
        //    transform.localScale = Vector3.one * 3;
        //}
        //else
        //{
        //    transform.localScale = Vector3.one * 1;
        //}


        //if (Input.GetKey(KeyCode.V)) //Pa hacerlo chiquito
        //{
        //    transform.localScale = Vector3.one * 0.5f;
        //}
        //else
        //{
        //    transform.localScale = Vector3.one * 1;
        //}
    }
}
