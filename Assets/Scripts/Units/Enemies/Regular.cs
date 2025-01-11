using UnityEngine;

public class Regular : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        Health = 6;
        UnitSpeed = 1;
        Damage = 2;
        MaxVelocity = 5;
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
