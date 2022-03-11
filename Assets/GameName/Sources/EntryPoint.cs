using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private LevelData[] _levelDatas;
    [SerializeField] private List<DataKit> _dataKits;
    [SerializeField] private PlayingFieldSettings _playingFieldSettings;

    private Game _game;

    private void Awake()
    {
        var quiz = new CardQuiz(_dataKits);
        var player = new Player(_camera);
        var level = new Level(_levelDatas);
        var playingField = new GridField(_playingFieldSettings.Offset,
            _playingFieldSettings.CellSize, _playingFieldSettings.DelayBeforeInsert);

        _game = new Game(playingField, quiz, player, level, _viewport);
    }

    private void Start()
    {
        _game.Start();
    }

    private void Update()
    {
        _game.Tick(Time.time);
    }

    private void OnApplicationQuit()
    {
        _game.End();
    }
}
