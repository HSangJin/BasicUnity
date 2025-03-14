using UnityEngine;

public class BossHead : MonoBehaviour
{
    //직렬화
    [SerializeField] GameObject bossBullet; //보스미사일

    //애니메이션에서 함수 사용하기
    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(1, -1));
    }

    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(-1, -1));
    }

    public void DownLauch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(0, -1));
    }
}
