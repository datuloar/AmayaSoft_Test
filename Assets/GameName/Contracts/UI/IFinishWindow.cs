using System;

public interface IFinishWindow : IWindow
{
    event Action RestartGameButtonClick;
}
