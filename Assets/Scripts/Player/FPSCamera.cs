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
        //Debug.Log("FPSCamera Update");

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

    public void SetRotation(Quaternion worldRotation)
    {
        Quaternion localRotation = Quaternion.Inverse(transform.parent.rotation) * worldRotation;

        //角度をEuler角に変換
        Vector3 euler = localRotation.eulerAngles;

        xRotation = euler.x;
        yRotation = euler.y;

        //FPScameraの変数に代入する
        // -180～180に変換
        if (xRotation > 180f)
            xRotation -= 360f;

        if (yRotation > 180f)
            yRotation -= 360f;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(
            xRotation,
            yRotation,
            0f
        );
    }
}
