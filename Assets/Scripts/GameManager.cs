using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager _Instance;

	public static System.Action _OnGameStart;
	public static System.Action<bool> _OnGameEnd;

	public enum State
	{
		Start,
		Play,
		End
	}

	public static State _State = State.Start; 

    void Start()
    {
		_State = State.Start;
		GameParam.Init();
		_Instance = this;
		DOVirtual.DelayedCall(4.0f, () =>
		{
			_State = State.Play;
			_OnGameStart?.Invoke();
			SoundManager.GetBGMSource()?.Play();
		});
	}

    void Update()
    {
		if(_State == State.Play)
		{
			GameParam.Update();

			if(GameParam._CurrentTime>= GameParam._PlayTime)
			{
				GameParam._CurrentTime = GameParam._PlayTime;

				End();
			}
		}

		Score.m_Score = 10000 * (int)(GameParam._CurrentTime / GameParam._PlayTime);
	}

	public void End()
	{
		if (_State == State.End) return;
		if(GameParam._CurrentTime == GameParam._PlayTime)
		{
			_OnGameEnd?.Invoke(true);
			SoundManager.PlaySE("ending");
			DOVirtual.DelayedCall(10.0f, () => { SceneManager.LoadSceneAsync(2); });
		}
		else
		{
			_OnGameEnd?.Invoke(false);
			SoundManager.PlaySE("tin1");
			DOVirtual.DelayedCall(2.0f, () => { SceneManager.LoadSceneAsync(2); });
		}

		_State = State.End;

		Score.m_Score = 10000 * (int)(GameParam._CurrentTime / GameParam._PlayTime);

	}
}
