using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/Card", order = 51)]
public class CardData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _sprite;

    public string Id => _id;
    public Sprite Sprite => _sprite;
}