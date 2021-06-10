using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatFish : MonoBehaviour
{
    [SerializeField] private float m_sharkHealth = 100;
    [SerializeField] private float m_damage = 5.0f;
    [Header("--Health--")]
    private Slider m_healthBarUI;

    [SerializeField]
    private Gradient m_healthGradient;

    [SerializeField]
    private float m_maxHealth = 100.0f;

    private Image m_healthFill;

    // Start is called before the first frame update
    void Start()
    {
        m_healthBarUI = UIManager.Instance.GetHealthBarUI();
        m_sharkHealth = m_maxHealth;
        m_healthBarUI.value = m_sharkHealth;

        //get the health fill image which is the first child 
        m_healthFill = m_healthBarUI.transform.GetChild(0).GetComponent<Image>();

        //set the color of the health fill image to the max health value by evaluating the gradient
        m_healthFill.color = m_healthGradient.Evaluate(m_healthBarUI.normalizedValue);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fish a_collidedFish = collision.gameObject.GetComponent<Fish>();
        if (a_collidedFish != null)
        {
            Fish.FishType a_type = a_collidedFish.GetFishType();

            if (a_type == GameManager.Instance.GetTargetFish())
            {
                //Ate Correct Fish
                GameManager.Instance.IncreaseScore();
            }
            else
            {
                //Ate Incorrect Fish
                m_sharkHealth -= m_damage;
                Debug.Log(m_sharkHealth);
                m_healthBarUI.value = m_sharkHealth;
                // change the color of the health fill image depending upon the health value 
                m_healthFill.color = m_healthGradient.Evaluate(m_healthBarUI.normalizedValue);

            }

            collision.gameObject.SetActive(false);
        }

    }

}
