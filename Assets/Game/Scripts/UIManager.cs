using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Slider m_healthBarUI;
    [SerializeField] private Text m_fishTypeText;
    [SerializeField] private Text m_scoreText;
    // Start is called before the first frame update
    

    public Slider GetHealthBarUI()
    {
        return m_healthBarUI;
    }

    public void UpdateScore(int p_score)
    {
        m_scoreText.text = "Score: " + p_score.ToString();
    }

    public void UpdateFishType(Fish.FishType p_fishType)
    {
        m_fishTypeText.text = p_fishType.ToString();
    }

}
