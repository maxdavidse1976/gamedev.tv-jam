using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;
    [SerializeField] TMP_Text healthText;

    private PointSystem pointSystem;
    private PlayerHealth playerHealth;

    private void Start()
    {
        pointSystem = FindObjectOfType<PointSystem>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        counterText.text = "Counter: " + pointSystem.counter;
        healthText.text = "Health: " + playerHealth.currentHealth;
    }
}
