using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    protected Rigidbody enemyRB;
    protected GameObject player;
    protected float speed;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        enemyRB.AddForce(direction * speed);
    }
}
