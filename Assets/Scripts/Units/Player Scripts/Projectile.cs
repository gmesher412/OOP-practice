using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public virtual int Damage {get; protected set;}
    public float projectileSpeed;

    void Awake()
    {
        Damage = 1;
        projectileSpeed = 25;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
