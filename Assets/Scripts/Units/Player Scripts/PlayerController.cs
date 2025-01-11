using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField] Vector3 moveValue;
    InputController inputController;
    
    void Start()
    {
        inputController = GetComponent<InputController>();
        Health = 6;
        UnitSpeed = 10;
    }

    void Update()
    {
        moveValue = inputController.MoveValue;
    }

    void FixedUpdate()
    {

        UnitMovement(moveValue);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            int damage = other.gameObject.GetComponent<Enemy>().Damage;
            TakeDamage(damage);
        }
    }
}
