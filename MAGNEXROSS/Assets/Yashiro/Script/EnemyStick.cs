using UnityEngine;
using System.Collections;

public class EnemyStick : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<EnemyMove_useDistance>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
