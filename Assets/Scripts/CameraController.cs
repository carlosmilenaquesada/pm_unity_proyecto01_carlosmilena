using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Este script maneja la cámara, la cual puede rotar alrededor del personaje usando el ratón
    private Vector3 offset = new Vector3(0, 3, -10);
    public Transform jugador;
    private float sensibilidada = 0.6f;

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidada, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensibilidada * (-1), Vector3.right) * offset;
        transform.position = Vector3.Lerp(transform.position, jugador.position + offset, 0.5f);
        transform.LookAt(jugador);
    }
}
