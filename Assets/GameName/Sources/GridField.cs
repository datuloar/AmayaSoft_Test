using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;

public class GridField : IPlayingField
{
    private readonly float _offset;
    private readonly Vector2 _cellSize;
    private readonly float _delayBeforeInsert;

    private Queue<Vector2> _cellsQueue;
    private List<ICard> _insertedCards;

    public GridField(float offset, Vector2 cellSize, float delayBeforeInsert)
    {
        _offset = offset;
        _cellSize = cellSize;
        _delayBeforeInsert = delayBeforeInsert;

        _insertedCards = new List<ICard>();
    }

    public void Create(LevelData levelData)
    {
        var cellsPosition = new Vector2[levelData.Count];

        float width = levelData.Cols * _offset * _cellSize.x;
        float height = levelData.Rows * _offset * _cellSize.y;

        for (int y = 0, offset = 0; y < levelData.Rows; y++, offset += levelData.Cols)
        {
            for (int x = 0; x < levelData.Cols; x++)
            {
                cellsPosition[offset + x] = new Vector2(
                       x * _offset - width / levelData.Cols,
                       y * _offset + height / levelData.Rows - levelData.Rows * _cellSize.y);
            }
        }

        _cellsQueue = new Queue<Vector2>(cellsPosition);
    }

    public async Task Insert(IEnumerable<ICard> cards)
    {
        if (_cellsQueue == null)
            throw new Exception("Сreate fields before insert");

        await Task.Delay(TimeSpan.FromSeconds(_delayBeforeInsert));

        foreach (var card in cards)
        {
            card.transform.localPosition = _cellsQueue.Dequeue();
            card.Show();
            _insertedCards.Add(card);

            await Task.Delay(TimeSpan.FromSeconds(_delayBeforeInsert));
        }
    }

    public void Clear()
    {
        _cellsQueue = null;

        foreach (var insertedCard in _insertedCards)
            insertedCard.Destroy();

        _insertedCards.Clear();
    }
}