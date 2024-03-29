﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int m_totalTypesOfFish;
    private Fish.FishType m_targetFish;
    private int m_score;

    private void Start()
    {
        int a_rand = Random.Range(0, m_totalTypesOfFish);
        switch (a_rand)
        {
            case (int)Fish.FishType.BlueFish:
                m_targetFish = Fish.FishType.BlueFish;
                break;

            case (int)Fish.FishType.GreenFish:
                m_targetFish = Fish.FishType.GreenFish;
                break;

            case (int)Fish.FishType.OrangeFish:
                m_targetFish = Fish.FishType.OrangeFish;
                break;

            case (int)Fish.FishType.PinkFish:
                m_targetFish = Fish.FishType.PinkFish;
                break;
        }
        UIManager.Instance.UpdateFishType(m_targetFish);
    }

    public Fish.FishType GetTargetFish()
    {
        return m_targetFish;
    }

    public void IncreaseScore()
    {
        m_score++;
        UIManager.Instance.UpdateScore(m_score);
    }
}
