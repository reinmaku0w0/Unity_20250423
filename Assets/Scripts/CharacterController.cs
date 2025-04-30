using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class CharacterController : MonoBehaviour
{ 
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction moveAction; //移動行為
    private InputAction interactAction; //互動行為
    private bool dead;
    
    void Start()
    {
        moveAction = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interact");
    }
    
    void Update()
    {
        if (dead) return;
        if (interactAction.WasPressedThisFrame())//互動按鈕按下的判斷式
        {
            Debug.Log("interact button pressed");
        }

    var moveVector2 = moveAction.ReadValue<Vector2>();
        //水平
        //var horizontal = Input.GetAxis("Horizontal");
        //垂直
        //var vertical = Input.GetAxis("Vertical");
        
        //移動方式(方向)
        //var direction = new Vector3(Horizontal , Vertical,  0);
        var direction = new Vector3(moveVector2.x , moveVector2.y , 0);
        //direction = direction.normalized;//正規化，避免斜著走較快
        
        //移動向量 deltaTime = 1/FPS
        var movement = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
