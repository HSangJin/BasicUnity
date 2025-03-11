using System.Collections;
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("코루틴 시작");
        yield return new WaitForSeconds(2f); //2초 대기
        Debug.Log("2초후 실행");
    }
}
