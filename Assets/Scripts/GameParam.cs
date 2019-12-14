using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameParam
{
	public static readonly float _PlayTime = 6.0f;

	public static float _CurrentTime = 0;

	public static void Init()
	{
		_CurrentTime = 0;
	}

	public static  void Update()
	{
		_CurrentTime += Time.deltaTime;
	}
}
