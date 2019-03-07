using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating State option in creating menu in Unity
[CreateAssetMenu(menuName="State")]
public class State : ScriptableObject
{   
    //first num is describing how large is the field that we type in
    //second num is describing how many lines will fit before its start scrolling
    [TextArea(14,10)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }
     public State[] GetNextStates()
    {
        return nextStates;
    }
}
