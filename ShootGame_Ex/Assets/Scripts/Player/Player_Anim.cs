using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player_Anim : MonoBehaviour
{
    public enum Player_PlayAnim { idle, attack, death, hit }

    public bool isAttack { get; private set; } = false;
    public bool isPadding { get; private set; } = false;

    [SerializeField] float animDelay = 1.5f;

    [SerializeField] Player_Control control;

    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Sprite[] _idles;
    [SerializeField] Sprite[] _attacks1;
    [SerializeField] Sprite[] _attacks2;
    [SerializeField] Sprite[] _deads;
    [SerializeField] Sprite[] _hits;

    Coroutine _playAnim = null;

    public void PlayAnim(Player_PlayAnim anim, UnityAction callback = null)
    {
        switch (anim)
        {
            case Player_PlayAnim.attack:
                if(isAttack) { return; }

                if(_playAnim != null) StopCoroutine(_playAnim);
                isAttack = true;
                _playAnim = StartCoroutine(PlayAnimation(_attacks1, () =>
                {
                    if(control.isAttack)
                    {
                        if (_playAnim != null) StopCoroutine(_playAnim);
                        _playAnim = StartCoroutine(PlayAnimation(_attacks2, () =>
                        {
                            isAttack = false;

                            if (callback != null) callback();
                            PlayAnim(Player_PlayAnim.idle);
                        }));
                    }
                    else
                    {
                        isAttack = false;
                        if (callback != null)
                            callback();
                        PlayAnim(Player_PlayAnim.idle);
                    }
                        
                }));
                break;
            default:
                if (isAttack) { return; }
                if (_playAnim != null) StopCoroutine(_playAnim);

                _playAnim = StartCoroutine(PlayAnimation(anim == Player_PlayAnim.death ? _deads : anim == Player_PlayAnim.hit ? _hits : _idles, () =>
                {
                    if (anim != Player_PlayAnim.death && callback != null) callback();
                    
                    if(anim != Player_PlayAnim.death)
                        PlayAnim(Player_PlayAnim.idle);

                    if (anim == Player_PlayAnim.death && callback != null)
                        callback();
                }));
                break;
        }
    }

    IEnumerator PlayAnimation(Sprite[] sprites, UnityAction callback = null)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(Time.deltaTime * animDelay);
        for (int i = 0; i < sprites.Length; i++)
        {
            isPadding = i > 2 && sprites[i].name.Contains("Attack");
            renderer.sprite = sprites[i];
            yield return wait;
            //Debug.Log($"{i}번째 {sprites[i].name}");
        }

        _playAnim = null;
        if (callback != null) 
            callback();
    }
}
