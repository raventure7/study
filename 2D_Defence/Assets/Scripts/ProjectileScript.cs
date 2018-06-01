using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float damage;              // 발사체 데미지
    public float speed;               // 발사체 속도
    public Vector3 direction;         // 발사체 방향
    public float lifeDuration = 10f;  //발사체가 자폭하기 전까지 살아있는 시간.
	// Use this for initialization
	void Start () {
        // 방향 정규화
        direction = direction.normalized;
        // 회전 값
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // 자폭용 타이머
        Destroy(gameObject, lifeDuration);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * Time.deltaTime * speed;
	}
}
