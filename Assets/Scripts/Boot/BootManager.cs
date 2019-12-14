using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BootManager : MonoBehaviour
{
	[SerializeField]
	Button _StartButton;

	AsyncOperation _AsyncOperation;
    // Start is called before the first frame update
    void Start()
    {
		_StartButton.onClick.AddListener(OnStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnStart()
	{
		if (_AsyncOperation != null) return;
		_AsyncOperation = SceneManager.LoadSceneAsync(1);
	}
}
