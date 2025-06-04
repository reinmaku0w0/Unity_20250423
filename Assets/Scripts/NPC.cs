using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPC_DialogData dialogData;

    [SerializeField]
    private Dialog dialog;

    [SerializeField]
    private PlayerInput playerInput;
    
    /// <summary>
    /// NPC UI物件
    /// </summary>
    [SerializeField]
    private CanvasGroup npcUI_Panel;

    private void Start()
    {
        Dialog.Instance.gameObject.SetActive(false);
        npcUI_Panel.alpha = 0;
        playerInput.actions.FindAction("Interact").performed+= OnInteractActionPerformed;
    }
    private void OnDisable()
    {
        var interactAction = playerInput.actions.FindAction("Interact");
        interactAction.performed -= OnInteractActionPerformed;
    }
    
    /// <summary>
    /// 按下互動鍵
    /// </summary>
    /// <param name="obj"></param>
    private void OnInteractActionPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("按下互動鍵");
        //已在對話中
        if (Dialog.Instance.IsInDialog()) return;
        //角色在範圍內，開始對話
        if (characterInTrigger)
        {
           StartDialog(); 
        }
    }

    private void ShowNPCDialogHintUI()
    {
        npcUI_Panel.alpha = 1;
    }

    private void CloseNPCDialogHintUI()
    {
        npcUI_Panel.alpha = 0;
    }
    
    /// <summary>
    /// 角色在偵測範圍內
    /// </summary>
    /// <param name="col"></param>
    private bool characterInTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out CharacterController character))
        {
            characterInTrigger = true;
            ShowNPCDialogHintUI();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out CharacterController character))
        {
            characterInTrigger = false;
            CloseNPCDialogHintUI();
        }
    }

    [Button("開始對話")]
    public void StartDialog()
    {
        Dialog.Instance.SetPosition(transform.position);
        Dialog.Instance.gameObject.SetActive(true);
        Dialog.Instance.SetTexts(dialogData.dialogTexts);
        Dialog.Instance.StartDialog();
    }

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        Dialog.Instance.PlayNextDialog();
    } 
}
