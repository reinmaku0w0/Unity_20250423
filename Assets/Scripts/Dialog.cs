using System.Collections.Generic;
using NaughtyAttributes;
using TMPEffects.Components;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private TMPWriter tmpWriter; 
    
    [SerializeField]
    private TMP_Text tmpText;
 
    //[SerializeField]
    //private PlayerInput playerInput;


    //private void Start(){}
    //var interactAction = playerInput.actions.FindAction("Interact");
    //interactAction.performed += InteractActionOnperformed;

    //private void OnDisable(){}
    //var interactAction = playerInput.actions.FindAction("Interact");
    //interactAction.performed -= InteractActionOnperformed;

    //private veld InteractActionOnperformed(InputAction.CallbackContext obj){}
    //Debug.Log("互動鍵按下");
    //如果對話完畢(最後一段話)，且打字機效果結束，則關閉對話框
    //if (dialogIndex + 1 == dialogTexts.Count && tmpWriter.IsWriting == false){ CloseDialog(); return; }
    //如果還在播放打字機效果，則Skip打字機效果
    //if(tmpWriter.IsWriting) SkipWriter();
    //如果打字機效果結束，則播放下一段文字
    //else if (tmpWriter.IsWriting == false) PlayNextDialog();


    //所有的對話
    private List<string> dialogTexts;
    
    //顯示播放那一行的字句
    public void SetText(string text)
    {
        tmpWriter.SetText(text);
    }

    //紀錄目前播到第幾段話，0行開始(第一行)
    private int  dialogIndex = 0;
    
    //儲存整段對話文字(?
    public void SetTexts(List<string> texts)
    {
        dialogTexts = texts;
    }

    //開始對話
    public void StartDialog()
    {
        //如果沒有對話，不做任何事
        if (dialogTexts.Count == 0) return;
        dialogIndex = 0; //重製Index 
        SetText(dialogTexts[dialogIndex]);
        PlayWriter();
    }

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        //如果沒有任何對話，不做任何事
        if (dialogTexts.Count == 0)
        {
            Debug.Log("沒有對話資料，哪去了!!");
            return;
        }

        //如果沒有下一個對話，不做任何事
        if (dialogIndex + 1 == dialogTexts.Count) return;
        dialogIndex++;
        SetText(dialogTexts[dialogIndex]);
        PlayWriter();
    } 
    
    //執行打字機效果
    //[ContextMenu("執行打字機效果")]
    [Button("執行打字機效果")]
    public void PlayWriter()
    {
        tmpWriter.RestartWriter();
    } 
    
    //跳過打字機效果，直接播放整行
    // [ContextMenu("跳過打字機效果，直接播放整行")]
    [Button("跳過打字機效果，直接播放整行")]
    private void SkipWriter()
    {
        tmpWriter.SkipWriter();
    }

    [Button("關閉對話框")]
    private void CloseDialog()
    {
        gameObject.SetActive(false);
    }
}
