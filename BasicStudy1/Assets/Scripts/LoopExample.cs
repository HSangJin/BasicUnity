using UnityEngine;

public class LoopExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for문: 1부터 10까지 출력
        for(int i = 0; i < 10; i++)
        {
            Debug.Log("Count : " + i);
        }

        //while문: 조건이 참일때 실행
        int counter = 0;
        while(counter < 5)
        {
            Debug.Log("While COunt : " + counter);
            counter++;
        }
    }
}
