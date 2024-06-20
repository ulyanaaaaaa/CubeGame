using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _firstZone; 
    [SerializeField] private int _gridSize = 3;
    private Cube _cube; 
    private bool[,] _grid;

    private void Awake()
    {
        _cube = Resources.Load<Cube>("Cube");
        _grid = new bool[_gridSize, _gridSize];
    }

    private void Start()
    {
        GenerateRandomGrid();
    }

    public void GenerateRandomGrid()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (Random.value > 0.8f) 
                {
                    Vector3 position = new Vector3(i - 1, 1, j - 1);
                    Instantiate(_cube, _firstZone.position + position, Quaternion.identity, _firstZone);
                    _grid[i, j] = true; 
                }
                else
                    _grid[i, j] = false; 
            }
        }
    }

    public bool[,] GetGrid()
    {
        return _grid;
    }
}