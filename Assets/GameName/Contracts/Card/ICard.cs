using UnityEngine;

public interface ICard
{
    string Id { get; }
    Transform transform { get; }

    void Hide();
    void Show();
    void Init(CardData data);
    void PlayMistakeEffect();
    void PlayVictoryEffect();
    void Destroy();
}
