using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    public float displayImageDuration = 1f;
    bool m_IsPlayerAtExit;
    float m_timer;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        m_timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_timer / fadeDuration;
        if(m_timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
