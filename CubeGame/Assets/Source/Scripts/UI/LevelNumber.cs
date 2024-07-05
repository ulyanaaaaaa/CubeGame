using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelNumber : MonoBehaviour
{
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private BestScore _bestScore;
    private TextMeshProUGUI _text;
    private int _number = 1;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateLevel();
    }

    private void OnEnable()
    {
        _gridCheсker.OnWin += NextLevel;
        _gridCheсker.OnLoose += FirstLevel;
    }
    
    private void OnDisable()
    {
        _gridCheсker.OnWin -= NextLevel;
        _gridCheсker.OnLoose -= FirstLevel;
    }

    private void NextLevel()
    {
        _number++;
        UpdateLevel();
    }

    private void FirstLevel()
    {
        _number = 1;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        _text.text = "Level: " + _number;
        _bestScore.CheckScore(_number);
    }
    
}
