using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// セーブデータを作成する
/// セーブデータをロードする=該当の生物ID,目標ID,などがあるか調べる
/// </summary>
public class SaveManager : MonoBehaviour
{
    //セーブデータ格納
    public SaveData Data { get; private set; }

    //セーブデータ保存先
    string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    //テスト用
    private void Awake()
    {
        Load();
    }

    /// <summary>
    /// セーブデータをロード=Dataにjsonファイルを格納していつでも使えるようにする
    /// セーブデータ読み込み時に一度だけ呼び出す
    /// </summary>
    public void Load()
    {
        //セーブデータが保存されている
        if (File.Exists(SavePath))
        {
            //stringで読み込む
            string json = File.ReadAllText(SavePath);
            //stringのjsonファイルをオブジェクトにして格納
            Data = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            //セーブデータがないなら作成する
            Data = new SaveData();
        }

        //??= 左辺がnullなら右辺を代入
        Data ??= new SaveData();
        Data.photographedSpeciesIds ??= new List<string>();
        Data.completedGoalIds ??= new List<string>();
    }

    /// <summary>
    /// 生物IDがセーブデータに存在するか調べる
    /// </summary>
    /// <param name="speciesId"></param>
    /// <returns></returns>
    public bool HasPhotographed(string speciesId)
    {
        //リストにあるかどうかbool値を返す
        return Data.photographedSpeciesIds.Contains(speciesId);
    }

    /// <summary>
    /// 目標IDがセーブデータに存在するか調べる
    /// </summary>
    /// <param name="goalId"></param>
    /// <returns></returns>
    public bool IsGoalCompleted(string goalId)
    {
        //リストにあるかどうかbool値を返す
        return Data.completedGoalIds.Contains(goalId);
    }

    public void MarkPhotographed(string speciesId)
    {
        Debug.Log("生物ID保存");
        //セーブデータに生物IDが存在しないとき
        if (!Data.photographedSpeciesIds.Contains(speciesId))
        {
            //撮影された生物IDリストに加える
            Data.photographedSpeciesIds.Add(speciesId);
            //jsonファイルを更新
            SaveToFile();
        }
    }

    public void MarkGoalCompleted(string goalId)
    {
        Debug.Log("目標ID保存");

        //セーブデータに生物IDが存在しないとき
        if (!Data.completedGoalIds.Contains(goalId))
        {
            //撮影された生物IDリストに加える
            Data.completedGoalIds.Add(goalId);
            //jsonファイルを更新
            SaveToFile();
        }
    }

    private void SaveToFile()
    {
        //jsonファイルを作成する　true:読みやすさのため出力を書式設定(falseは最小サイズ)
        string json = JsonUtility.ToJson(Data, true);
        //textファイルに出力する
        File.WriteAllText(SavePath, json);
        Debug.Log("保存先"+ SavePath);
    }
}

/// <summary>
/// セーブデータ
/// 撮影した生物ID
/// 達成した目標ID
/// </summary>
[System.Serializable]
public class SaveData
{
    public List<string> photographedSpeciesIds = new();
    public List<string> completedGoalIds = new();  
}
