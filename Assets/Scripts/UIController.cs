using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] Button restart;
    [SerializeField] Button mainMenu;
    void Awake()
    {
        if(MenuManager.Instance != null)
        {
            playerName.text = MenuManager.Instance.nameText;
        }

        gameOver.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
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
        restart.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
}
