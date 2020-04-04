using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newActionReferences", menuName = " Story Engine/References/Actions")]
public class ActionReferences : ScriptableObject
{
    public List<Action> Actions;
}
