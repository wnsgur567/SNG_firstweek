using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Awake(only) -> OnEnable -> Start(only) -> 
// Fixed_Update -> Update -> Late_Update
// Rendering
// OnDisable 
// OnDestroy


public interface IAwake
{
    void __Awake();
}
public interface IStart
{
    void __Start();
}
public interface IOnEnable
{
    void __OnEnable();
}

public interface IUpdate
{
    void __Update();
}
public interface ILateUpdate
{
    void __LateUpdate();
}
public interface IOnDisable
{
    void __OnDisable();
}
