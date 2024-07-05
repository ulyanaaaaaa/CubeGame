using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResultUI : MonoBehaviour
{
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _lifeLenght = 3f;
    private TextMeshProUGUI _text;
    private Coroutine _tick;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _gridCheсker.OnWin += WinText;
        _gridCheсker.OnLoose += LooseText;
    }
    
    private void OnDisable()
    {
        StopCoroutine(LifeTick());
        _gridCheсker.OnWin -= WinText;
        _gridCheсker.OnLoose -= LooseText;
    }

    private void WinText()
    {
        _text.text = "You win!";
        _text.color = Color.green;
        _cubeSpawner.GenerateRandomGrid();
        _tick = StartCoroutine(LifeTick());
    }

    private void LooseText()
    {
        _text.text = "You loose! Try again.";
        _text.color = Color.red;
        _tick = StartCoroutine(LifeTick());
    }

    private IEnumerator LifeTick()
    {
        yield return new WaitForSeconds(_lifeLenght);
        _text.text = " ";
    }
}
