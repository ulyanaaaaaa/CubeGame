using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(TextTranslator))]
public class LevelNumber : MonoBehaviour
{
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private AdsWindow _adsWindow;
    [SerializeField] private BestScore _bestScore;
    [SerializeField] private GameButtons _gameButtons;
    private TextTranslator _translator;
    private TextMeshProUGUI _text;
    private int _number = 1;
    private int _lastNumber;
    
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
        _adsWindow.OnContinue += Continue;
        _gameButtons.OnPlay += FirstLevel;
    }
    
    private void OnDisable()
    {
        _translator.TranslateText -= UpdateLevel;
        _gridCheсker.OnWin -= NextLevel;
        _gridCheсker.OnLoose -= FirstLevel;
        _adsWindow.OnContinue -= Continue;
        _gameButtons.OnPlay -= FirstLevel;
    }

    private void NextLevel()
    {
        _number++;
        UpdateLevel();
    }

    private void FirstLevel()
    {
        _lastNumber = _number;
        _number = 1;
        UpdateLevel();
    }

    private void Continue()
    {
        _number = _lastNumber;
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        _text.text = _translator.Translate(_translator.Id) + "\n" + _number;
        _bestScore.CheckScore(_number);
    }
    
}
