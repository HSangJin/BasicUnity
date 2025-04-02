using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory _instance;
    public static EnemyFactory Instance
    {
        get
        {
            if(_instance == null)
                _instance = FindAnyObjectByType<EnemyFactory>();
            if( _instance == null )
            {
                GameObject go = new GameObject("EnemyFactory");
                _instance = go.AddComponent<EnemyFactory>();
                DontDestroyOnLoad( go );
            }
            return _instance;
        }
    }

    public GameObject gruntPrefab;
    public GameObject runnerPrefab;
    public GameObject tankPrefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnemy CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyObject = null;

        switch (type)
        {
            case EnemyType.Grunt:
                enemyObject = Instantiate(gruntPrefab);
                break;
            case EnemyType.Runner:
                enemyObject = Instantiate(runnerPrefab);
                break;
            case EnemyType.Tank:
                enemyObject = Instantiate(tankPrefab);
                break;
            default:
                Debug.LogError($"Unknow enemy type: {type}");
                return null;
        }

        IEnemy enemy = enemyObject.GetComponent<IEnemy>();
        enemy.Initialize(position);
        return enemy;
    }
}
