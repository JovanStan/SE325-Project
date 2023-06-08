using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM : MonoBehaviour
{
    public static GM instance;
    public string currentObjectiveText;
    public int enemiesKilled = 0;
    [Header("Objective Checks")]
    public bool firstObjectiveCompleted = false;
    public bool secondObjectiveCompleted = false;
    public bool thirdObjectiveCompleted = false;
    public bool fourthObjectiveCompleted = false;

    [Header("Objective Texts")]
    public TMP_Text questText;
    public TMP_Text conversationText;
    public GameObject conversationPanel;
    public string firstObjectiveText = "Find and talk to a police officer nearby to learn more about the local situation.";
    public string secondObjectiveText = "Clear the area surrounding the house of enemy soldiers.";
    public string thirdObjectiveText = "Return to the police officer.";
    public string fourthObjectiveText = "Head towards the location the officer told you about in order to escape.";


    public GameObject npc, player, interactionText;


	private void Awake()
	{
		instance = this;
	}

	void Start()
    {
        currentObjectiveText = firstObjectiveText;
        questText.text = currentObjectiveText;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, npc.transform.position);
        if(distance <= 2f && !firstObjectiveCompleted)
        {
            interactionText.SetActive(true);
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    public void FirstObjectiveDone()
    {
        firstObjectiveCompleted = true;
		currentObjectiveText = secondObjectiveText;
        questText.text = currentObjectiveText;

        // Conversation
        conversationPanel.SetActive(true);
        conversationText.text = "Liuetenant, a moment of your time please. The regional government house has been taken by hostile forces, and we need it if we are to mount any resistance in this area. Would you help us?";
        StartCoroutine(ConversationToggle());
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled >= 5)
            SecondObjectiveDone();
    }

    private void SecondObjectiveDone()
    {
        secondObjectiveCompleted = true;
        currentObjectiveText = thirdObjectiveText;
        questText.text = currentObjectiveText;
    }

    public void ThirdObjectiveDone()
    {
        thirdObjectiveCompleted = true;
        currentObjectiveText = fourthObjectiveText;
        questText.text = currentObjectiveText;

        // Conversation
        conversationPanel.SetActive(true);
        conversationText.text = "Thank you for your help liuetenant Dubois. I know you are trying to get to friendly territory, and I think I can help you. Talk to my colleague who is stationed by a campfire to the west.";
        StartCoroutine(ConversationToggle());
    }

    public void FourthObjectiveDone()
    {
        fourthObjectiveCompleted = true;
        currentObjectiveText = "";
        questText.text = currentObjectiveText;
        // win screen
    }

    private IEnumerator ConversationToggle()
    {
        yield return new WaitForSeconds(10);

        conversationPanel.SetActive(false);
    }
}
