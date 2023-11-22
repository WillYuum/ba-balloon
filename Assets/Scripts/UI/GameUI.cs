using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using System;

public class GameUI : MonoBehaviourSingleton<GameUI>
{
    [SerializeField] private GameScreen _gameScreen;

    public T GetScreen<T>()
    {
        switch (typeof(T))
        {
            case Type gameScreenType when gameScreenType == typeof(GameScreen):
                return (T)(object)_gameScreen;

            // Add more cases if needed for other types

            default:
                return default;
        }
    }
}
