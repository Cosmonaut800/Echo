using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
	[SerializeField] private AudioSource music;
	[SerializeField] private AudioSource[] sources;
	[SerializeField] private Slider musicSlider;

	private float defaultMusicVolume = 1.0f;
	private List<float> defaultVolumes = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
		defaultMusicVolume = music.volume;
		music.volume = musicSlider.value;
        for(int i = 0; i < sources.Length; i++)
		{
			defaultVolumes.Add(sources[i].volume);
		}
    }

	public void ChangeMusicVolume(float newVolume)
	{
		music.volume = defaultMusicVolume * newVolume;
	}

    public void ChangeVolume(float newVolume)
	{
		for(int i = 0; i < sources.Length; i++)
		{
			sources[i].volume = defaultMusicVolume * newVolume;
		}
	}
}
