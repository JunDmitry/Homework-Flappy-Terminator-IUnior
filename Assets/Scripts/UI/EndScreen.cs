using System;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Open()
    {
        CanvasGroup.interactable = true;
        CanvasGroup.alpha = 1f;
    }

    public override void Close()
    {
        CanvasGroup.interactable = false;
        CanvasGroup.alpha = 0f;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}