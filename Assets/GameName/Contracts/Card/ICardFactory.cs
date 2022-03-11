using System.Collections.Generic;
using UnityEngine;

public interface ICardFactory
{
    ICard Create(Vector3 position, Quaternion rotation);
    ICard Create(Transform parent);
    IReadOnlyList<ICard> Create(Transform parent, int count);
}
