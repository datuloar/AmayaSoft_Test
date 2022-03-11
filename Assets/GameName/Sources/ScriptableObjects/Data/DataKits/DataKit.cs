using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataKit", menuName = "Data/Kit", order = 51)]
public class DataKit : ScriptableObject
{
    [SerializeField] private List<CardData> _cards;

    public IReadOnlyList<CardData> Cards => _cards;

    public void Shuffle()
    {
        _cards.Shuffle();
    }
}
