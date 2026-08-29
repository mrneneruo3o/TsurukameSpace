using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public List<CreatureData> discoveredCreatures
        = new List<CreatureData>();

    public void Register(CreatureData data)
    {
        //‚·‚Å‚É“o˜^Ï‚İ‚È‚çˆ—‚ğ”²‚¯‚é
        if (discoveredCreatures.Contains(data)) return;

        //ƒŠƒXƒg‚É“o˜^
       discoveredCreatures.Add(data);

        Debug.Log(data.creatureName + "‚ğ“o˜^I");

    }

}
