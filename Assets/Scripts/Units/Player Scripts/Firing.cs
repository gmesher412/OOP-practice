using UnityEngine;


public class Firing : MonoBehaviour
{
    private InputController inputController;
    [SerializeField] GameObject projectile;
    GameController gameController;

    float fireTime;
    float fireDelay;

    void Awake()
    {
        inputController = GetComponentInParent<InputController>();
        fireTime = Time.time;
        fireDelay = 0.25f;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(inputController.FireAction.IsPressed() && Time.time > (fireTime + fireDelay) && !gameController.gameOver)
        {
            GameObject clone = Instantiate(projectile, transform.position, gameObject.transform.rotation);

            Projectile projectileController = clone.GetComponent<Projectile>();
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * projectileController.projectileSpeed, ForceMode.Impulse);

            fireTime = Time.time;
        }
    }
}
