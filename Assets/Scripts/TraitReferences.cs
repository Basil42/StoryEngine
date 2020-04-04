using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitRef", menuName = "Story Engine/References/Traits")]
public class TraitReferences : ScriptableObject
{
    public List<Trait> traits;
}
