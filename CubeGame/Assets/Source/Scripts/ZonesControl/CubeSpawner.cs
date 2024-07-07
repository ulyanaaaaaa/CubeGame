using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _gridSize = 3;
    [SerializeField] private GameButtons _gameButtons;
    private Cube _cube; 
    private bool[,] _grid;

    private void Awake()
    {
        _cube = Resources.Load<Cube>("Cube");
        _grid = new bool[_gridSize, _gridSize];
    }

    private void OnEnable()
    {
        _gameButtons.OnPlay += GenerateRandomGrid;
    }

    private void OnDisable()
    {
        _gameButtons.OnPlay -= GenerateRandomGrid;
    }

    private void Start()
    {
        GenerateRandomGrid();
    }

    public void GenerateRandomGrid()
    {
        ClearGrid();
        
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (Random.value > 0.8f) 
                {
                    Vector3 position = new Vector3(i - 1, 1, j - 1);
                    Instantiate(_cube, transform.position + position, Quaternion.identity, transform);
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

    private void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}