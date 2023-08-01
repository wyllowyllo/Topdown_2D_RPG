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
            talkText.text = "이것의 이름은" + scanObj.name + "이라고 한다";
        }
        talkPanel.SetActive(IsAction);
    }
      
}
