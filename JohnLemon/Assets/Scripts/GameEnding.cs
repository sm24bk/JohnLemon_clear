using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [Header("Game Clear")]
    public CanvasGroup exitImageCanvasGroup;
    public float fadeDuration;
    public float displayExitImageDuration;
    public AudioSource exitAudio;

    [Header("Game Over")]
    public CanvasGroup gameOverImageCanvasGroup;
    public float displayGameOverImageDuration;
    public AudioSource caughtAudio;

    bool isPlayerExit = false;
    bool isPlayerCaught = false;
    bool HasAudioPlayed = false;
    float timer = 0f;

    void Update()
    {
        if (isPlayerExit)
        {
            EndLevel(exitImageCanvasGroup, displayExitImageDuration, false, exitAudio);
        }
        if (isPlayerCaught)
        {
            EndLevel(gameOverImageCanvasGroup, displayGameOverImageDuration, true, caughtAudio);
        }
               
    }
    void EndLevel(CanvasGroup canvasGroup, float displayDuration, bool doRestart, AudioSource audioSource)

    {
        if (HasAudioPlayed == false)
        {
            audioSource.Play();
            HasAudioPlayed = true;
        }
       
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                //재시작
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Application.Quit();
            }
            
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    //OnTriggerEnter : 콜라이더 컴포넌트에서 다른 콜라이더가 충돌해서 겹쳐지는 첫 프레임에 한번 호출
    //OnTriggerStay : 콜라이더가 다른 콜라이더와 겹쳐져있는 내내 호출
    //OnTriggerExit : 두 콜라이더가 떨어지는 순간 한번 호출
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            isPlayerExit = true;
        }
    }

}
