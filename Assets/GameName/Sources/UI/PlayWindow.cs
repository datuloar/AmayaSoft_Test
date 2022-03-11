using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PlayWindow : MonoBehaviour, IPlayWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private DesiredIdPanel _desiredPanel;

    private void Awake()
    {
        Close();
    }

    public void Close()
    {
        _canvasGroup.Close();
    }

    public void Open()
    {
        _canvasGroup.Open();
    }

    public void RenderDesiredId(string id)
    {
        _desiredPanel.Show();
        _desiredPanel.Render(id);
    }
}
