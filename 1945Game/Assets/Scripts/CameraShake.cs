using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Impulse Source 컴포넌트 참조
    [SerializeField] CinemachineImpulseSource source;

    public void CameraShakeShow()
    {
        if(source != null)
        {
            //기본 설정으로 임펄스 생성
            source.GenerateImpulse();
        }
    }
}
