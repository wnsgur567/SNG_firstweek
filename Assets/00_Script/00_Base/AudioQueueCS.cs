using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQueueCS : MonoBehaviour
{    
    public delegate void OnAudioInit(AudioSource _source);     
    public Queue<AudioSource> AudioQueue;   

    public void __AwakeInit()
    {
        AudioQueue = new Queue<AudioSource>();

        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (var item in sources)
        {
            item.playOnAwake = false;
            AudioQueue.Enqueue(item);
        }
    }

    public void SetAudio(AudioClip _clip, OnAudioInit _function)
    {
        if (AudioQueue.Count > 0)
        {
            AudioSource _source = AudioQueue.Dequeue();
            if (_source.isPlaying)
                Debug.LogErrorFormat("{0} : AudioSouce 컴포넌트 부족", this.name);

            _source.clip = _clip;
            _function(_source);
        }
        else
        {
            Debug.LogErrorFormat("{0} : AudioSouce 컴포넌트 부족", this.name);
        }

    }
    public void SetAudio(AudioClip _clip)
    {
        if (AudioQueue.Count > 0)
        {
            AudioSource _source = AudioQueue.Dequeue();
            if (_source.isPlaying)
                Debug.LogErrorFormat("{0} : AudioSouce 컴포넌트 부족", this.name);

            _source.clip = _clip;
            OnAudioInitilize_std(_source);
        }
        else
        {
            Debug.LogErrorFormat("{0} : AudioSouce 컴포넌트 부족", this.name);
        }        
    }

    private void OnAudioInitilize_std(AudioSource _source)
    {
        _source.loop = false;        
    }
}
