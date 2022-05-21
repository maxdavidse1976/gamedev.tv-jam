using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.MemoryProfiler;

public class ConversationScript : MonoBehaviour
{
    private Player player;

    [Tooltip("The distance away from the interlocutor to enable conversation")]
    public int distanceToTalk = 3;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < distanceToTalk)
        {
            Debug.Log("im close");
        }
    }
}
