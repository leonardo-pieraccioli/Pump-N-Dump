using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] public Canvas hud;
    [SerializeField] public Canvas gameover;
    [SerializeField] public Canvas win;
    [SerializeField] public CinemachineVirtualCamera cineVC;
    [SerializeField] public Pointer pointer;
    [SerializeField] private AudioClip stonks;
    [SerializeField] private AudioClip notStonks;
    void Start()
    {

    }

    public void ActivateGameOver()
    {
        AudioManager.Instance.PlaySound(notStonks);
        hud.gameObject.SetActive(false);
        gameover.gameObject.SetActive(true);
        StartCoroutine(ZoomOrtho());
        cineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 6;
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

    public void ActivateWin()
    {
        AudioManager.Instance.PlaySound(stonks);
        hud.gameObject.SetActive(false);
        win.gameObject.SetActive(true);
        StartCoroutine(ZoomOrtho());
        cineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 6;
        cineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 8;
        ObstacleSpawner.canSpawn = false;
        pointer._hasCollided = true;
        pointer._speed = 3;
        pointer._angle = +75;
    }
}
