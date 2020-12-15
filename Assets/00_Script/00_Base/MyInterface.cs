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
    public abstract void __Awake();
}
public interface IStart
{
    public abstract void __Start();
}
public interface IOnEnable
{
    public abstract void __OnEnable();
}

public interface IUpdate
{
    public abstract void __Update();
}
public interface ILateUpdate
{
    public abstract void __LateUpdate();
}
public interface IOnDisable
{
    public abstract void __OnDisable();
}
