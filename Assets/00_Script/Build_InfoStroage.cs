using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct BuildInformation
{
    public int width;   
    public int height;
    public float time;  // 소요 시간
    public int gold;    // 요구 금액    
    public int level;   // 요구 레벨

    public void Clear()
    {
        width = 0;
        height = 0;
        time = 0f;
        gold = 0;
        level = 0;
    }
}
public class Build_InfoStroage: MonoBehaviour
{    
    public BuildInformation stroage;

    public void __Init(int width, int height, float time ,int gold)
    {
        stroage.width = width;
        stroage.height = height;
        stroage.time = time;
        stroage.gold = gold;
    }       
}
