using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Unit : MonoBehaviour
{
    protected Rigidbody unitRB;
    protected GameObject player;
    protected GameController gameController;


    protected virtual float UnitSpeed{get; set;}
    protected virtual float MaxVelocity {get; set;}
    public virtual int Health{get; protected set;}

    protected virtual void Awake()
    {
        unitRB = GetComponent<Rigidbody>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    protected virtual void UnitMovement(Vector3 movementDirection)
    {
        if(!gameController.gameOver)
        {
            unitRB.AddForce(movementDirection * UnitSpeed);
        }
        else
        {
            unitRB.angularVelocity = Vector3.zero;
            unitRB.linearVelocity = Vector3.zero;
        }
    }

    
    protected GameObject PlayerFinder()
    {
        player = gameController.player;
        return player;
    }

    protected void TakeDamage(int damage)
    {
        Health -= damage;
        gameController.uIController.UpdateHealth(Health);

        if(Health < 1)
        {
            string tag = gameObject.tag;
            Dies(tag);
        }
    }

    protected virtual void Dies(string tag)
    {
        if(tag == "Player")
        {
            gameController.GameOver();
        }

        if(tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
