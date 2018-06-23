using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureFirst : MonoBehaviour {
    Vector3 Aim_vector;

	// Use this for initialization
	void Start () {
        Aim_vector = new Vector3(5, 0, 0);

    }
    // Update is called once per frame
    float y;
    void Update () {
        y += Time.deltaTime * ((Random.value-0.5f)*5);
        if (y > 3.0f) y = 3.0f;
        if (y < -3.0f) y = -3.0f;
        Aim_vector = Quaternion.Euler(0, y, 0) * Aim_vector;
        Debug.Log("Aim_vector:" + Aim_vector);
        GetComponent<Rigidbody>().velocity = Aim_vector * 1f;
    }
}
