using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(TextTranslator))]
public class LevelNumber : MonoBehaviour
{
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private BestScore _bestScore;
    private TextTranslator _translator;
    private TextMeshProUGUI _text;
    private int _number = 1;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _translator = GetComponent<TextTranslator>();
    }

    private void Start()
    {
        UpdateLevel();
    }

    private void OnEnable()
    {
        _translator.TranslateText += UpdateLevel;
        _gridCheсker.OnWin += NextLevel;
        _gridCheсker.OnLoose += FirstLevel;
    }
    
    private void OnDisable()
    {
        _translator.TranslateText -= UpdateLevel;
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
        _text.text = _translator.Translate(_translator.Id) + "\n" + _number;
        _bestScore.CheckScore(_number);
    }
    
}
