using UnityEngine;
using DG.Tweening;

public class CardMistakeEffect : MonoBehaviour, IEffect
{
    [SerializeField] private ScaleSettings _scaleSettings;
    [SerializeField] private SpriteRenderer _content;

    public void Play()
    {
        _content.transform.DORewind(false);

        _content.transform
            .DOShakePosition(_scaleSettings.Duration, _scaleSettings.Strength, _scaleSettings.Vibrato, 0)
            .SetEase(_scaleSettings.Ease);
    }
}
