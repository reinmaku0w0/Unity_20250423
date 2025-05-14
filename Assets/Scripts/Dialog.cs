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

    public void SetText(string dialogText)
    {
        tmpText.SetText(dialogText);
    }

}
