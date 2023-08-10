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
    public GameObject menuPanel;
    public GameObject Player;
    public Text quest_text;
    public Text Obj_name;
    public TypingEffect talkText;

    ObjData objData;
    private void Start()
    {
        GameLoad();
        quest_text.text = questManager.CheckQuest();
    }
    public void Action(GameObject scan)
    { 
            
            scanObj = scan;
           objData = scanObj.GetComponent<ObjData>();
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
          
            quest_text.text = questManager.CheckQuest(id); //다음 퀘스트로
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

            Obj_name.text = objData.name;
        }
        else
        {
            //talkText.text = talkData;
            talkText.SetMsg(talkData);
            portraitImage.color = new Color(1, 1, 1, 0);
            Obj_name.text = "";
        }
        IsAction = true;
        talkIndex++;
    }

    private void Update()
    {
        //in the case of barely used key input, they are handled in this func(Update) normally.
        if (Input.GetButtonDown("Cancel"))
        {

            SubmenuActive();

        }

    }

    public void SubmenuActive()
    {
        if (menuPanel.activeSelf)
        { // if the menuPanel is already poped
            menuPanel.SetActive(false);
            IsAction = false;
        }

        else
        {
            menuPanel.SetActive(true);
            IsAction = true;
        }
    }

    public void GameSave()
    {
        // PlayerPrefs : this classs offers simple data_saving opperations 
        PlayerPrefs.SetFloat("PlayerX",Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuPanel.SetActive(false);
        IsAction = false;
    }
    
    public void GameLoad()
    {
        //if the execution of application is the first time(having never been executed)
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int id = PlayerPrefs.GetInt("QuestId");
        int index = PlayerPrefs.GetInt("QuestIndex");

        Player.transform.position = new Vector3(x,y,0);
        questManager.questId = id;
        questManager.questActionIndex = index;
        questManager.ControlObject();
    }
    public void GameExit()
    {
        Application.Quit();
    }

}
