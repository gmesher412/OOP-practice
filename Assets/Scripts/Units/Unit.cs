using UnityEngine;

// INHERITANCE
// All units inherit basic characteristics from this class, including health, speed, and other
// utility charactistics, like a reference to the singleton GameController. 
[RequireComponent(typeof(Rigidbody))]
public abstract class Unit : MonoBehaviour
{
    protected Rigidbody unitRB;
    protected GameObject player;
    protected GameController gameController;
    protected virtual float UnitSpeed{get; set;}
    protected virtual float MaxVelocity {get; set;}

    // ENCAPSULATION
    // Any piece of code that wants to access the health of any unit can do so, but only Units can set
    // their own health
    public virtual int Health{get; protected set;}

    // POLYMORPHISM
    // All units call the original Awake function, but override it to add extra functionality
    // This is mostly used to initialise variables like health and speed
    protected virtual void Awake()
    {
        unitRB = GetComponent<Rigidbody>();
        gameController = GameController.Instance;
    }

    // ABSTRACTION
    // All units use the same movement method, but have their own ways to determine the movement direction
    // Because all movement direction is Vector3, polymorphism is not necessary
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
