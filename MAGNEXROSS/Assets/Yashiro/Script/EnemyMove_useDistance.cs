using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_useDistance : MonoBehaviour {
    List<GameObject> players = new List<GameObject>();
    List<GameObject> enemys = new List<GameObject>();
    private float limitDistance = 10f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）
    private bool on = true;
    private float speed = 3; //移動速度

    float frame = 0;

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < obj.Length; i++) players.Add(obj[i]);
    }

    void Update()
    {
        //--------------------------------------------------------------------
        // ステージ上の敵を検索
        if (frame >= 1.0f)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < obj.Length; i++) enemys.Add(obj[i]);
            frame = 0;
        }
        else
            frame += Time.deltaTime;

        for (int i = 0; i < enemys.Count; i++)
        {
            for (int j = 0; j < players.Count; j++)
            {
                Vector3 playerPos = players[j].transform.position;                 //プレイヤーの位置
                Vector3 direction = playerPos - enemys[i].transform.position; //方向と距離を求める。
                float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
                direction = direction.normalized;                   //単位化（距離要素を取り除く）
                direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。

                //プレイヤーの距離が一定以下だと近づく
                if (distance < 1.0f)
                {
                    enemys[i].transform.parent = players[j].transform;
                }
                else if (distance < limitDistance)
                {
                    //プレイヤーとの距離が制限値以下なので近づく
                    enemys[i].transform.position = enemys[i].transform.position + (direction * speed * Time.deltaTime);
                }
            }
        }
    }
    // private Transform player;    //プレイヤーを代入
    //[SerializeField]private float speed = 3; //移動速度
    // private float limitDistance = 10f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）

    // //ゲーム開始時に一度
    // void Start()
    // {
    //     //Playerオブジェクトを検索し、参照を代入
    //     player = GameObject.FindGameObjectWithTag("Player").transform;
    // }

    // //毎フレームに一度
    // void Update()
    // {
    //     Vector3 playerPos = player.position;                 //プレイヤーの位置
    //     Vector3 direction = playerPos - transform.position; //方向と距離を求める。
    //     float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
    //     direction = direction.normalized;                   //単位化（距離要素を取り除く）
    //     direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。

    //     //プレイヤーの距離が一定以下だと近づく
    //     if (distance < limitDistance)
    //     {
    //         //プレイヤーとの距離が制限値以下なので近づく
    //         transform.position = transform.position + (direction * speed * Time.deltaTime);
    //     }

    //     //プレイヤーの方を向く
    //     transform.rotation = Quaternion.LookRotation(direction);

    //     //敵のY座標が-5以下の時自身を削除
    //     if (transform.position.y <= -10.0f)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    // //オブジェクトが衝突したとき
    // //void OnTriggerEnter(Collision collision)
    // //{
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         //Destroy(this.gameObject);    //オブジェクトを消去
    //         Debug.Log("アタック!");
    //         //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
    //         //rb.isKinematic = true;
    //         // 同じオブジェクト(Cube)内の他のスクリプトを参照する場合
    //         GetComponent<EnemyStick>().enabled = true;
    //         GetComponent<EnemyMove_useDistance>().enabled = false;
    //         SphereCollider rb = gameObject.GetComponent<SphereCollider>();
    //         rb.isTrigger = true;
    //     }
    // }
}
