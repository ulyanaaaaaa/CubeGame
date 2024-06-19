using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class GridCheсker : MonoBehaviour
{
    [SerializeField] private Transform _firstZone; 
    [SerializeField] private Transform _secondZone; 
    [SerializeField] private int _gridSize = 3;
    private CubeSpawner _firstZoneGenerator;
    private bool _isCorrect = true;

    private bool[,] _firstGrid;
    private bool[,] _secondGrid;

    private void Awake()
    {
        _firstZoneGenerator = _firstZone.GetComponent<CubeSpawner>();
    }

    private void Start()
    {
        _firstGrid = _firstZoneGenerator.GetGrid();
        _secondGrid = new bool[_gridSize, _gridSize];
    }

    public void CheckGrid()
    {
        UpdateSecondGrid();

        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                if (_firstGrid[i, j] != _secondGrid[i, j])
                {
                    _isCorrect = false;
                    break;
                }
            }
            if (!_isCorrect)
                break;
        }
        
        if (_isCorrect)
            Debug.Log("Grid is correct! You win!");
        else
            Debug.Log("Grid is incorrect! Try again!");
    }

    private void UpdateSecondGrid()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
                _secondGrid[i, j] = false;
        }
        
        foreach (Transform child in _secondZone)
        {
            int i = Mathf.RoundToInt(child.position.x);
            int j = Mathf.RoundToInt(child.position.z);
            
            if (i >= 0 && i < _gridSize && j >= 0 && j < _gridSize)
                _secondGrid[i, j] = true;
        }
    }
}


