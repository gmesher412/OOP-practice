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
        gameController = GameController.Instance;
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
        string tag = gameObject.tag;
        Health -= damage;

        if(Health < 1)
        {

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
