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
                //�����
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

    //OnTriggerEnter : �ݶ��̴� ������Ʈ���� �ٸ� �ݶ��̴��� �浹�ؼ� �������� ù �����ӿ� �ѹ� ȣ��
    //OnTriggerStay : �ݶ��̴��� �ٸ� �ݶ��̴��� �������ִ� ���� ȣ��
    //OnTriggerExit : �� �ݶ��̴��� �������� ���� �ѹ� ȣ��
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            isPlayerExit = true;
        }
    }

}
