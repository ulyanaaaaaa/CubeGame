using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _firstZone; 
    private Cube _cube; 
    
    private Vector3[,] _gridPositions = new Vector3[3, 3];

    private void Awake()
    {
        _cube = Resources.Load<Cube>("Cube");
    }

    private void Start()
    {
        InitializeGridPositions(_firstZone);
        SpawnCubes(_firstZone);
    }
    
    private void InitializeGridPositions(Transform zone)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _gridPositions[i, j] = new Vector3(zone.position.x - 1 + i,
                    zone.position.y + 0.5f,
                    zone.position.z - 1 + j);
            }
        }
    }
    
    private void SpawnCubes(Transform zone)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Random.value > 0.5f) 
                    Instantiate(_cube, _gridPositions[i, j], Quaternion.identity, zone);
            }
        }
    }
}