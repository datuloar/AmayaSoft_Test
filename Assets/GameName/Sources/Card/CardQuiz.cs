using System.Collections.Generic;
using UnityEngine;

public class CardQuiz : ICardQuiz
{
    private readonly List<DataKit> _dataKits;
    private readonly ICardFactory _cardFactory;
    private readonly List<ICard> _desiredCardsHistory;

    private ICard _desiredCard;
    private IReadOnlyList<ICard> _playingCards;

    public CardQuiz(List<DataKit> dataKits)
    {
        _dataKits = dataKits;

        _cardFactory = new CardFactory();
        _desiredCardsHistory = new List<ICard>();
    }

    public IEnumerable<ICard> GeneratePlayingCards(int count)
    {
        ShuffleDataKits();
        _playingCards = _cardFactory.Create(null, count);

        for (int i = 0; i < count; i++)
        {
            var randomDataKitIndex = Random.Range(0, _dataKits.Count);

            _playingCards[i].Init(_dataKits[randomDataKitIndex].Cards[i]);
        }

        return _playingCards;
    }

    public ICard GenerateDesiredCard()
    {
        if (_playingCards == null)
            throw new System.Exception("Generate playing cards before use it");

        var randomIndex = Random.Range(0, _dataKits.Count);
        var card = _playingCards[randomIndex];

        try
        {
            if (_desiredCardsHistory.Contains(card))
                _desiredCard = GenerateDesiredCard();
            else
                _desiredCard = card;
        }
        catch (System.StackOverflowException)
        {
            _desiredCardsHistory.Clear();
            _desiredCard = GenerateDesiredCard();
        }

        return _desiredCard;
    }

    public bool IsDesiredCard(ICard card)
    {
        if (_desiredCard.Id == card.Id)
            return true;

        return false;
    }

    public void Clear()
    {
        _desiredCardsHistory.Clear();
        _playingCards = null;
    }

    private void ShuffleDataKits()
    {
        foreach (var data in _dataKits)
            data.Shuffle();
    }
}
