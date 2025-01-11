using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField] Vector3 moveValue;
    InputController inputController;
    GameObject range;
    
    void Start()
    {
        inputController = GetComponent<InputController>();
        Health = 6;
        UnitSpeed = 6;
        range = GameObject.Find("Range");
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

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == range)
        {
            Vector3 currentVelocity = unitRB.linearVelocity;
            // unitRB.linearVelocity = Vector3.zero;
            unitRB.AddForce(-currentVelocity, ForceMode.Impulse);
        }
    }
}
