public interface ILevel
{
    LevelData CurrentLevel { get; }
    bool CanNext { get; }

    void GoNext();
    void Reset();
}
