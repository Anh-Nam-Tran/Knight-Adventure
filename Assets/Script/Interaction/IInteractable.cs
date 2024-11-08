using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void EnableInteraction();

    void DisableInteraction();

    Vector3 GetPosition();

    void Interact();
}

public interface IInteractable<T> : IInteractable
{
    T GetContext();

    void SetContext(T context);
}
