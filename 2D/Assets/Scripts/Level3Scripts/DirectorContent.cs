using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorContent : MonoBehaviour
{
    [Header("对话相关")]
    public DialogueManager dialogueManager;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            dialogueManager.StartDialogue("妇女", new string[] {
                "“怎么今天突然下雨了，得早点出发了……”", "她的视线落在承翰上",
                "“醒了怎么还不自己起床啊，翰翰，我们得抓紧时间准备了”",
                "妇女熟练地给小孩穿上衣服","“自己洗漱吧，我先帮你打包好东西。”"
            });
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
}
