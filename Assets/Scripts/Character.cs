using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores
{
    public Action s_Action;
    public int s_Score;
    public Scores(Action action, int score)
    {
        s_Action = action;
        s_Score = score;
    }
}

[CreateAssetMenu(fileName = " NewCharacter", menuName = "Story Engine/Character")]
public class Character : ScriptableObject
{
    //[SerializeField] string name; only useful outside of unity
    List<Action> _actions;//initialized by the engine
    List<Scores> _Scores;
    //list of goals
    [SerializeField] List<Trait> _traits;
    [SerializeField] List<Relationship> _relationships;
    [SerializeField] List<Goal> _goals;
    //Representation of the world state
    VirtualWorldState _percievedWorldState = new VirtualWorldState();
    

    Action _nextAction = null;

    int EvaluateAction(Action action/*, ActionScoreModifiers*/)
    {

        //score action according to practicality, personal volition and beat (if applicable)
        return -1;
    }

    public void Think(/*ActionScoreModifiers*/)
    {
        //int[] actionScores = new int[_actions.Count];
        //int bestAction = -1;
        //for (int i = 0; i < _actions.Count; i++)
        //{
        //    actionScores[i] = EvaluateAction(_actions[i]/*, ActionScoreModifiers*/);
        //    if (bestAction == -1 || actionScores[i] > actionScores[bestAction])
        //    {
        //        bestAction = i;
        //    }
        //}
        ////log action scores
        //
        //_nextAction = _actions[bestAction];
        for(int i = 0; i < _Scores.Count; i++)
        {
            _Scores[i].s_Score = _Scores[i].s_Action.getCompatibility(this);
            
            
        }
    }

    public void Act()
    {
        if (_nextAction == null)
        {
            return;
        }
        //execute nextAction
        _nextAction = null;
    }

    public void InitActions(List<Action> actionPool)//get a copy of the reference list of action that the character can sort later.
    {

        foreach (var action in actionPool)
        {
            _Scores.Add(new Scores(action,0));
        }
    }
}
