using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FinishWindow : MonoBehaviour, IFinishWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _restartGameButton;

    public event Action RestartGameButtonClick;

    private void Awake()
    {
        Close();
    }

    private void OnEnable()
    {
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClick);
    }

    private void OnDisable()
    {
        _restartGameButton.onClick.RemoveListener(OnRestartGameButtonClick);
    }

    private void OnRestartGameButtonClick()
    {
        Close();
        RestartGameButtonClick?.Invoke();
    }

    public void Close()
    {
        _canvasGroup.Close();
    }

    public void Open()
    {
        _canvasGroup.Open();
    }
}
