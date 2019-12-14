﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private SceneObject nextScene;

    private int resultScore = 0;

    public List<GameObject> ResultImageList;
    void Start()
    {
        //
        resultScore = Score.m_Score;


        //背景の変更
        if(resultScore >= 10000)
        {
            ResultImageList[5].SetActive(true);
        }
        else if(resultScore >= 8000)
        {
            ResultImageList[4].SetActive(true);
        }
        else if(resultScore >= 6000)
        {
             ResultImageList[3].SetActive(true);
        }
        else if(resultScore >= 4000)
        {
             ResultImageList[2].SetActive(true);
        }
        else if(resultScore >= 2000)
        {
             ResultImageList[1].SetActive(true);
        }
        else{
             ResultImageList[0].SetActive(true);
        }
    }

  

    public void ToNext()
    {
        SceneManager.LoadScene( nextScene );
    }
}
