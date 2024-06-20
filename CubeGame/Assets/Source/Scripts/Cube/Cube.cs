using Unity.Netcode;
using UnityEngine;

public class Cube : NetworkBehaviour
{
    [SerializeField] private float _checkZoneRange = 1f;
    
    public void DeleteParent()
    {
        transform.parent = null;
    }

    public void AddParent(GameObject gameObject)
    {
        transform.parent = gameObject.transform;
    }
    
    public void CheckZone()
    {
        RaycastHit hit;
        Vector3 down = transform.TransformDirection(Vector3.down);
        
        if (Physics.Raycast(transform.position, down, out hit, _checkZoneRange))
        {
            if (hit.collider.TryGetComponent(out Zone zone))
                AddParent(zone.gameObject);
        }
    }
}
