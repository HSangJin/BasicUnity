using UnityEngine;

public class Player : MonoBehaviour
{
    //움직이는 속도 정의
    public float moveSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distaceX = Input.GetAxis("Horizontal")*Time.deltaTime * moveSpeed;
        transform.Translate(distaceX, 0, 0);
    }
}
