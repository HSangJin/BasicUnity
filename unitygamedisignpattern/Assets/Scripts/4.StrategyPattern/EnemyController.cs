using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _enemy.SetMovementStrategy(new StraightMovement());
            Debug.Log("직선 이동 전략으로 변경");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _enemy.SetMovementStrategy(new ZigzegMovement());
            Debug.Log("지그재그 이동 전략으로 변경");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _enemy.SetMovementStrategy(new CircularMovement());
            Debug.Log("원형 이동 전략으로 변경");
        }
    }
}
