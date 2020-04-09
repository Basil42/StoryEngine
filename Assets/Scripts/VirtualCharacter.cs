using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualInteraction
{
    public int turn;//turn the interaction happened
    public Dictionary<Relationship, int> _effects;//Which relationships were affected by the interaction and how much(These value grow smaller over time
    //more detailed information could be conveyed later
}
public class VirtualCharacter
{
    Dictionary<Trait, float> _traits = new Dictionary<Trait, float>();
    Dictionary<Relationship, float> _relationships = new Dictionary<Relationship, float>();
    Dictionary<VirtualInteraction, float> _actionHistory = new Dictionary<VirtualInteraction, float>();//Each character logs its interaction with other characters
    Dictionary<Goal, float> _percievedGoals;
}

