using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobManager : MonoBehaviour
{
    private static MobManager instance;

    public static MobManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<MobManager>();
            return instance;
        }
    }

    public UnityEvent<MobManager> OnSpawn, OnDestroy;

    private List<MobManager> mobs = new List<MobManager>();

    private void Awake()
    {
        instance = this;
    }

    public void OnSpawned(MobManager mobManager)
    {
        mobs.Add(mobManager);
        OnSpawn?.Invoke(mobManager);
    }

    public void OnDestroyed(MobManager mobManager)
    {
        if (mobs.Remove(mobManager))
        {
            OnDestroy?.Invoke(mobManager);
        }
    }
}
