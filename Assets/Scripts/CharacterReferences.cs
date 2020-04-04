using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCharacterReferences", menuName = " Story Engine/References/Characters")]
public class CharacterReferences : ScriptableObject
{
    public List<Character> characters;
}
