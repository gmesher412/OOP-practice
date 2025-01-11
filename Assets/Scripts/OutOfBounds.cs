using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    GameObject range;
    void Awake()
    {
        range = GameObject.Find("Range");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == range)
        {
            Destroy(gameObject);
        }
    }
}
