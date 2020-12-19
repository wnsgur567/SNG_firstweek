using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SoundManager : Singleton<_SoundManager>, IAwake
{
    _ResourcesLoader loader = null;
    public void __Awake()
    {
        loader = _ResourcesLoader.Instance;
    }
}
