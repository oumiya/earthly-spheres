using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スフィアの移動
/// </summary>
/// <remarks>
/// http://matudozer.blog.fc2.com/blog-entry-21.html
/// </remarks>
public class SphereControll : MonoBehaviour {

    public float speed = 2.0f;
    public float width = 4.0f;
    public float height = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Cos(Time.time * speed) * width;
        float y = Mathf.Sin(Time.time * speed) * height;
        float z = 0.0f;
        transform.position = new Vector3(x, y, z);
	}
}
