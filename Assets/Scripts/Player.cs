using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	[SerializeField]
	GameObject _PlayerObject;

	[SerializeField]
	float _Speed = 20.0f;

	float _WidthEnd = 2.5f;
	float _HeightEnd = 4.8f;

	bool _IsPlay = false;

	private void Start()
	{
		_IsPlay = false;
		GameManager._OnGameStart += OnGameStart;
		GameManager._OnGameEnd += OnGameEnd;
	}

	void Update()
    {
		if (false == _IsPlay) return;

        if(Input.GetKey(KeyCode.RightArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(_Speed*Time.deltaTime,0,0));

			if(_PlayerObject.transform.localPosition.x> _WidthEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(_WidthEnd, pos.y,pos.z);
			}
		}
		 if(Input.GetKey(KeyCode.LeftArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(-_Speed * Time.deltaTime, 0, 0));

			if (_PlayerObject.transform.localPosition.x < -_WidthEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(-_WidthEnd, pos.y, pos.z);
			}
		}
		 if(Input.GetKey(KeyCode.UpArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(0,_Speed * Time.deltaTime, 0));

			if (_PlayerObject.transform.localPosition.y > _HeightEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(pos.x, _HeightEnd, pos.z);
			}
		}
		 if(Input.GetKey(KeyCode.DownArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(0, -_Speed * Time.deltaTime, 0));

			if (_PlayerObject.transform.localPosition.y < -_HeightEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(pos.x, -_HeightEnd, pos.z);
			}
		}

    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			GameManager._Instance.End();
		}
	}

	private void OnGameStart()
	{
		_IsPlay = true;
	}

	private void OnGameEnd(bool isclear)
	{

		if(isclear)
		{
			_PlayerObject.transform.DOMoveY(10,1.0f);
		}
		_IsPlay = false;
	}
}
