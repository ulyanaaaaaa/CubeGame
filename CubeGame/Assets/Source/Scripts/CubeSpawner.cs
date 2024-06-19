using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _firstZone; 
    [SerializeField] private int gridSize = 3;
    private Cube _cube; 

    private void Awake()
    {
        _cube = Resources.Load<Cube>("Cube");
    }

    private void Start()
    {
        RandomSpawnCube();
    }
    
    private void RandomSpawnCube()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (Random.value > 0.7f) 
                {
                    Vector3 position = new Vector3(i - 1, 1, j - 1);
                    Instantiate(_cube, _firstZone.position + position, Quaternion.identity, _firstZone);
                }
            }
        }
    }
}