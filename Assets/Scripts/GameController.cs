using UnityEngine;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] GameObject playerObject;
    public GameObject player;
    public bool gameOver;

    void Awake()
    {
        Singleton();

        player = Instantiate(playerObject, playerObject.transform.position, playerObject.transform.rotation);

        gameOver=false;
    }

    void Singleton()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}
