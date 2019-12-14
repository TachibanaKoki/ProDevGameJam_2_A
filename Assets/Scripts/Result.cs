using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private SceneObject nextScene;

    private int resultScore = 0;
    void Start()
    {
        //
        resultScore = Score.m_Score;


        //背景の変更
    }

    // つかわない？
    void Update()
    {
        
    }

    public void ToNext()
    {
        SceneManager.LoadScene( nextScene );
    }
}
