using UnityEngine;

public class Large : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        Health = 12;
        UnitSpeed = 0.25f;
        Damage = 3;
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
