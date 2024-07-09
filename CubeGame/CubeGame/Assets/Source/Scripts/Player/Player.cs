using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _pickUpRange = 3f;
    private bool _isPick;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) ||Input.GetKeyDown(KeyCode.RightShift))
        {
            if (_isPick)
                PickDown();
            else
                PickUp();
        }
    }

    private void PickDown()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Cube cube))
            {
                cube.DeleteParent();
                _isPick = false;
                cube.CheckZone();
            }
        }
    }

    private void PickUp()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, forward, out hit, _pickUpRange))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                cube.AddParent(gameObject);
                _isPick = true;
            }
        }
    }
}
