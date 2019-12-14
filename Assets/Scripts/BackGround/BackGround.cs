using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{

	[SerializeField]
	Color _StartColor = Color.blue;
	[SerializeField]
	Color _EndColor = Color.black;


	[SerializeField]
	Image _Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		_Image.color = Color.Lerp(_StartColor, _EndColor,GameParam._CurrentTime/GameParam._PlayTime);
	}
}
