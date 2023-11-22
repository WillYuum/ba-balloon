using System;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _untilLoseTimer;

    public T CreateConnection<T>()
    {
        switch (typeof(T))
        {
            case Type connectTimerType when connectTimerType == typeof(ConnectTimerWithUI):
                return (T)(object)new ConnectTimerWithUI()
                {
                    UpdateTimer = UpdateTimer
                };

            // Add more cases if needed for other types

            default:
                return default;
        }
    }


    private void UpdateTimer(float value)
    {
        _untilLoseTimer.text = value.ToString();
    }
}


public struct ConnectTimerWithUI
{
    public Action<float> UpdateTimer;
}