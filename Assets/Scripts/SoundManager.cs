using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private static SoundManager _Instance;

	[SerializeField]
	AudioSource _BGMSource;

	[SerializeField]
	AudioSource _SESource;

	[SerializeField]
	AudioClip[] _AudioClips;

	public static void PlaySE(string clipName)
	{
		if (_Instance == null) return;
		AudioClip[] clips = _Instance._AudioClips;
		for (int i = 0;i< clips.Length;i++)
		{
			if (clips[i].name == clipName)
			{
				_Instance._SESource.PlayOneShot(clips[i]);
				return;
			}
		}
	}

	public static AudioSource GetBGMSource()
	{
		if (_Instance == null) return null;
		return _Instance._BGMSource;
	}

	// Start is called before the first frame update
	void Awake()
    {
		_Instance = this;
    }



}
