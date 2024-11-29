using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public struct CanItem
{
    public CanType CanType;
    public CanData CanData;
}

[CreateAssetMenu(menuName = "CanCrasher/Setting", fileName = "Can Crasher Setting")]
public class CanCrasherSetting : ScriptableObject
{
    public float CountdownTime;
    public List<CanItem> AllCanItem;
    public Dictionary<CanType, CanData> CanItemDict;



    public void CreateCanItemDictionary()
    {
        CanItemDict = new Dictionary<CanType, CanData>();
        foreach (var canItem in AllCanItem) 
        {
            CanItemDict.Add(canItem.CanType, canItem.CanData);
        }
    }
}
