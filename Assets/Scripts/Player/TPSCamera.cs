using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TPSカメラ制御　プレイヤーを追従
/// SetActive管理 = CameraSystem
/// </summary>
public class TPSCamera : MonoBehaviour
{
    [Header("追従する対象")]
    public Transform target;
    [Header("カメラ距離")]
    public float distance = 4f;

    //カメラの回転角度　
    float xRotation = 20f;
    float yRotation = 0f;

    void Update()
    {
        //カメラの移動　プレイヤーの向き×カメラの回転角度
        Quaternion rotation = target.rotation * Quaternion.Euler(xRotation, yRotation, 0);

        //プレイヤーの後ろのdistance分離れた位置を計算する
        //プレイヤーの位置-回転角度*(0,0,1)*カメラ距離
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        //TPSカメラの位置を設定
        transform.position = position;

        //カメラを追従対象に向ける
        transform.LookAt(target);
    }
}
