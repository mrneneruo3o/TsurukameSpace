using UnityEngine;

/// <summary>
/// 生き物に関する情報を管理するデータ
/// </summary>
/// 

//UnityでCreate>CreatureDataでつくれるようになる=アセット化
[CreateAssetMenu(fileName = "New Creature", menuName = "Creature Data")]
public class CreatureData : ScriptableObject
{
    public string creatureName;
    public Sprite icon;

    //セーブのときに必要なるID
    public string id;

    [TextArea]
    public string description;
}