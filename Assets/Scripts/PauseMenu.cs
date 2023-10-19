using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;

    bool isPaused = false;

    public InputAction pauseAction;

    [SerializeField] MonoBehaviour[] scriptsToPause;

    [SerializeField] AudioMixer audioMixer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            Resume();
        }
    }

    public void MasterVolumeUpdate(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SFXVolumeUpdate(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void Resume()
    {
        isPaused = !isPaused;
        panel.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;

            foreach (var item in scriptsToPause)
            {
                item.enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1.0f;

            foreach (var item in scriptsToPause)
            {
                item.enabled = true;
            }
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }
}
