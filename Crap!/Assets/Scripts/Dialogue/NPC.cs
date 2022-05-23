using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

    private bool triggered = false;

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