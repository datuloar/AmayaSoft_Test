using System;
using UnityEngine;

public class Player : IPlayer
{
    private readonly Camera _inputCamera;

    private bool _inputWork;

    public Player(Camera inputCamera)
    {
        _inputCamera = inputCamera;
    }

    public event Action<ICard> CardClicked;

    public void DisableInput() => _inputWork = false;

    public void EnableInput() => _inputWork = true;

    public void Tick(float time)
    {
        if (Input.GetMouseButtonDown(0) && _inputWork)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out ICard card))
                    CardClicked?.Invoke(card);
        }
    }
}
