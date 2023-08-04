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
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1","우리 마을에 온 걸 환영해!:2" });
        talkData.Add(2000, new string[] { "여어.:1","이곳 어딘가에 신비한 우물이 있다는데..:0", "휴.. 대체 어디 있는거야:0" });
        talkData.Add(100, new string[] { "누군가 사용했던 흔적이 있는 오래된 책상이다" });
        talkData.Add(200, new string[] { "나의 집이다" });


        ////////////Quest talk (quest number + NPC id)/////////////////////////////////
        
        //마을 사람들과 인사하기
        talkData.Add(10+1000, new string[] { "안녕? 이번에 이사온 사람이 너구나? 난 루시라고 해:0", "우리 마을은 조용하고 아름다워, 그리고 마을 사람들도 모두 친절해.:1",
        "너도 곧 여기가 좋아질 거야!:2","아 참, 마을 사람들과 대화해 보는 건 어때?:1","이곳에 적응하는 데 도움이 될 거야!:2"});
        talkData.Add(11 + 2000, new string[] {"뭐야? 처음보는 얼굴인데.:0", "여기로 이사왔다고? 이런 깡촌에?:1","여튼 반갑다, 내 이름은 루도, 무슨 일 있으면 이몸한테 말하라고:2" });


        //루도의 동전
        talkData.Add(20 + 2000, new string[] { "너 그거 알아? 이 마을에 신비한 우물이 있다는 거?:0", "그 우물의 물을 마시면 굉장한 스피드를 낼 수 있대!:1", "어때? 흥미가 가지 않아? 나랑 같이 찾아보지 않을래?:1",
                                                "좋아! 같이 찾아보자고! ....근데, 모험을 떠나기 전에 경비가 좀 필요해.:2","근데 내가 모아둔 동전을 잃어버렸거든, 우선 이 동전들을 좀 찾아줘:1"
                                                });
        talkData.Add(20 + 1000, new string[] {"루도의 동전?:1", "돈을 흘리고 다니면 못쓰지!:3",
                                               "나중에 루도에게 한마디 해야겠어.:3"
                                                });
        //talkData.Add(20 + 2000, new string[] { "동전 찾았어?:1", "찾으면 꼭 가져와 줘.:1" });

        talkData.Add(20 + 5000, new string[] { "루도의 동전을 찾았다."
                                                });
        talkData.Add(21 + 2000, new string[] { "엇, 찾았구나!:2", "이제 모험을 떠날 수 있겠는걸.:2"
                                                });



        /////////////////////////////////////////////////////////////////////////////////
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
        ///////////////////Exception process//////////////////////////
        if (!talkData.ContainsKey(id))
        {
            //퀘스트 맨 처음 대사마저 없을 때, 기본 대사 가져옴
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);

            //해당 퀘스트 진행 순서 대사가 없을 때 ,퀘스트 맨 처음 대사 가져옴.
            else
                return GetTalk(id - id % 10, talkIndex);
            
        }
        ///////////////////////////////////////////////////////////////////
  
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
