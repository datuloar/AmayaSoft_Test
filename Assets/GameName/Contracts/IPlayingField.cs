using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayingField
{
    Task Insert(IEnumerable<ICard> card);
    public void Create(LevelData levelData);
    void Clear();
}
