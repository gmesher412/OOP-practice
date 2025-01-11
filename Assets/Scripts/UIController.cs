using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI gameOver;
    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateHealth(int healthToDisplay)
    {
        health.text = "Health: " + healthToDisplay;
    }

    public void GameOverDisplay()
    {
        gameOver.gameObject.SetActive(true);
    }
}
