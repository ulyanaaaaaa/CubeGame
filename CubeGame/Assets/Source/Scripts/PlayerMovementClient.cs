using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementClient : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsOwner) 
            return;

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        SendInputToServerRpc(input);
    }

    [ServerRpc]
    private void SendInputToServerRpc(Vector3 input)
    {
        _rigidbody.velocity = input * _speed;
    }
}
