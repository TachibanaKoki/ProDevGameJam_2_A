using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	GameObject _PlayerObject;

	[SerializeField]
	float _Speed = 20.0f;

	float _WidthEnd = 2.5f;

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(_Speed*Time.deltaTime,0,0));
			if(_PlayerObject.transform.localPosition.x> _WidthEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(_WidthEnd, pos.y,pos.z);
			}
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			_PlayerObject.transform.Translate(new Vector3(-_Speed * Time.deltaTime, 0, 0));
			if (_PlayerObject.transform.localPosition.x < -_WidthEnd)
			{
				Vector3 pos = _PlayerObject.transform.localPosition;
				_PlayerObject.transform.localPosition = new Vector3(-_WidthEnd, pos.y, pos.z);
			}
		}
    }
}
