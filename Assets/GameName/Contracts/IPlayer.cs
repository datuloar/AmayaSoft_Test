using System;

public interface IPlayer : IUpdateLoop
{
    event Action<ICard> CardClicked;

    void DisableInput();
    void EnableInput();
}
