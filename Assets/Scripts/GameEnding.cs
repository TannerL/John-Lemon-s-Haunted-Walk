using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    public float displayImageDuration = 1f;
    bool m_IsPlayerAtExit = false;
    float m_timer;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    bool m_IsPlayerCaught;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_timer / fadeDuration;
        if(m_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart) {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
