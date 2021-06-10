using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    [SerializeField] private float m_speed = 10.0f;
    [SerializeField] private float m_movementDeadZoneFactor = 0.02f;
    private Vector2 m_mousePosition;
    private Camera m_mainCamera;
    //Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        m_mousePosition = Input.mousePosition;
        Vector2 a_view = m_mainCamera.ScreenToViewportPoint(m_mousePosition);

        if ((a_view.x > 0 && a_view.x < 1) && (a_view.y > 0 && a_view.y < 1))
        {   //Mouse within game viewport

            Vector3 a_movePosition = m_mainCamera.ScreenToWorldPoint(new Vector3(m_mousePosition.x, m_mousePosition.y,0));
            Vector2 a_directionVector = (a_movePosition - transform.position).normalized;
            float a_dot = Vector2.Dot(transform.up, a_directionVector);
            if (a_dot > m_movementDeadZoneFactor)
            {
                transform.position += transform.up * m_speed * Time.deltaTime;
            }
            else if(a_dot < -m_movementDeadZoneFactor)
            {
                transform.position += (-transform.up) * m_speed * Time.deltaTime;
            }

        }


    }

 }
