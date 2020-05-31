using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent(typeof(T)) as T;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            enabled = false;
        }
    }
}
