using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] Player player;
    [SerializeField] float distanceToPlayer = 3f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider collider)
    {
        TriggerDialogue();
    }

    //private void Update()
    //{
    //    if(Physics.CheckSphere(gameObject.transform.position, distanceToPlayer, 5))
    //    {
    //        Debug.Log("test");
    //        TriggerDialogue();
    //    }

    //    //if (Vector3.Distance(gameObject.transform.position, player.transform.position) < distanceToPlayer) {
    //    //    TriggerDialogue();
    //    //}
    //}
}