using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId; // present quest id
    public int questActionIndex;  //order of quests
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        generateData();
    }
    void generateData()
    {
        questList.Add(10, new QuestData("���� ������ �λ��ϱ�", new int[] {1000,2000}));
        questList.Add(20, new QuestData("�絵�� ����", new int[] { 5000,2000 }));
    }

    public int GetquestTalkIndex(int id)
    {
        return questId+questActionIndex;
    }
    public string CheckQuest(int id)
    {
    
        string presentQuest = questList[questId].questName;
        // to determine the order of quests
        if (id==questList[questId].npcId[questActionIndex])
             questActionIndex++;
        //Control Quest object
        ControlObject();
        //End of the quest
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return presentQuest;
    }
    public string CheckQuest()
    {
        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                break;
            case 20:  
                if (questActionIndex >= 1)
                    questObject[0].SetActive(false);
                else
                    questObject[0].SetActive(true);
                break;
        }
    }
}
