using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get {
            if(instance == null)
                instance = FindAnyObjectByType<GameManager>();
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("GameManager");
                instance = singletonObject.AddComponent<GameManager>();
            }
            return instance;
        } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private int _score = 0;
    public int Score => _score;

    public void AddScore(int points)
    {
        _score += points;
        Debug.Log($"Score updated: {_score}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
