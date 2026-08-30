using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 120f;
    public CameraSystem cameraSystem;

    void Update()
    {
        if (cameraSystem.IsFPSMode())return;

        //float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float y = 0;

        // 自身のtranformを取得
        Transform myTransform = this.transform;

        //Aキーで左回転
        if (Input.GetKey(KeyCode.A))
        {
            myTransform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        //Dキーで右回転
        if (Input.GetKey(KeyCode.D))
        {
            myTransform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        //SpaceキーでUp
        if (Input.GetKey(KeyCode.Space))
        {
            y = 1;
        }

        //コントロールキーでDown
        if (Input.GetKey(KeyCode.LeftControl) ||
            Input.GetKey(KeyCode.RightControl))
        {
            y = -1;
        }

        Vector3 move = new Vector3(0, y, v);
        transform.Translate(move * speed * Time.deltaTime, Space.Self);

        //テスト
        //Debug.Log(transform.rotation.eulerAngles.y);
    }
}
