using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(TextTranslator))]
public class ResultUI : MonoBehaviour
{
    [SerializeField] private GridCheсker _gridCheсker;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _lifeLenght = 3f;
    private TextMeshProUGUI _text;
    private Coroutine _tick;
    private TextTranslator _translator;

    private void Awake()
    {
        _translator = GetComponent<TextTranslator>();
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
        _text.text = _translator.Translate("good_result");
        _text.color = Color.green;
        _cubeSpawner.GenerateRandomGrid();
        _tick = StartCoroutine(LifeTick());
    }

    private void LooseText()
    {
        _text.color = Color.red;
        _text.text = _translator.Translate("bed_result");
        _tick = StartCoroutine(LifeTick());
    }

    private IEnumerator LifeTick()
    {
        yield return new WaitForSeconds(_lifeLenght);
        _text.text = " ";
    }
}
