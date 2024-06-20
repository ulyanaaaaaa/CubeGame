using UnityEngine;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    public void StartHost()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            NetworkManager.Singleton.StartHost();
    }

    public void StartClient()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            NetworkManager.Singleton.StartClient();
    }
}