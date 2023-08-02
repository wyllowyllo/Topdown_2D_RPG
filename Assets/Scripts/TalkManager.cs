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
        //대화 내용 : 초상화 매칭
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "여어.:1","이곳 어딘가에 신비한 우물이 있다는데..:0", "휴.. 대체 어디 있는거야:0" });
        talkData.Add(100, new string[] { "누군가 사용했던 흔적이 있는 오래된 책상이다" });
        talkData.Add(200, new string[] { "나의 집이다" });

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
        if (talkIndex == talkData[id].Length)  // 대화가 끝났다면 action 상태 해제
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int PortraitIndex)
    {
        return portraitData[id+PortraitIndex];
    }

}
