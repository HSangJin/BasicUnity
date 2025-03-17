using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public float ss = -2f; //몬스터 생성 x값 처음
    public float es = 2; //몬스터 생성 x값 끝
    public float startTime = 1f; //시작
    public float spawnStop = 10f; //스폰 끝나는 시간
    public GameObject monster;
    public GameObject monster2;
    public GameObject boss;

    public GameObject item;

    bool swi = true;
    bool swi2 = true;

    [SerializeField] GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);

        //PoolManager.Instance.CreatePool(monster, 10);
        //PoolManager.Instance.CreatePool(monster2, 10);
        //PoolManager.Instance.CreatePool(boss, 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RandomSpawn());
        Invoke("Stop", spawnStop);
    }

    public void SpawnItem(Vector3 pos)
    {
        Instantiate(item, pos, Quaternion.identity);
    }

    IEnumerator RandomSpawn()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(startTime);
        while(swi)
        {
            //1초마다 
            yield return wait;
            //x값은 랜덤
            float x = Random.Range(ss, es);
            //y값은 자기자신값
            Vector2 r = new Vector2(x, transform.position.y);
            //몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
            //GameObject enemy = PoolManager.Instance.Get(monster);
            //enemy.transform.position = r;
        }
    }

    IEnumerator RandomSpawn2()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(startTime+2);
        while (swi2)
        {
            //1초마다 
            yield return wait;
            //x값은 랜덤
            float x = Random.Range(ss, es);
            //y값은 자기자신값
            Vector2 r = new Vector2(x, transform.position.y);
            //몬스터 생성
            Instantiate(monster2, r, Quaternion.identity);
            //GameObject enemy = PoolManager.Instance.Get(monster2);
            //enemy.transform.position = r;
        }
    }

    void Stop()
    {
        swi = false;
        StopCoroutine(RandomSpawn());
        //두번째 몬스터 코루틴
        StartCoroutine(RandomSpawn2());
        Invoke("Stop2", spawnStop);
    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine(RandomSpawn2());
        textBossWarning.SetActive(true);
        //보스
        Vector3 pos = new Vector3(0f, 4f, 0f);
        Instantiate(boss, pos, Quaternion.identity);
        //GameObject _boss = PoolManager.Instance.Get(boss);
        //_boss.transform.position = pos;

    }
}
