using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//注意: 这种方法对于对于本教程这种小游戏够用了。
//但是对于一个大型游戏，它可能有点太轻量级了，
//所以你管理上百个音效的时候会很不方便。

public class SoundEffectsHelper : MonoBehaviour
{
    public static SoundEffectsHelper instance;
    public AudioClip explosionSound;
    public AudioClip playerShotSound;

    void Awake()
    {
        //单例
        if (instance != null)
        {
            Debug.LogError("SoundEffectsHelper 有多个实例");
        }
        instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayShotSound()
    {
        MakeSound(playerShotSound);
    }

    //播放给定的声音
    private void MakeSound(AudioClip originalClip)
    {
        //因为不是3D音频，所以位置不关键
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
