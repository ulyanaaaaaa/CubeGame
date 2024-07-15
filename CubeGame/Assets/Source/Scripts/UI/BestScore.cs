using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(TextTranslator))]
public class BestScore : MonoBehaviour
{
    private int _bestScore = 1;
    private TextMeshProUGUI _text;
    private SaveService _saveService;
    private TextTranslator _translator;
    private string _id = "best_score";

    private void Awake()
    {
        _translator = GetComponent<TextTranslator>();
        _text = GetComponent<TextMeshProUGUI>();
        _saveService = new SaveService();
    }
    
    private void Start()
    {
        _translator.TranslateText += UpdateBestScore;
        
        if (!PlayerPrefs.HasKey(_id))
        {
            _bestScore = 1;
            Save();
        }
        else
            Load();

        UpdateBestScore();
    }
    
    public void CheckScore(int score)
    {
        if (_bestScore < score)
        {
            _bestScore = score;
            UpdateBestScore();
        }
    }
    
    private void Save()
    {
        //BestScoreSaveData data = new BestScoreSaveData();
        //data.BestScore = _bestScore;
        //_saveService.Save(_id, data);
        PlayerPrefs.SetInt(_id, _bestScore);
    }

    private void Load()
    {
        //.Load<BestScoreSaveData>(_id, data =>
        //{
            //_bestScore = data.BestScore;
        //});
        _bestScore = PlayerPrefs.GetInt(_id);
    }

    private void UpdateBestScore()
    {
        _text.text = _translator.Translate(_id) + "\n" + _bestScore;
        Save();
    }
}

public class BestScoreSaveData
{
    public int BestScore; 
}
