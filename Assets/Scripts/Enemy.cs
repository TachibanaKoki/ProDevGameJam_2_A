using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int enemyLevel = 1;


    private float eventTime = 0.0f;

    private int eventflag = 0;

    [SerializeField]
    private float addForce = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyLevel)
        {
            case 1 :
                break;
            case 2 :
                EnemyType2();
                break;
            case 3 :
                EnemyType3();
                break;
        }

        //画面外で消える
        if(this.transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void EnemyType2()
    {
        eventTime += Time.deltaTime;

        if(eventflag == 0)
        {
            if(eventTime >= 3.0f)
            {
                moveEnemy();
                eventflag = 1;
                eventTime = 0.0f; 
            }
        }
            
    }

    void EnemyType3()
    {
        eventTime += Time.deltaTime;

        if(eventflag == 0)
        {
            if(eventTime >= 2.5f)
            {
                moveEnemy();
                eventflag = 1;
                eventTime = 0.0f; 

            }
        }
        else if(eventflag == 1)
        {
            if(eventTime >= 0.6f)
            {
                moveEnemy(true);
                eventflag = 2;

            }
        }
    }

    void moveEnemy(bool nextmove = false)
    {
        GameObject player = GameObject.Find("player");
        //プレイヤーの方へAddForce
        Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();
        Vector2 setforce =  new Vector2 (0.0f,0.0f);
        float p_posx = player.transform.position.x;
        float m_posx = this.transform.position.x;
        float _dis = p_posx - m_posx;
        float add_f = addForce;
        if(_dis < 0)
        {
            _dis*=-1;
        }

        if(_dis < 2.0f)
        {
             setforce = new Vector2 (0.0f,-add_f);
        }
        else if(p_posx < m_posx)
        {
            if(_dis < 3.0f)
            {
                add_f /=2.0f;
            }
            if(nextmove)
            {
                add_f *=2.0f;
            }
            setforce = new Vector2 (-add_f,0.0f);
            
        }
        else if(p_posx > m_posx)
        {
            if(_dis < 2.0f)
            {
                add_f /=2.0f;
            }
            if(nextmove)
            {
                add_f *=2.0f;
            }
            setforce = new Vector2 (add_f,0.0f);
        }

        rb.AddForce (setforce); 
    }
}
