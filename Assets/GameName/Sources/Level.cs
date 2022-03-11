public class Level : ILevel
{
    private readonly LevelData[] _levels;

    private int _currentLevelIndex;

    public Level(LevelData[] levels)
    {
        _levels = levels;
    }

    public LevelData CurrentLevel => _levels[_currentLevelIndex];

    public bool CanNext => _currentLevelIndex + 1 < _levels.Length;

    public void GoNext() => _currentLevelIndex++;

    public void Reset()
    {
        _currentLevelIndex = 0;
    }
}
