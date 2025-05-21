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

    private List<string> dialogTexts;
    
    private int  dialogIndex = 0;

    public void SetText(string text)
    {
        tmpWriter.SetText(text);
    }
    
    public void StartDialog()
    {
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
    //[ContextMenu("執行打字機效果")
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

    public void SetTexts(List<string> texts)
    {
        dialogTexts = texts;
    }
}
