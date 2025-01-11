using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameController gameController;
    GameObject player;
    Vector3 offset, velocity = Vector3.zero;
    float smoothTime = 0.25f;    

    void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        offset = transform.position;
    }
    void Start()
    {
        player = gameController.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
