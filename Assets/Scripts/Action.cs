using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAction", menuName = "Story Engine/Action")]
public abstract class Action : ScriptableObject
{
    [SerializeField] string _name;

    //evaluate if it is possible given current worldstate
    public abstract bool CanExecute();

    //alter worldstate
    public abstract void Execute();

    
    //broadcast to all characters, including instigator, targets and witnesses
    //investigate c# delegates
    public abstract void Broadcast();
    public abstract int getCompatibility(List<Trait> traits);//attractivness of the action given a set of traits
    public abstract int getCompatibility(List<Beat> Beats);//attractiveness of the action in regard of its participation in fullfilling a narrative beat
    public abstract int getCompatibility(List<Relationship> relationships);

    public abstract int getCompatibility(List<Goal> goals);

}
