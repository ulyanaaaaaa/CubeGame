using UnityEngine;

public class GridCheker : MonoBehaviour
{
    [SerializeField] private Transform _firstZone; 
    [SerializeField] private Transform _secondZone; 
    [SerializeField] private int _gridSize = 3; 
    private bool _isCorrect = true;

    public void CheckGrid()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                Vector3 expectedPosition = _firstZone.position + new Vector3(i, 0, j);
                if (IsCubeAtPosition(_firstZone, expectedPosition) != IsCubeAtPosition(_secondZone, expectedPosition))
                {
                    _isCorrect = false;
                    break;
                }
            }
            if (!_isCorrect)
            {
                break;
            }
        }

        if (_isCorrect)
        {
            Debug.Log("Grid is correct! You win!");
        }
        else
        {
            Debug.Log("Grid is incorrect! Try again!");
        }
    }

    private bool IsCubeAtPosition(Transform zone, Vector3 position)
    {
        foreach (Transform child in zone)
        {
            if (Vector3.Distance(child.position, position) < 0.5f)
            {
                return true;
            }
        }
        return false;
    }
}


