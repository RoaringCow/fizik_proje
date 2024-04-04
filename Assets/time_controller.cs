using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class time_controller : MonoBehaviour
{

    public Sprite pause_texture, unpause_texture;
    public GameObject start_pause_button, time_scale_object;
    Image object_image;
    TMP_Text time_scale_text;
    float old_time_scale = 0.0f;
    bool paused_time_changed = false;
    float paused_time_scale_change = 0.0f;

    bool paused = false;
    void Start()
    {
        time_scale_text = time_scale_object.GetComponent<TMP_Text>();
        object_image = start_pause_button.GetComponent<Image>();
    }

    public void Pause_Unpause_Handler()
    {
        switch (paused)
        {
            case true:
                Unpause();
                break;

            case false:
                Pause();
                break;
        }
    }

    void Pause()
    {
        old_time_scale = Time.timeScale;
        Time.timeScale = 0.0f;
        time_scale_text.text = "Time scale: " + Time.timeScale;
        paused = true;
        object_image.sprite = unpause_texture;
        paused_time_scale_change = 0.0f;
        paused_time_changed = false;
    }
    void Unpause()
    {
        paused = false;
        object_image.sprite = pause_texture;
        if (paused_time_changed)
        {
            Time.timeScale = paused_time_scale_change;
        } else
        {
            Time.timeScale = old_time_scale;
        }
        time_scale_text.text = "Time scale: " + Time.timeScale;

    }

    public void MakeTimeSlower()
    {
        switch (paused)
        {
            case true:
                paused_time_scale_change -= 0.1f;
                paused_time_changed = true;
                time_scale_text.text = "Time scale: " + paused_time_scale_change;
                break;

            case false:
                // unity already prevents negative values.
                Time.timeScale -= 0.1f;
                time_scale_text.text = "Time scale: " + Time.timeScale;
                break;
        }
    }
    public void MakeTimeFaster()
    {
        switch (paused)
        {
            case true:
                paused_time_scale_change += 0.1f;
                paused_time_changed = true;
                time_scale_text.text = "Time scale: " + paused_time_scale_change;
                break;

            case false:
                Time.timeScale += 0.1f;
                time_scale_text.text = "Time scale: " + Time.timeScale;
                break;
        }
    }
}
