using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    //public Text talkText;
    public GameObject scanObj;
    public Image portraitImage;
    public Animator portraitAnimator;
    public bool IsAction;
    public int talkIndex;
    public Sprite prevPortrait;

    public TypingEffect talkText;
    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scan)
    { 
            
            scanObj = scan;
            ObjData objData = scanObj.GetComponent<ObjData>();
            Talk(objData.Id, objData.IsNpc);


        talkPanel.SetBool("IsShown", IsAction);
    }

    void Talk(int id, bool isNpc)
    {
        //set talk data
        int questTalkIndex;
        string talkData="";
       

        if (talkText.isAnim)
        {
            talkText.SetMsg("");
            return;
        }
            
        else
        {
            questTalkIndex = questManager.GetquestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }


        //Conversation end
        if (talkData == null)
        {
            IsAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id)); //다음 퀘스트로
            return;
        }

        if (isNpc)
        {
            //talkText.text = talkData.Split(':')[0];  //구분자를 통해 나누기
            talkText.SetMsg(talkData.Split(':')[0]);

            portraitImage.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImage.color=new Color(1, 1, 1, 1);

            if (prevPortrait != portraitImage.sprite)
            {
                portraitAnimator.SetTrigger("doEffect");
                prevPortrait = portraitImage.sprite;
            }
        }
        else
        {
            //talkText.text = talkData;
            talkText.SetMsg(talkData);
            portraitImage.color = new Color(1, 1, 1, 0);
        }
        IsAction = true;
        talkIndex++;
    }
      
}
