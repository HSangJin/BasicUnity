using UnityEngine;

public class VectorStudy : MonoBehaviour
{
    public Vector2 v2 = new Vector2(10, 10); //2d
    public Vector3 v3 = new Vector3(1, 1, 1); //3d
    public Vector4 v4 = new Vector4(1.0f, 0.5f, 0.0f, 1.0f); //색상

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 a = new Vector3(1, 1, 0);
        //Vector3 b = new Vector3(2, 0, 0);
        //Vector3 c = a + b;
        //Debug.Log("Vector : "+c);
        //Debug.Log("길이 : " + c.magnitude);

        Vector3 a = new Vector3(3, 0, 0);
        Vector3 normalizedVector = a.normalized;
        Debug.Log("1의 길이 방향만 설정하는 정규화 : " + normalizedVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
