using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeTowerScript : MonoBehaviour {
    public float rangeRadius;   // 발사 가능한 최대 거리
    public float reloadTime;     // 다음 발사 리로드 타입
    public GameObject projectilePrefab; // 발사 오브젝트
    private float elapsedTime;  // 컵 케이크가 타워가 발사한 직후부터 흐른 시간

    public int upgradeLevel; // 컵케이크 타워 레벨
    public Sprite[] upgradeSprites; // 컵케이크 타워 레벨에 따른 스프라이트
    public bool isUpgradable = true; // 업그레이드 가능 여부

    private Sprite cupcakeSprite;
	// Use this for initialization
	void Start () {
        cupcakeSprite = GetComponent<SpriteRenderer>().sprite;

    }
	
	// Update is called once per frame
	void Update () {
	    if(elapsedTime >= reloadTime)
        {
            elapsedTime = 0; //흐른 스간 초기화
            // 컵케이크 타워의 콜라이더 범위 안에 게임 오브젝트가 있는지 체크.
            Collider2D[] hitColiider = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
            if(hitColiider.Length != 0) // 1개 이상 충돌이라면
            {
                //모든 게임 오브젝트를 대상으로 컵케이크 타ㅜ어에서 가장 가까운 곳에 있는 적을 판별하는 루프
                float min = int.MaxValue;
                int index = -1;
                for(int i = 0; i<= hitColiider.Length; i++)
                {
                    if(hitColiider[i].tag == "Enemy")
                    {
                        float distance = Vector2.Distance(hitColiider[i].transform.position, this.transform.position);
                        if(distance < min)
                        {
                            index = i;
                            min = distance;
                        }
                    }
                }
                if (index == -1) return;

                // 방향 획득
                Transform target = hitColiider[index].transform;
                Vector2 direction = (target.position - this.transform.position).normalized;
                // 발사체 생성
                GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<ProjectileScript>().direction = direction;
            }
            

        }
        elapsedTime += Time.deltaTime;
	}
    public void Upgrade()
    {
        // 업그레이드가 가능한지 체크
        if (!isUpgradable)
        {
            return;
        }
        upgradeLevel++;
        // 업그레이드 최대치 체크
        if(upgradeLevel < upgradeSprites.Length)
        {
            isUpgradable = false;
        }

        // 타워의 스텟을 올린다.
        rangeRadius += 1f;
        reloadTime -= 0.5f;
        // 타워의 그래픽 변경
        cupcakeSprite = upgradeSprites[upgradeLevel];
        //GetComponent<SpriteRenderer>().sprite = upgradeSprites[upgradeLevel];
    }
}
