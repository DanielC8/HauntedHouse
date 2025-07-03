using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{


    public GameObject panel;
    public GameObject dialogueText;
    public String[] dialogues;  //stores all the dialogue
    private TextMeshProUGUI text;
    private int dialogueIndex; // index the is on for the dialogue

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(true); // makes it active
        text = dialogueText.GetComponent<TextMeshProUGUI>();
        dialogueIndex = 0; //initializes index to 0
    }

    public void PrevDialogue()
    {
        SoundManager.Instance.PlayButton();
        //only moves down if the index is bigger than 0
        if (dialogueIndex > 0)
        {
            dialogueIndex -= 1; //decrement index by 1
            text.SetText(dialogues[dialogueIndex]);
        }
    }

    public void NextDialogue()
    {
        SoundManager.Instance.PlayButton();
        //only moves up when its less than array length
        dialogueIndex += 1; //increment index by 1
        if (dialogueIndex < dialogues.Length)
        {

            text.SetText(dialogues[dialogueIndex]);
        }
        else if (dialogueIndex == dialogues.Length) //if you exceed array indecies then you move to exit scene
        {
            SceneManager.LoadScene("ExitScene");
        }

        if (dialogueIndex == dialogues.Length - 1) //jumpscare on the last dialogue
        {
            Animation animation = GameObject.Find("Ghost").GetComponent<Animation>();
            animation.Play();
            SoundManager.Instance.PlayJumpscare();
        }
        else if (dialogueIndex == 1)
        {
            SoundManager.Instance.PlayHeartbeat(); //plays heartbeat when reach second dialogue
        }
    }
    
}

