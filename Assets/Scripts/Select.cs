using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {

    public RaycastHit hit;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Sphere")
            {
                hit.collider.gameObject.GetComponent<SphereControll>().OnLookEnter();
            }

        }

	}
}
