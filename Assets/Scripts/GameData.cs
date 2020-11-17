using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData _i;

    public static GameData i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameData>("GameData"));
            return _i;
        }
    }
    
    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    private void Awake()
    {
        SoundManager.Initialize();
    }

}
