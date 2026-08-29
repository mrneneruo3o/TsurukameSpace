using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 200f;
    public float distance = 4f;

    float xRotation = 20f;
    float yRotation = 0f;

    void Update()
    {
        //ˆê“I‚ÉƒIƒt20260730
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //yRotation += mouseX;
        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -30f, 60f);

        //¢ŠE‚ÌŒü‚«
        //Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //©•ª‚ÌŒü‚«
        Quaternion rotation = target.rotation * Quaternion.Euler(xRotation, yRotation, 0);
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;
        transform.LookAt(target);
    }
}
