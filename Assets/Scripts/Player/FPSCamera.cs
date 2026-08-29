using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FPSカメラ=撮影モード時の視点移動を管理する
/// SetActive管理=CameraSystem
/// </summary>
public class FPSCamera : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Update()
    {
        //テスト
        Debug.Log("FPSCamera Update");

        if (!gameObject.activeSelf)
            return;

        float mouseX =
            Input.GetAxis("Mouse X")
            * mouseSensitivity
            * Time.deltaTime;

        float mouseY =
            Input.GetAxis("Mouse Y")
            * mouseSensitivity
            * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation =
            Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
