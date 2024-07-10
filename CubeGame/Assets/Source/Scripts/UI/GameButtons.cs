using System;
using UnityEngine;

[RequireComponent(typeof(Translator))]
public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _languageMenu;
    [SerializeField] private GameObject _failWindow;
    private Translator _translator;
    public Action OnPlay;
    public Action OnExit;

    private void Awake()
    {
        _translator = GetComponent<Translator>();
    }

    public void Play()
    {
        _mainMenu.SetActive(false);
        OnPlay?.Invoke();
    }

    public void Exit()
    {
        _mainMenu.SetActive(true);
        _languageMenu.SetActive(false);
        _failWindow.SetActive(false);
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
