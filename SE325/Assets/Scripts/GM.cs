using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public string currentObjectiveText;
    public int enemiesKilled = 0;
    [Header("Objective Checks")]
    public bool firstObjectiveCompleted = false;
    public bool secondObjectiveCompleted = false;
    public bool thirdObjectiveCompleted = false;
    public bool fourthObjectiveCompleted = false;

    [Header("Objective Texts")]
    public string firstObjectiveText = "Find and talk to a police officer nearby to learn more about the local situation.";
    public string secondObjectiveText = "Clear the area surrounding the house of enemy soldiers.";
    public string thirdObjectiveText = "Return to the police officer.";
    public string fourthObjectiveText = "Head towards the location the officer told you about in order to escape.";

    void Start()
    {
        currentObjectiveText = firstObjectiveText;
    }

    void Update()
    {
        
    }
}
