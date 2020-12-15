using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Managers : Singleton<_Managers>
{   

    override protected void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
