using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    //싱글톤
    //어디에서나 접근 할수있도록 static(정적)으로 자기 자신을 저장해서 싱글톤이라는 디자인패턴을 사용해본다.
    public static GamaManager Instance;
    public Text scoreText;
    int score = 0; //점수를 관리합니다
    public Text StartText; //게임시작 3,2,1

    [SerializeField] Launcher launcher;
    [SerializeField] SpawnManager spawnManager;

    private void Awake()
    {
        if(GamaManager.Instance == null)
            GamaManager.Instance = this;
    }

    private void Start()
    {
        launcher.enabled = false;
        spawnManager.enabled = false;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        int i = 3;
        while(i>0)
        {
            StartText.text = i.ToString();
            yield return new WaitForSeconds(1f);
            i--;
            if(i==0)
            {
                StartText.gameObject.SetActive(false); //UI 감추기
            }
        }
        launcher.enabled = true;
        spawnManager.enabled = true;
    }


    public void AddScore(int num)
    {
        score += num;
        scoreText.text = $"Score : {score}";
    }
}
