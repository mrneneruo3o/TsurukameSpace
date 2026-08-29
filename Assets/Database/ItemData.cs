using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// どこかの文明の遺物アイテムのデータを管理する
/// </summary>
[CreateAssetMenu(menuName = "Item/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public Sprite detailImage;
    [TextArea]
    public string description;
}
