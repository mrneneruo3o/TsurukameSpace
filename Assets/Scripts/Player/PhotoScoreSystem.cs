using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 写真のスコア計算をする
/// 撮影処理CameraSystemから呼び出す
/// </summary>
public class PhotoScoreSystem : MonoBehaviour
{
    public Camera photoCamera;

    /// <summary>
    /// スコア計算をする処理
    /// </summary>
    /// <param name="creature"></param>
    /// <returns></returns>
    public int CalculateScore(Creature creature)
    {
        //生物の箱を取得
        Bounds bounds = creature.targetRenderer.bounds;

        //左下奥の座標=一番小さい位置
        Vector3 min = bounds.min;
        //右下手前の座標=一番大きい位置
        Vector3 max = bounds.max;

        //箱の8この角をつくる
        Vector3[] points =
        {
            new Vector3(min.x, min.y, min.z),
            new Vector3(max.x, min.y, min.z),
            new Vector3(min.x, max.y, min.z),
            new Vector3(max.x, max.y, min.z),

            new Vector3(min.x, min.y, max.z),
            new Vector3(max.x, min.y, max.z),
            new Vector3(min.x, max.y, max.z),
            new Vector3(max.x, max.y, max.z),
        };

        int visiblePoints = 0;

        foreach (Vector3 point in points)
        {
            //カメラの3D座標を画面上の位置に変換
            Vector3 viewport = photoCamera.WorldToViewportPoint(point);

            bool visible =
                viewport.z > 0 &&   //カメラの前にいるか
                viewport.x >= 0 &&  //画面横範囲内か
                viewport.x <= 1 &&
                viewport.y >= 0 &&  //画面縦範囲内か
                viewport.y <= 1;

            //カメラ画面内に映っている場合スコアを加算
            if (visible)
            {
                visiblePoints++;
            }
        }

        float visiblePercent =
            visiblePoints / 8f;

        int score =
            Mathf.RoundToInt(visiblePercent * 100);

        return score;
    }
}
