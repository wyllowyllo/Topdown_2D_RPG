using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingEffect : MonoBehaviour
{
    public int CharPerSeconds;
    float interval;
    public GameObject EndCursor;
    AudioSource audioSource;
    Text msgText;
    int CharIndex;
    string targetMsg;
    public bool isAnim;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        EndCursor.SetActive(false);
        interval = (float)1 / CharPerSeconds;
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        //Animation cancel
        if (isAnim)
        {
            CancelInvoke();
            msgText.text = targetMsg;
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        CharIndex = 0;
        isAnim = true;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        //End animation
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[CharIndex];

        //Sound
        if(targetMsg[CharIndex]!=' '|| targetMsg[CharIndex] !='.')
        {
            audioSource.Play();
        }
        CharIndex++; //to implement sequential Text_animation 
        
        //Recursive
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true);
        isAnim = false;
    }

   
}
