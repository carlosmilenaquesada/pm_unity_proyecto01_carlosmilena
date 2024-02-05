using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private Vector3 inputPersonaje;
    private CharacterController characterController;
    private float velocidad = 10f;

    private Vector3 movePlayer;

    public Camera mainCamara;
    private Vector3 camForward;
    private Vector3 camRight;
    private float gravedad = -0.98f;

    private float horizontalAxis;
    private float verticalAxis;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        
        
        inputPersonaje = new Vector3(horizontalAxis, 0, verticalAxis);
        inputPersonaje = Vector3.ClampMagnitude(inputPersonaje, 1);


        movePlayer = inputPersonaje.x * camRight + inputPersonaje.z * camForward;
        characterController.transform.LookAt(characterController.transform.position + movePlayer);

        characterController.Move(Time.deltaTime * velocidad * (movePlayer + new Vector3(0, gravedad, 0)));



        direccionCamara();


    }



    void direccionCamara()
    {

        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
