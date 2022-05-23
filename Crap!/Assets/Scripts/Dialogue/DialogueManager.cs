using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Tooltip("Insert the Text Gameobject you want to show as name")]
    public TMP_Text nameText;

    [Tooltip("Insert the Text Gameobject you want to show as text")]
    public TMP_Text dialogueText;

    [Tooltip("Opening / Closing of the dialogue")]
    public Animator animator;

    private Queue<string> sentences;

    private Player player;

    void Start()
    {
        sentences = new Queue<string>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void Update()
    {
        // Used to make the player use the [ENTER] on the keyboard in order to go to the next sentence
        // and / or close the dialogue when finished
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        // Remove the controls of the player body in order to not move
        player.enabled = false;
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        // Give the player back his control over his body
        player.enabled = true;
    }
}