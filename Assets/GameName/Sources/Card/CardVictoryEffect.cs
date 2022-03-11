using DG.Tweening;
using UnityEngine;

public class CardVictoryEffect : MonoBehaviour, IEffect
{
    [SerializeField] private ParticleSystem _template;
    [SerializeField] private ScaleSettings _scaleSettings;

    public void Play()
    {
        var particle = Instantiate(_template, transform.position, Quaternion.identity);
        particle.Play();

        transform.DOScale(Vector3.zero, _scaleSettings.Duration);
    }
}
