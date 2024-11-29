using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CanCrasher/Can Data", fileName = "Can Data")]
public class CanData : ScriptableObject
{
    public GameObject[] CanModels;
    public int HitNeeded;
    public int Score;
}
