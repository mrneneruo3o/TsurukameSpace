using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// カメラをTPSからFPSへ切り替える
/// </summary>
public class CameraSystem : MonoBehaviour
{
    public TPSCamera tpsCamera;
    public FPSCamera fpsCamera;
    public GameObject cameraUI;
    public TMP_Text photoresultText;
    public EncyclopediaManager encyclopediaManager;
    public AudioSource audioSource;
    public AudioClip shutterSE;
    private bool fpsCameraOn;
    
    public PhotoScoreSystem photoScoreSystem;

    void Start()
    {
        //テスト
        Debug.Log("CameraSystem Start");
        //Debug.Log(gameObject.GetInstanceID());
        //Debug.Log(fpsCamera.activeSelf);

        tpsCamera.gameObject.SetActive(true);
        fpsCamera.gameObject.SetActive(false);
        cameraUI.SetActive(false);
        photoresultText.gameObject.SetActive(false);
        fpsCameraOn = false;
        Debug.Log("TPS"+tpsCamera.gameObject.activeSelf);
        Debug.Log("FPS"+fpsCamera.gameObject.activeSelf);

        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        //Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * 100f, Color.green, 2f);
       // Debug.Log(fpsCamera.transform.forward);


        // 右クリックで撮影モード
        if (Input.GetMouseButtonDown(1))
        {
            if (!fpsCameraOn)
            {
                // 向きだけTPSからコピー
                //fpsCamera.transform.rotation = tpsCamera.transform.rotation;

                //tpsカメラの向きをfpsカメラにコピーする
                fpsCamera.SetRotation(tpsCamera.transform.rotation);

                tpsCamera.gameObject.SetActive(false);
                fpsCamera.gameObject.SetActive(true);
                cameraUI.SetActive(true);
                photoresultText.gameObject.SetActive(false);
                fpsCameraOn = true;
            }
            else //fpsCameraOnがTrueのときに右クリックでOFFにする
            {
                tpsCamera.gameObject.SetActive(true);
                fpsCamera.gameObject.SetActive(false);
                cameraUI.SetActive(false);
                fpsCameraOn = false;

            }

        };

        //
        if (Input.GetMouseButtonDown(0) && fpsCameraOn)
        {
            Debug.Log("撮影処理に入りました");

            Ray ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward);
            RaycastHit hit;

            // SEを鳴らす
            //Debug.Log(audioSource);
            audioSource.PlayOneShot(shutterSE);

            if (Physics.Raycast(ray, out hit, 100f))
            {

                //Creatureクラスの参照を取得する
                Creature creature = hit.collider.GetComponentInParent<Creature>();

                if (creature != null)
                {
                    //のちにイベントを発行して処理を細分化する
                    CreatureData data = creature.data;

                    encyclopediaManager.Register(data);

                    //スコア計算をする
                    int score = photoScoreSystem.CalculateScore(creature);

                    //Debug.Log(score);

                    photoresultText.text = "撮影成功！！";
                    photoresultText.gameObject.SetActive(true);
                    //3秒後に非表示にする
                    StartCoroutine(HideMessageAfterSeconds(3f));
                    //Debug.Log("撮影：" + creature.data.creatureName);

                }

            }
            else
            {
                photoresultText.text = "撮影失敗！！";
                photoresultText.gameObject.SetActive(true);
                //3秒後に非表示にする
                StartCoroutine(HideMessageAfterSeconds(3f));
                //Debug.Log("撮影失敗");
            }
        }

        IEnumerator HideMessageAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            photoresultText.gameObject.SetActive(false);
        }
    }




}
