using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObj;
    public Image portraitImage;
    public bool IsAction;
    public int talkIndex;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scan)
    { 
            
            scanObj = scan;
            ObjData objData = scanObj.GetComponent<ObjData>();
            Talk(objData.Id, objData.IsNpc);
           
        
        talkPanel.SetActive(IsAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetquestTalkIndex(id);
        string talkData=talkManager.GetTalk(id+questTalkIndex, talkIndex);


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
            talkText.text = talkData.Split(':')[0];  //구분자를 통해 나누기

            portraitImage.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImage.color=new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImage.color = new Color(1, 1, 1, 0);
        }
        IsAction = true;
        talkIndex++;
    }
      
}
