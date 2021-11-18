using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    public float maxVolume = 0;
    public float minVolume = -80;
    public AudioMixer mixer;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        float value = PlayerPrefs.GetFloat("MVolume",100);
        textMesh.text = value + "%";

        value = Remap(value, 0, 100, minVolume, maxVolume);
        mixer.SetFloat("MasterVolume", value);
    }

    public void VolumeChange(float amount = 0.1f)
    {
        float newValue = PlayerPrefs.GetFloat("MVolume",100) + amount;
        newValue = newValue > 100 ? 100 : newValue;
        newValue = newValue < 0 ? 0 : newValue;

        textMesh.text = newValue + "%";
        PlayerPrefs.SetFloat("MVolume", newValue);

        newValue = Remap(newValue, 0, 100, minVolume, maxVolume);
        mixer.SetFloat("MasterVolume", newValue);
    }
    
    private float Remap(float value, float baseMin, float baseMax, float targetMin, float targetMax)
    {
        value -= baseMin;
        baseMax -= baseMin;
        value /= baseMax;

        targetMax -= targetMin;
        value *= targetMax;
        value += targetMin;

        return value;
    }


}
