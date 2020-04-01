using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBeat", menuName = "Story Engine/Beat")]
public class Beat : ScriptableObject
{
    [SerializeField] string _name;
    public string Name { get { return _name; } }
    [SerializeField] int _targetTime;
    public int TargetTime { get { return _targetTime; } }

    //List of actions requested by TargetTime
}
