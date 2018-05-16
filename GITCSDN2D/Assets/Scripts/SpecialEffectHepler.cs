using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//从代码中创建粒子实粒
//单例： 单例是一种设计模式，通过使用单例可以保证对象只会被实例化一次。我们的这个跟传统单例的实现有点不一样，但是原则是一样的。
public class SpecialEffectHepler : MonoBehaviour {

    public static SpecialEffectHepler instance;
    public ParticleSystem smokeEffect;
    public ParticleSystem fireEffect;

     void Awake()
    {
        //单项实例
        if(instance!=null)
        {
            Debug.LogError("SpecialEffectsHelper有多个实例");
        }
        instance = this;
    }

    //在指定位置创造爆炸
    public void Explosion(Vector3 position)
    {
        //smoke
        Instantiate(smokeEffect, position);

        //fire
        Instantiate(fireEffect, position);
    }

    //从prefab实例化粒子系统

    private ParticleSystem Instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity
            ) as ParticleSystem;

        //确保它会被销毁
        Destroy(
            newParticleSystem.gameObject,
            newParticleSystem.main.startLifetimeMultiplier
            );
        return newParticleSystem;
    }
}
