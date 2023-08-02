using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int ,Sprite> portraitData;

    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //��ȭ ���� : �ʻ�ȭ ��Ī
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        talkData.Add(2000, new string[] { "����.:1","�̰� ��򰡿� �ź��� �칰�� �ִٴµ�..:0", "��.. ��ü ��� �ִ°ž�:0" });
        talkData.Add(100, new string[] { "������ ����ߴ� ������ �ִ� ������ å���̴�" });
        talkData.Add(200, new string[] { "���� ���̴�" });

        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)  // ��ȭ�� �����ٸ� action ���� ����
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int PortraitIndex)
    {
        return portraitData[id+PortraitIndex];
    }

}
