using System.Collections.Generic;
using UnityEngine;

public class CardFactory : ICardFactory
{
    private const string CardPath = "Card/Card";

    public ICard Create(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(LoadTemplate(), position, rotation);
    }

    public ICard Create(Transform parent)
    {
        return Object.Instantiate(LoadTemplate(), parent);
    }

    public IReadOnlyList<ICard> Create(Transform parent, int count)
    {
        var cards = new List<ICard>();

        for (int i = 0; i < count; i++)
        {
            var card = Create(parent);
            cards.Add(card);
        }

        return cards;
    }

    private Card LoadTemplate()
    {
        return Resources.Load<Card>(CardPath);
    }
}
