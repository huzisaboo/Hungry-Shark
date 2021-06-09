using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPool : MonoBehaviour
{
    [SerializeField]private float m_minY = -2.0f;
    [SerializeField]private float m_maxY = 2.0f;
    [SerializeField]private int m_poolSize;
    [SerializeField]private float m_maxSpawnTime;
    [SerializeField]private GameObject[] m_fishPrefabArray;
    private GameObject[] m_fishPool;
    private int m_currentFishIndex = 0;
    private float m_spawnTimer = 0.0f;
    private float m_yPosValue;
    private float m_xPosValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_fishPool = new GameObject[m_poolSize];
        for(int i =0,j = 0;i<m_fishPool.Length;i++,j++)
        {
            if(j >= m_fishPrefabArray.Length)
            {
                j = 0;
            }
            m_fishPool[i] = Instantiate(m_fishPrefabArray[j], this.transform);
            
            if(m_xPosValue == 0)    //Initialize x position value for spawning fishes
            {
                m_xPosValue = m_fishPool[i].transform.position.x;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer += Time.deltaTime;
        if(m_spawnTimer > m_maxSpawnTime)
        {
            m_spawnTimer = 0;
            EnterFish(m_currentFishIndex);
            m_currentFishIndex++;
            if(m_currentFishIndex >= m_poolSize)
            {
                m_currentFishIndex = 0;
            }
        }
    }

    private void EnterFish(int p_fishIndex)
    {
        m_yPosValue = Random.Range(m_minY, m_maxY);
        m_fishPool[p_fishIndex].transform.position = new Vector2(m_xPosValue, m_yPosValue);
    }
}
