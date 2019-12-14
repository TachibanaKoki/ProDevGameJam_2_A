using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyManager : MonoBehaviour
{

    [Header("NavMesh操作ロジック設定変数")]
    private float createTime = 0.0f;

    public List<Transform> enemyPopPos;

    [SerializeField]
    private int enemyType = 3;


    public List<GameObject> enemyType1List;
    public List<GameObject> enemyType2List;
    public List<GameObject> enemyType3List;

    public float enemyPopTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator loop() {
    
        while (true) {
            yield return null;
            yield return new WaitForSeconds(enemyPopTime);
            CreateEnemy();
        }
    }
    void CreateEnemy()
    {
        int _posNO = Random.Range(0,enemyPopPos.Count);
        int _EnemyNo = Random.Range(0,enemyType);

        switch(_EnemyNo)
        {
            case 0 :
                CreateType1(_posNO);
                break;
            case 1 :
                CreateType2(_posNO);
                break;
            case 2 :
                CreateType3(_posNO);
                break;
            default :
                CreateType1(_posNO);
                break;
        }
        
        if(Score.m_Score > 7000)
        {
            enemyPopTime = 2.0f;
        }
        else if(Score.m_Score > 5000)
        {
            enemyPopTime = 2.5f;
        }
        else if(Score.m_Score > 3000)
        {
            enemyPopTime = 3.0f;
        }
        else if(Score.m_Score > 1500)
        {
            enemyPopTime = 3.5f;
        }

    }

    void CreateType1(int _posNO)
    {
        int _EnemyNo = Random.Range(0,enemyType1List.Count);
        Instantiate(enemyType1List[_EnemyNo], enemyPopPos[_posNO].position, Quaternion.identity);
    }
    void CreateType2(int _posNO)
    {
        int _EnemyNo = Random.Range(0,enemyType2List.Count);
        Instantiate(enemyType2List[_EnemyNo], enemyPopPos[_posNO].position, Quaternion.identity);
    }
    void CreateType3(int _posNO)
    {
        int _EnemyNo = Random.Range(0,enemyType3List.Count);
        Instantiate(enemyType3List[_EnemyNo], enemyPopPos[_posNO].position, Quaternion.identity);
    }
}
