using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    //함수 정의
    void SayHello()
    {
        Debug.Log("Hello, Unity");
    }

    int AddNumbers(int a, int b)
    {  return a + b; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SayHello();
        int total = AddNumbers(3, 5);
        Debug.Log($"Total : {total}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
