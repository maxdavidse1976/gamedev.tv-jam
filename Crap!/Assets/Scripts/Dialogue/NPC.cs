using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

    private bool triggered = false;

    private void Start()
    {

    }

    public void TriggerDialogue()
    {
        if (triggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            triggered = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        TriggerDialogue();
    }
}