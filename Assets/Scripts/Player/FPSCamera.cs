using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FPSカメラ=撮影モード時の視点移動を管理する
/// SetActive管理=CameraSystem
/// </summary>
public class FPSCamera : MonoBehaviour
{
    [Header("マウス感度")]
    public float mouseSensitivity = 200f;

    //カメラ角度を格納する変数
    float xRotation = 0f;
    float yRotation = 0f;

    void Update()
    {
        //FPSカメラがActiveじゃない=撮影モードじゃないので処理を抜ける
        if (!gameObject.activeSelf)
            return;

        //マウスの動きからマウスの移動量を計算
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

        //上下方向には制限をいれる
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //計算した角度をカメラに反映させる　Quaternion.Eulerはオイラー角で角度を作成するメソッド
        transform.localRotation =
            Quaternion.Euler(xRotation, yRotation, 0f);
    }

    public void SetRotation(Quaternion worldRotation)
    {
        //TPSの角度はワールド基準なので、親オブジェクト基準に変換する
        //親基準角度 = 親基準"逆"角度×ワールド基準角度
        Quaternion localRotation = Quaternion.Inverse(transform.parent.rotation) * worldRotation;

        //角度をEuler角に変換
        Vector3 euler = localRotation.eulerAngles;

        xRotation = euler.x;
        yRotation = euler.y;

        //FPScameraの変数に代入する
        // -180～180に変換　→　扱いやすいようにする
        if (xRotation > 180f)
            xRotation -= 360f;

        if (yRotation > 180f)
            yRotation -= 360f;

        //TPSが上下に制限をかけているので考慮する
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //カメラに反映
        transform.localRotation = Quaternion.Euler(
            xRotation,
            yRotation,
            0f
        );
    }
}
