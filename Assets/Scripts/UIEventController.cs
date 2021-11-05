using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventController : MonoSingleton<UIEventController>
{
    public event Action<int> OnLivesChange;
    public event Action<int> onScoreChange;

    public void UpdateLives(int newLivesCount)
    {
        OnLivesChange?.Invoke(newLivesCount);
    }

    public void UpdateScore(int newScoreCount)
    {
        onScoreChange?.Invoke(newScoreCount);
    }

} 