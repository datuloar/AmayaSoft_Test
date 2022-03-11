using System.Collections.Generic;

public interface ICardQuiz
{
    void Clear();
    ICard GenerateDesiredCard();
    IEnumerable<ICard> GeneratePlayingCards(int count);
    bool IsDesiredCard(ICard card);
}