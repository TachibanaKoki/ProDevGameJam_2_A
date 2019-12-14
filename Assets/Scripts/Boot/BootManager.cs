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
		_StartButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -387+(Mathf.Sin(Time.time*2)*20.0f),0);
    }

	private void OnStart()
	{
		if (_AsyncOperation != null) return;
		_AsyncOperation = SceneManager.LoadSceneAsync(1);
	}
}
