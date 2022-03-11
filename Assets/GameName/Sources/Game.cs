using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public sealed class Game : IUpdateLoop
{
    private const float DelayBetweenLevelChange = 0.2f;

    private readonly IViewport _viewport;
    private readonly IPlayer _player;
    private readonly ILevel _level;
    private readonly IPlayingField _playingField;
    private readonly ICardQuiz _quiz;

    public Game(IPlayingField playingField, ICardQuiz quiz, IPlayer player, ILevel level, IViewport viewport)
    {
        _level = level;
        _player = player;
        _viewport = viewport;
        _playingField = playingField;
        _quiz = quiz;

        _player.CardClicked += OnCardClicked;
    }

    public void Start()
    {
        _viewport.GetPlayWindow().Open();

        _player.EnableInput();

        StartQuiz();
    }

    public void Tick(float time)
    {
        _player.Tick(time);
    }

    public void End()
    {
        _player.CardClicked -= OnCardClicked;
    }

    private void StartQuiz()
    {
        IEnumerable<ICard> playingCards = _quiz.GeneratePlayingCards(_level.CurrentLevel.Count);
        ICard desiredCard = _quiz.GenerateDesiredCard();

        _viewport.GetPlayWindow().RenderDesiredId(desiredCard.Id);
        FillPlayingField(playingCards);
    }

    private void FillPlayingField(IEnumerable<ICard> playingCards)
    {
        _playingField.Create(_level.CurrentLevel);
        _playingField.Insert(playingCards);
    }

    private async void OnCardClicked(ICard card)
    {
        if (_quiz.IsDesiredCard(card))
        {
            card.PlayVictoryEffect();

            await Task.Delay(TimeSpan.FromSeconds(DelayBetweenLevelChange));

            if (_level.CanNext)
            {
                _level.GoNext();
                _playingField.Clear();

                StartQuiz();
            }
            else
            {
                _player.DisableInput();
                _viewport.GetPlayWindow().Close();
                _viewport.GetFinishWindow().Open();
                _viewport.GetFinishWindow().RestartGameButtonClick += OnRestartGameButtonClick;
            }
        }
        else
        {
            card.PlayMistakeEffect();
        }
    }

    private void OnRestartGameButtonClick()
    {
        _playingField.Clear();
        _quiz.Clear();
        _level.Reset();

        _viewport.GetLoadingWindow().Load(Start);
        _viewport.GetFinishWindow().RestartGameButtonClick -= OnRestartGameButtonClick;
    }
}
