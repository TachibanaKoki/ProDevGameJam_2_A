using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyManager : MonoBehaviour
{

    [Header("NavMesh操作ロジック設定変数")]
    private float createTime = 0.0f;

    public List<Transform> enemyPopPos;


    public List<GameObject> enemyList;

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
            yield return new WaitForSeconds(2.0f);
            CreateEnemy();
        }
    }
    void CreateEnemy()
    {
        int _posNO = Random.Range(0,enemyPopPos.Count);
        int _EnemyNo = Random.Range(0,enemyList.Count);

        Instantiate(enemyList[_EnemyNo], enemyPopPos[_posNO].position, Quaternion.identity);

    }
}
