using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum State
	{
		Start,
		Play,
		End
	}

	public State _State = State.Start; 

    void Start()
    {
    }

    void Update()
    {
		DOVirtual.DelayedCall(3.0f,()=> { _State = State.Play; });

		if(_State == State.Play)
		{
			GameParam.Update();

			if(GameParam._CurrentTime>= GameParam._PlayTime)
			{
				_State = State.End;
				SceneManager.LoadSceneAsync(2);
			}
		}
    }
}
