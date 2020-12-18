﻿using UnityEngine;

// https://202psj.tistory.com/1247 [알레폰드의 IT 이모저모]
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj;
                obj = GameObject.Find(typeof(T).Name);
                if (obj == null)
                {
                    obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
                else
                {
                    instance = obj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    protected void Awake()
    {
        this.transform.position = new Vector3(-1000, -1000, -1000);        
    }
}