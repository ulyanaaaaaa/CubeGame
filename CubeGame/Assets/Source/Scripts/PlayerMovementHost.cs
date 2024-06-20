using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementHost : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsClient && IsOwner)
            enabled = false;
    }

    [ServerRpc]
    public void MovePlayerServerRpc(Vector3 input)
    {
        _rigidbody.velocity = input * _speed;
    }
}
