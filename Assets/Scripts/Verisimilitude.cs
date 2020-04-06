using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "NewEngine", menuName = "Story Engine/Engine")]
public class Verisimilitude : ScriptableObject
{
    [SerializeField] List<Character> _characters;
    [SerializeField] List<Action> _Actions;
    [SerializeField] List<Beat> _beats;

    int _time = 0;
    public int Time { get { return _time; } }
    int _nextBeat = 0;

    public void Init()
    {
        //scriptable objects retain all variables between runs
        _time = 0;
        _nextBeat = 0;

        Logger.SetEngine(this);
        //sort and sanity check beats
        for (int i = 0; i < _beats.Count; i++)
        {
            Assert.IsNotNull(_beats[i], "Beat " + i + " was null");
            Assert.IsTrue(_beats[i].TargetTime >= 0, "Beat " + i + " scheduled for negative time");
        }
        _beats.Sort((lhs, rhs) => lhs.TargetTime.CompareTo(rhs.TargetTime));
        for (int beat = 0; beat < _beats.Count; beat++)
        {
            for (int other = 0; other < _beats.Count; other++)
            {
                if (beat == other)
                {
                    continue;
                }
                Assert.AreNotEqual(_beats[beat], _beats[other], "Beat " + beat + " same as " + other);
                Assert.AreNotEqual(_beats[beat].TargetTime, _beats[other].TargetTime, "Two beats scheduled for same time");
            }
        }

        //sanity check characters
        for (int character = 0; character < _characters.Count; character++)
        {
            Assert.IsNotNull(_characters[character]);
            for (int other = 0; other < _characters.Count; other++)
            {
                Assert.IsTrue(character == other || _characters[character] != _characters[other], "Character " + character + " same as " + other);
            }
        }
    }

    public void Tick()
    {
        _time++;
        //evaluate beats for scoring and distributing prefered actions to characters

        //simulturns or consecutive?
        foreach (Character character in _characters)
        {
            character.Think(/*ActionScoreModifiers*/);
        }

        foreach (Character character in _characters)
        {
            character.Act();
        }
    }
}
