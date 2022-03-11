using System;
using UnityEngine;

[Serializable]
public class PlayingFieldSettings
{
    [SerializeField] private float _delayBeforeInsert;
    [SerializeField] private float _offset;
    [SerializeField] private Vector2 _cellSize;

    public float DelayBeforeInsert => _delayBeforeInsert;
    public float Offset => _offset;
    public Vector2 CellSize => _cellSize;
}
