using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour, ICard
{
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private CardVictoryEffect _victoryEffect;
    [SerializeField] private CardMistakeEffect _mistakeEffect;
    [SerializeField] private float _showDuration;

    public string Id { get; private set; }

    private void Awake()
    {
        Hide();
    }

    public void Init(CardData data)
    {
        Id = data.Id;
        _icon.sprite = data.Sprite;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, _showDuration);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void PlayVictoryEffect()
    {
        _victoryEffect.Play();
    }

    public void PlayMistakeEffect()
    {
        _mistakeEffect.Play();
    }

    public void Destroy() => Destroy(gameObject);
}