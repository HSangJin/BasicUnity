using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터 가져오기
    public GameObject enemy;

    /// <summary> 몬스터 생성하는 함수 </summary>
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2.5f, 2.5f); //적이 나타날 X좌표를 랜덤으로 생성하기

        //적을 생성한다. randomX랜덤함 x값
        Instantiate(enemy, new Vector3(randomX, 7.15f, 0f), Quaternion.identity);
    }

    void Start()
    {
        //SpawnEnemy 1 0.5f
        InvokeRepeating("SpawnEnemy", 1, 0.5f);
    }

}
