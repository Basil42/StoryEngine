using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " NewCharacter", menuName = "Story Engine/Character")]
public class Character : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] List<Action> _actions;
    [SerializeField] List<Trait> _traits;
    [SerializeField] List<Relationship> _relationships;

    Action _nextAction = null;

    int EvaluateAction(Action action/*, ActionScoreModifiers*/)
    {
        //score action according to practicality, personal volition and beat (if applicable)
        return -1;
    }

    public void Think(/*ActionScoreModifiers*/)
    {
        int[] actionScores = new int[_actions.Count];
        int bestAction = -1;
        for (int i = 0; i < _actions.Count; i++)
        {
            actionScores[i] = EvaluateAction(_actions[i]/*, ActionScoreModifiers*/);
            if (bestAction == -1 || actionScores[i] > actionScores[bestAction])
            {
                bestAction = i;
            }
        }
        //log action scores

        _nextAction = _actions[bestAction];
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

}
