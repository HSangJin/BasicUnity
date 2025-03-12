using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Bullet bullet;
    public int count = 1;
    public float delay = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(ShootAction());
        InvokeRepeating("Shoot", 1f, 1f);
    }

    //IEnumerator ShootAction()
    //{
    //    while (true)
    //    {
    //        return new WaitForSecondsRealtime(delay);
    //        Shoot();
    //    }
    //}

    void Shoot()
    {
        if (count == 0)
            return;

        Vector3 pos = transform.position;
        if (count % 2 == 1)
        {
            for(int i=0;i<count;i++)
            {
                pos.x += i * 0.5f * (i % 2 == 0 ? 1 : -1);
                GameObject obj = Instantiate(bullet.gameObject, pos, Quaternion.identity);
                //obj.transform.position = pos;
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                pos.x += (i + 1) * 0.25f * (i % 2 == 0 ? 1 : -1);
                GameObject obj = Instantiate(bullet.gameObject, pos, Quaternion.identity);
                //obj.transform.position = pos;
            }
        }
    }
}
