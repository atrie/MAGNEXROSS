using UnityEngine;
using System.Collections;

public class EnemySet : MonoBehaviour {

    //プレハブを変数に代入
    [SerializeField]private GameObject EnemyPre;
    

    void Start()
    {
        ////オブジェクトの座標
        //float x = Random.Range(-10.0f, 10.0f);
        //float y = -2;
        //float z = Random.Range(-10.0f, 10.0f);

        ////オブジェクトを生産
        //Instantiate(EnemyPre, new Vector3(x, y, z), Quaternion.identity);
    }
    void Update()
    {
        //オブジェクトの座標
        float x = Random.Range(-10.0f, 10.0f);
        float y = -2;
        float z = Random.Range(-10.0f, 10.0f);

        //オブジェクトを生産
        Instantiate(EnemyPre, new Vector3(x, y, z), Quaternion.identity);
    }
}
