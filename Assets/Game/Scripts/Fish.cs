using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public enum FishType
    {
        BlueFish,
        GreenFish,
        OrangeFish,
        PinkFish
    }

    [SerializeField] private FishType m_FishType;
    
    private FishType GetFishType()
    {
        return m_FishType;
    }
}
