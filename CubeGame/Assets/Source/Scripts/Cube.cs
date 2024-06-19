using UnityEngine;

public class Cube : MonoBehaviour
{
    public void DeleteParent()
    {
        transform.parent = null;
    }

    public void AddParent(GameObject gameObject)
    {
        transform.parent = gameObject.transform;
    }
}
