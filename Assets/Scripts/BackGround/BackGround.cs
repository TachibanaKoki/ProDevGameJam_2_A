using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
	[SerializeField]
	Gradient _Gradient;

	[SerializeField]
	SpriteRenderer _Image;

	[SerializeField]
	Transform _Clouds;

	SpriteRenderer[] renderers;

    // Start is called before the first frame update
    void Start()
    {
		DOVirtual.DelayedCall(4.0f, () => { Clouds(); });
		renderers = _Clouds.GetComponentsInChildren<SpriteRenderer>();
	}
	private void Clouds()
	{
		bool isRight = Random.Range(0,2)==0;
		if (isRight)
		{
			_Clouds.localPosition = new Vector3(1, 3.5f, -0.5f);
			_Clouds.DOMove(new Vector3(12, -6.0f, -0.5f), 10.0f).SetEase(Ease.Linear).onComplete += Clouds;
		}
		else
		{
			_Clouds.localPosition = new Vector3(12, 3.5f, -0.5f);
			_Clouds.DOMove(new Vector3(1, -6.0f, -0.5f), 10.0f).SetEase(Ease.Linear).onComplete += Clouds;
		}
	}
	// Update is called once per frame
	void Update()
	{
		Color col = _Gradient.Evaluate(GameParam._CurrentTime / GameParam._PlayTime);
		_Image.color = col;

		//col = col + Color.gray;
		//renderers[0].color = col;
		//renderers[1].color = col;
	}
}
