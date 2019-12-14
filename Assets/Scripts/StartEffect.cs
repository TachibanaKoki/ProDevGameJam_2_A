using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartEffect : MonoBehaviour
{

	[SerializeField]
	RectTransform Left;
	[SerializeField]
	RectTransform Right;
	// Start is called before the first frame update
	void Start()
	{
		DOVirtual.DelayedCall(1.0f, () =>
		{
			Left.DOLocalMoveX(-1000, 1.0f);
			Right.DOLocalMoveX(1000, 1.0f);
		});

	}

	// Update is called once per frame
	void Update()
	{

	}
}
