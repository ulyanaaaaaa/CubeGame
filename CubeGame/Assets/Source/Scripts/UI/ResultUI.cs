using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResultUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _gridCheсker.OnWin += WinText;
        _gridCheсker.OnLoose += LooseText;
    }

    private void WinText()
    {
        _text.text = "You win!";
        _text.color = Color.green;
        _cubeSpawner.GenerateRandomGrid();
    }

    private void LooseText()
    {
        _text.text = "You loose! Try again.";
        _text.color = Color.red;
    }
    
    private void OnDisable()
    {
        _gridCheсker.OnWin -= WinText;
        _gridCheсker.OnLoose -= LooseText;
    }
}
