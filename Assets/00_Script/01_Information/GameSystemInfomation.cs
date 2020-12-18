using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Option_Graphic
{
    public int quality_level;

    public int resolution_width;
    public int resoulution_height;

    public bool isShowing_Effect;
    public bool isShowing_TouchEffect;    
}
public struct Option_Sound
{
    public int sound_level;
    public bool isPlaying_Effect;
    public bool isPlaying_UIEffect;
    public bool isPlaying_BGM;
}


public class GameSystemInfomation : Singleton<GameSystemInfomation>, IAwake
{
    public Option_Graphic option_graphic;
    public Option_Sound option_sound;

    public void __Awake()
    {
        
    }
}
