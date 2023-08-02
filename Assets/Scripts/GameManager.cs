using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObj;
    public Image portraitImage;
    public bool IsAction;
    public int talkIndex;
    public void Action(GameObject scan)
    { 
            
            scanObj = scan;
            ObjData objData = scanObj.GetComponent<ObjData>();
            Talk(objData.Id, objData.IsNpc);
           
        
        talkPanel.SetActive(IsAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData=talkManager.GetTalk(id, talkIndex);


        if (talkData == null)
        {
            IsAction = false;
            talkIndex = 0;
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
