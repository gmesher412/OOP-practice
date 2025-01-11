using UnityEngine;


public class Aiming : MonoBehaviour
{
    private InputController inputController;
    public Vector3 screenPosV;
    [SerializeField] LayerMask groundMask;

    void Awake()
    {
        inputController = GetComponentInParent<InputController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        screenPosV = inputController.MousePosition;
        Aim();
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(screenPosV);
        Debug.DrawRay(ray.origin, ray.direction * 100);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success:true, position: hitInfo.point);
            
        }
        else
        {
            return(success: false, position: Vector3.zero);
        }
    }

    void Aim()
    {
        var (success, position) = GetMousePosition();
        if(success)
        {
            var direction = position - transform.position;
            
            direction.y = 0;

            transform.forward = direction;
        }
    }
}
