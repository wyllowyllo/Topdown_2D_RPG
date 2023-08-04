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
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1","�츮 ������ �� �� ȯ����!:2" });
        talkData.Add(2000, new string[] { "����.:1","�̰� ��򰡿� �ź��� �칰�� �ִٴµ�..:0", "��.. ��ü ��� �ִ°ž�:0" });
        talkData.Add(100, new string[] { "������ ����ߴ� ������ �ִ� ������ å���̴�" });
        talkData.Add(200, new string[] { "���� ���̴�" });


        ////////////Quest talk (quest number + NPC id)/////////////////////////////////
        
        //���� ������ �λ��ϱ�
        talkData.Add(10+1000, new string[] { "�ȳ�? �̹��� �̻�� ����� �ʱ���? �� ��ö�� ��:0", "�츮 ������ �����ϰ� �Ƹ��ٿ�, �׸��� ���� ����鵵 ��� ģ����.:1",
        "�ʵ� �� ���Ⱑ ������ �ž�!:2","�� ��, ���� ������ ��ȭ�� ���� �� �?:1","�̰��� �����ϴ� �� ������ �� �ž�!:2"});
        talkData.Add(11 + 2000, new string[] {"����? ó������ ���ε�.:0", "����� �̻�Դٰ�? �̷� ���̿�?:1","��ư �ݰ���, �� �̸��� �絵, ���� �� ������ �̸����� ���϶��:2" });


        //�絵�� ����
        talkData.Add(20 + 2000, new string[] { "�� �װ� �˾�? �� ������ �ź��� �칰�� �ִٴ� ��?:0", "�� �칰�� ���� ���ø� ������ ���ǵ带 �� �� �ִ�!:1", "�? ��̰� ���� �ʾ�? ���� ���� ã�ƺ��� ������?:1",
                                                "����! ���� ã�ƺ��ڰ�! ....�ٵ�, ������ ������ ���� ��� �� �ʿ���.:2","�ٵ� ���� ��Ƶ� ������ �Ҿ���Ȱŵ�, �켱 �� �������� �� ã����:1"
                                                });
        talkData.Add(20 + 1000, new string[] {"�絵�� ����?:1", "���� �긮�� �ٴϸ� ������!:3",
                                               "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3"
                                                });
        //talkData.Add(20 + 2000, new string[] { "���� ã�Ҿ�?:1", "ã���� �� ������ ��.:1" });

        talkData.Add(20 + 5000, new string[] { "�絵�� ������ ã�Ҵ�."
                                                });
        talkData.Add(21 + 2000, new string[] { "��, ã�ұ���!:2", "���� ������ ���� �� �ְڴ°�.:2"
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
            //����Ʈ �� ó�� ��縶�� ���� ��, �⺻ ��� ������
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);

            //�ش� ����Ʈ ���� ���� ��簡 ���� �� ,����Ʈ �� ó�� ��� ������.
            else
                return GetTalk(id - id % 10, talkIndex);
            
        }
        ///////////////////////////////////////////////////////////////////
  
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
