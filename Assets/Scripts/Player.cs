﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	[SerializeField]
	GameObject _PlayerObject;

	[SerializeField]
	SpriteRenderer _Start;
	[SerializeField]
	Sprite _Kanoke;

	[SerializeField]
	Transform _Goal;

	[Header("フェイシャル")]
	[SerializeField]
	SpriteRenderer _Faice;
	[SerializeField]
	Sprite _Died;
	[SerializeField]
	Sprite _Defult;
	[SerializeField]
	Sprite _Happy;

	[Header("パラメーター")]
	[SerializeField]
	float _Speed = 20.0f;

	float _WidthEnd = 2.5f;
	float _HeightEnd = 4.8f;

	bool _IsPlay = false;


	private void Awake()
	{
		_IsPlay = false;
		GameManager._OnGameStart += OnGameStart;
		GameManager._OnGameEnd += OnGameEnd;
		_PlayerObject.SetActive(false);
		DOVirtual.DelayedCall(2.0f, () => {
			_Start.transform.DOMoveY(-4.5f,1.0f).OnComplete(()=> 
			{
				DOVirtual.DelayedCall(0.5f,()=> {
					_Start.sprite = _Kanoke;
					_PlayerObject.SetActive(true);
					DOVirtual.DelayedCall(0.5f, () =>
					{
						_Start.transform.DOMoveY(-6.0f, 1.0f);
					});
					});
			});
		});

	}

	void Update()
	{
		if (false == _IsPlay) return;

		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.x < Screen.width * 0.4f)
			{
				MoveLeft();
			}
			else if (Input.mousePosition.x > Screen.width - (Screen.width * 0.4f))
			{
				MoveRight();
			}
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			MoveRight();
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			MoveLeft();
		}
		var rig = _PlayerObject.transform.GetComponent<Rigidbody2D>();
		_PlayerObject.transform.rotation = Quaternion.Euler(0,0,-rig.velocity.x*2);
	}

	private void MoveRight()
	{
		_PlayerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(_Speed * Time.deltaTime, 0, 0), ForceMode2D.Impulse);

		if (_PlayerObject.transform.localPosition.x > _WidthEnd)
		{
			Vector3 pos = _PlayerObject.transform.localPosition;
			_PlayerObject.transform.localPosition = new Vector3(_WidthEnd, pos.y, pos.z);
		}
	}

	private void MoveLeft()
	{
		_PlayerObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-_Speed * Time.deltaTime, 0, 0),ForceMode2D.Impulse);

		if (_PlayerObject.transform.localPosition.x < -_WidthEnd)
		{
			Vector3 pos = _PlayerObject.transform.localPosition;
			_PlayerObject.transform.localPosition = new Vector3(-_WidthEnd, pos.y, pos.z);
		}
	}

	private void OnGameStart()
	{
		_IsPlay = true;
		_Faice.sprite = _Defult;
	}

	private void OnGameEnd(bool isclear)
	{
		if (isclear)
		{
			DOVirtual.DelayedCall(1.0f, () => { _PlayerObject.transform.DOMoveY(10, 1.0f); });
			_Goal.DOMoveY(4.1f,1.0f);
			_Faice.sprite = _Happy;
		}
		else if(_PlayerObject!=null)
		{
			var renderers =  _PlayerObject.GetComponentsInChildren<SpriteRenderer>();
			foreach(var obj in renderers)
			{
				obj.DOFade(0,1.0f);
			}
			_Faice.sprite = _Died;
		}
		_IsPlay = false;
	}
}
