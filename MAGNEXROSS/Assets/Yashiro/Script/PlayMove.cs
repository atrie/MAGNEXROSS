using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private float inputXY;//左右入力変数
    private float inputXZ;//左右入力変数

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Hello, world!");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //*************:左右の移動:***************//
        inputXY = Input.GetAxis("Horizontal");
        //ゲームパッドの十字キー右入力
        if (inputXY > 0)
        {
            inputXY = 1;
            Debug.Log("Right");
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        //ゲームパッドの十字キー左入力
        else if (inputXY < 0)
        {
            inputXY = -1;
            Debug.Log("Left");
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
        //何も入力されていない時
        else
        {
            inputXY = 0;
        }
        //*************:上下の移動:***************//
        inputXZ = Input.GetAxis("Vertical");
        //ゲームパッドの十字キー上入力
        if (inputXZ > 0)
        {
            inputXZ = 1;
            Debug.Log("Up"); transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);
        }
        //ゲームパッドの十字キー下入力
        else if (inputXZ < 0)
        {
            inputXZ = -1;
            Debug.Log("Down"); transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
        //何も入力されていない時
        else
        {
            inputXZ = 0;
        }
    }
    
}
