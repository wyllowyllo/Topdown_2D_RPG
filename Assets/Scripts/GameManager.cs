using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObj;
    public bool IsAction;
    public void Action(GameObject scan)
    {

        if (IsAction)
        {
            IsAction = false;
        }
        else
        {
            IsAction = true;
            scanObj = scan;
            talkText.text = "�̰��� �̸���" + scanObj.name + "�̶�� �Ѵ�";
        }
        talkPanel.SetActive(IsAction);
    }
      
}
