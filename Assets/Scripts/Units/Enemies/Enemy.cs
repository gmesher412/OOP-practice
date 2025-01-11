using UnityEngine;

public abstract class Enemy : Unit
{
    protected GameObject target;
    protected Vector3 targetDirection;
    public virtual int Damage{get; set;}

    protected virtual void Start()
    {
        PlayerFinder();
    }

    protected virtual void FixedUpdate()
    {
        unitRB.maxLinearVelocity = MaxVelocity;
    }
    
    protected Vector3 Direction()
    {
        targetDirection = player.transform.position - transform.position;
        return targetDirection.normalized;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            int projectileDamage = other.GetComponent<Projectile>().Damage;
            TakeDamage(projectileDamage);
            Destroy(other.gameObject);
        }
    }
}
