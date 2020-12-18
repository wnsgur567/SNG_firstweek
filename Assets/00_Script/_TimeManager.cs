using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// https://www.youtube.com/watch?v=tChb3CryqL8&ab_channel=DevGomDol
public class _TimeManager : MonoBehaviour
{
    UnityWebRequest request;
    public string url = "";
    public DateTime startTime; // 게임 시작 타임
    public DateTime now;
    public bool isChecking;

    private void Awake()
    {
        request = new UnityWebRequest();
        isChecking = true;

        StartCoroutine(GetStartTime());
        StartCoroutine(WebChk());
    }

    IEnumerator GetStartTime()
    {
        request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string date = request.GetResponseHeader("date");
            //Debug.Log(date);    // universal

            startTime = DateTime.Parse(date); // 한국 현재 시각
        }
    }

    IEnumerator WebChk()
    {         
        while (isChecking)
        {
            request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();
            if(request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");
                //Debug.Log(date);    // universal

                now = DateTime.Parse(date); // 한국 현재 시각
                //Debug.Log(now);
            }
            
            // 갱신 시간 유예
            yield return new WaitForSeconds(0.33f);
        }
    }
}
