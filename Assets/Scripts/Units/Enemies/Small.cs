using UnityEngine;

public class Small : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        Health = 1;
        UnitSpeed = 1.5f;
        Damage = 1;
        MaxVelocity = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UnitMovement(targetDirection);
    }
}
