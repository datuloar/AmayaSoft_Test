using TMPro;
using UnityEngine;
using DG.Tweening;

public class DesiredIdPanel : MonoBehaviour, IPanel
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _desiredIdLabel;
    [SerializeField] private float _showDuration;

    private void Awake()
    {
        Hide();
    }

    public void Render(string id)
    {
        _desiredIdLabel.text = $"Õ¿…ƒ» : {id}";
    }

    public void Show()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _showDuration);
    }

    public void Hide()
    {
        _canvasGroup.Close();
    }
}
