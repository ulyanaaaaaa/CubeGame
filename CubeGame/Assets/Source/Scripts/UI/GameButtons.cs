using System;
using UnityEngine;

[RequireComponent(typeof(Translator))]
public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _languageMenu;
    private Translator _translator;
    public Action OnPlay;
    public Action OnExit;

    private void Awake()
    {
        _translator = GetComponent<Translator>();
    }

    private void OnEnable()
    {
        OnPlay += () => _mainMenu.SetActive(false);
        OnExit += () => _mainMenu.SetActive(true);
        OnExit += () => _languageMenu.SetActive(false);
    }
    
    private void OnDisable()
    {
        OnPlay -= () => _mainMenu.SetActive(false);
        OnExit -= () => _mainMenu.SetActive(true);
        OnExit -= () => _languageMenu.SetActive(false);
    }

    public void Play()
    {
        OnPlay?.Invoke();
    }

    public void Exit()
    {
        OnExit?.Invoke();
    }

    public void OpenLanguageMenu()
    {
        _mainMenu.SetActive(false);
        _languageMenu.SetActive(true);
    }

    public void RussianClick()
    {
        _translator.ChangeLanguage(Language.Russian);
    }

    public void EnglishClick()
    {
        _translator.ChangeLanguage(Language.English);
    }

    public void TurkishClick()
    {
        _translator.ChangeLanguage(Language.Turkish);
    }
}
