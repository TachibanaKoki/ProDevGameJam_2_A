using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{

	[SerializeField]
	Gradient _Gradient;


	[SerializeField]
	Image _Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		_Image.color = _Gradient.Evaluate(GameParam._CurrentTime / GameParam._PlayTime);
	}
}
