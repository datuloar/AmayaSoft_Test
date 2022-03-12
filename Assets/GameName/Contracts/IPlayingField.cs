using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayingField
{
    Task Insert(IEnumerable<ICard> card);
    void Create(LevelData levelData);
    void Clear();
}
