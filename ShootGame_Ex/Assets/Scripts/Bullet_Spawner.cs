using UnityEngine;

public class Bullet_Spawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBullet", 0, 1f);
    }

    void SpawnBullet()
    {
        Vector3 pos = new Vector3(10f, Random.Range(-4f, 6f), 0f);
        GameObject obj = Instantiate(bullet);
        obj.transform.position = pos;
    }
}
