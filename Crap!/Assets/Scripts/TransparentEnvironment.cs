using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentEnvironment : MonoBehaviour
{
    Player player;

    MeshRenderer meshRenderer;

    float distanceToPlayer;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        meshRenderer = GetComponent<MeshRenderer>();

        distanceToPlayer = (gameObject.transform.lossyScale.x - 3f);
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < distanceToPlayer)
        {
            if(meshRenderer.material.color.a > 0f)
            {
                meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, meshRenderer.material.color.a - (1f * Time.deltaTime));
            }
        } 
        else
        {
            if(meshRenderer.material.color.a < 1f)
            {
                meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, meshRenderer.material.color.a + (1f * Time.deltaTime));
            }
        }
    }
}
