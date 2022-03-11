using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField, Min(1)] private int _rows;
    [SerializeField, Min(1)] private int _cols;

    public int Count => _rows * _cols;
    public int Rows => _rows;
    public int Cols => _cols;
}