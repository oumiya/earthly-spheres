using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スフィアの挙動
/// </summary>
/// <remarks>
/// http://matudozer.blog.fc2.com/blog-entry-21.html
/// </remarks>
public class SphereControll : MonoBehaviour {

    public float speed = 2.0f;
    public float width = 4.0f;
    public float height = 4.0f;

    enum Status { Around, Rotation, Attract, Holding, Wait };
    Status state;

    Transform playerTransform;

	// Use this for initialization
	void Start () {
        state = Status.Around;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        switch(state)
        {
            case Status.Around:
                // 周回軌道を回っている
                {
                    float x = Mathf.Cos(Time.time * speed) * width;
                    float y = Mathf.Sin(Time.time * speed) * height;
                    float z = 0.0f;
                    transform.position = new Vector3(x, y, z);
                    break;
                }
            case Status.Rotation:
                // 選択中なので回ってアピールしている ついでにキラキラエフェクトも出しちゃう
                {
                    transform.Rotate(10, 0, 0);

                    float x = Mathf.Cos(Time.time * speed) * width;
                    float y = Mathf.Sin(Time.time * speed) * height;
                    float z = 0.0f;
                    transform.position = new Vector3(x, y, z);

                    state = Status.Around;
                    break;
                }
            case Status.Attract:
                // 選択されてプレイヤーに引き寄せられている
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerTransform.position - transform.position), 0.3f);

                transform.position += transform.forward * 1f;

                // 一定距離まで近づいたら状態をHoldingに遷移
                if (Vector3.Distance(playerTransform.position, transform.position) <= 1.0f)
                {
                    state = Status.Holding;
                }
                break;
            case Status.Holding:
                // プレイヤーに持たれている
                transform.position = playerTransform.position;
                transform.forward = playerTransform.forward;
                transform.position += transform.forward * 2f;
                break;
            case Status.Wait:
                // 地面に設置されている
                break;
        }
	}

    /// <summary>
    /// カメラ映像の中央で衛星を捉えた時に行われるイベント
    /// 選択中みたいな感じ
    /// クリックしたら取ってこれる
    /// </summary>
    public void OnLookEnter()
    {
        if (state == Status.Around)
        {
            GetComponent<ParticleSystem>().Play();
            state = Status.Rotation;
        }

        if (state == Status.Around || state == Status.Rotation)
        {
            if (Input.GetMouseButton(0))
            {
                state = Status.Attract;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
