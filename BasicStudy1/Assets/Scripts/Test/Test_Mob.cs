using UnityEngine;

public class Test_Mob : MonoBehaviour
{
    public float speed = 10f;

    void PosInit()
    {
        float _x = Random.Range(-5f, 10f);

        transform.position = new Vector3(_x, 0.5f, 105f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= speed * Time.deltaTime;
        transform.position = pos;
        if (pos.z <= -7f)
            PosInit();
    }
}
