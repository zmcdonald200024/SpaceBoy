﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static bool isQuitting;
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null && !isQuitting)
            {
                FindOrCreateInstance();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private static void FindOrCreateInstance()
    {
        T[] instanceArray = FindObjectsOfType<T>();
        if (instanceArray.Length == 0)
        {
            instance = new GameObject(typeof(T).Name).AddComponent<T>();
        }
        else if (instanceArray.Length == 1)
        {
            instance = instanceArray[0];
        }
        else if (instanceArray.Length > 1)
        {
            Debug.LogError($"<color=yellow>Multiple instances of the singleton [{typeof(T).Name}] exists.</color>");
            Debug.Break();
        }
        DontDestroyOnLoad(instance);
    }
}