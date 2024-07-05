using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BestScore : MonoBehaviour
{
    private int _bestScore = 1;
    private TextMeshProUGUI _text;
    private SaveService _saveService;
    private string _id = "best_score";

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    private void Start()
    {
        _saveService = new SaveService();

        if (!_saveService.Exists(_id))
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
        BestScoreSaveData data = new BestScoreSaveData();
        data.BestScore = _bestScore;
        _saveService.Save(_id, data);
    }

    private void Load()
    {
        _saveService.Load<BestScoreSaveData>(_id, data =>
        {
            _bestScore = data.BestScore;
        });
    }

    private void UpdateBestScore()
    {
        _text.text = "Best score: " +  _bestScore;
        Save();
    }
}

public class BestScoreSaveData
{
    public int BestScore; 
}
