using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartEffect : MonoBehaviour
{

	[SerializeField]
	RectTransform Left;
	[SerializeField]
	RectTransform Right;
	[SerializeField]
	Image _GO;
	[SerializeField]
	Image _YOUAREDEAD;
	// Start is called before the first frame update
	void Start()
	{
		_GO.enabled = false;
		DOVirtual.DelayedCall(4.0f, () => { _GO.enabled = true;_GO.DOFade(0.0f,1.5f); });

		DOVirtual.DelayedCall(1.0f, () =>
		{
			_YOUAREDEAD.DOFade(0,0.5f);
			Left.DOLocalMoveX(-1000, 1.0f);
			Right.DOLocalMoveX(1000, 1.0f);
		});

	}

	// Update is called once per frame
	void Update()
	{

	}
}
