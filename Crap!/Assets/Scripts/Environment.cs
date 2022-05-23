using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform player;
    [SerializeField] private MeshRenderer playerMeshRenderer;
    [SerializeField] private MeshRenderer groundMeshRenderer;
    [SerializeField] private Transform evilBoundary;
    [SerializeField] private Transform goodBoundary;
    [SerializeField] private float amountToChangeColor = 0.005f;
    private Material playerMaterial;
    private Material groundMaterial;
    private float timer = 0;
    private float duration = 10f;

    void Start()
    {
        playerMaterial = playerMeshRenderer.material;
        groundMaterial = groundMeshRenderer.material;
    }

    void Update()
    {
        //if (player.position.x >= evilBoundary.position.x)
        //{
        //    Debug.Log("Changing colors");
        //    ChangeColors(amountToChangeColor, false);
        //}
        //else if (player.position.x <= goodBoundary.position.x)
        //{
        //    Debug.Log("Changing colors");
        //    ChangeColors(amountToChangeColor, true);
        //}
        //if (timer < duration)
        //{
        //    timer += Time.deltaTime / duration;
        //}
    }

    private void ChangeColors(float changeBy, bool towardsHeaven)
    {
        if (!towardsHeaven && amountToChangeColor > 0)
        {
            amountToChangeColor = -amountToChangeColor;
        }
        else if (towardsHeaven && amountToChangeColor < 0)
        {
            amountToChangeColor = -amountToChangeColor;
        }

        float newPlayerColorR = 0;
        float newPlayerColorG = 0;
        float newPlayerColorB = 0;
        float newGroundColorR = 0;
        float newGroundColorG = 0;
        float newGroundColorB = 0;

        if (amountToChangeColor < 0)
        {
            newPlayerColorR = (playerMaterial.color.r >= -amountToChangeColor) ? playerMaterial.color.r + amountToChangeColor : 0;
            newPlayerColorG = (playerMaterial.color.g >= -amountToChangeColor) ? playerMaterial.color.g + amountToChangeColor : 0;
            newPlayerColorB = (playerMaterial.color.b >= -amountToChangeColor) ? playerMaterial.color.b + amountToChangeColor : 0;

            newGroundColorR = (groundMaterial.color.r >= -amountToChangeColor) ? groundMaterial.color.r + amountToChangeColor : 0;
            newGroundColorG = (groundMaterial.color.g >= -amountToChangeColor) ? groundMaterial.color.g + amountToChangeColor : 0;
            newGroundColorB = (groundMaterial.color.b >= -amountToChangeColor) ? groundMaterial.color.b + amountToChangeColor : 0;

        }
        else
        {
            newPlayerColorR = (playerMaterial.color.r >= 1) ? 1 : playerMaterial.color.r + amountToChangeColor;
            newPlayerColorG = (playerMaterial.color.g >= 1) ? 1 : playerMaterial.color.g + amountToChangeColor;
            newPlayerColorB = (playerMaterial.color.b >= 1) ? 1 : playerMaterial.color.b + amountToChangeColor;

            newGroundColorR = (groundMaterial.color.r >= 1) ? 1 : groundMaterial.color.r + amountToChangeColor;
            newGroundColorG = (groundMaterial.color.g >= 1) ? 1 : groundMaterial.color.g + amountToChangeColor;
            newGroundColorB = (groundMaterial.color.b >= 1) ? 1 : groundMaterial.color.b + amountToChangeColor;
        }
        Color newPlayerColor = new Color(newPlayerColorR, newPlayerColorG, newPlayerColorB);
        playerMaterial.color = Color.Lerp(playerMaterial.color, newPlayerColor, timer);
        Color newGroundColor = new Color(newGroundColorR, newGroundColorG, newGroundColorB);
        groundMaterial.color = Color.Lerp(groundMaterial.color, newGroundColor, timer);
    }
}
