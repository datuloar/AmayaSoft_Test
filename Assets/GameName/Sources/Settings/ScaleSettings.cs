using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class ScaleSettings
{
    [SerializeField] private float _duration;
    [SerializeField] private int _vibrato;
    [SerializeField] private Vector3 _strength;
    [SerializeField] private Ease _ease = Ease.InBounce;

    public float Duration => _duration;
    public int Vibrato => _vibrato;
    public Vector3 Strength => _strength;
    public Ease Ease => _ease;
}
