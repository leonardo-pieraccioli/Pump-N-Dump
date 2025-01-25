using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] public Canvas hud;
    [SerializeField] public Canvas gameover;
    [SerializeField] public CinemachineVirtualCamera cineVC;
    [SerializeField] public Pointer pointer;
    void Start()
    {

    }

    public void ActivateGameOver()
    {
        hud.gameObject.SetActive(false);
        gameover.gameObject.SetActive(true);
        StartCoroutine(ZoomOrtho());
        cineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 8;
        cineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 8;
        pointer._hasCollided = true;
        pointer._speed = 3;
        pointer._angle = -75;
    }

    IEnumerator ZoomOrtho()
    {
        float timer = 0;
        while (timer < 1)
        {
            cineVC.m_Lens.OrthographicSize = Mathf.Lerp(11.61f, 2, timer * 4);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void Bailout()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    // Update is called once per frame
    public void Suicide()
    {
        Application.Quit();
    }
}
