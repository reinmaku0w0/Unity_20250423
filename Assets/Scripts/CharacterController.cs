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
    private InputAction jumpAction; //跳躍行為

    void Start()
    {
        moveAction =  playerInput.actions.FindAction("Move");
        moveAction =  playerInput.actions.FindAction("Jump");
        jumpAction.performed += JumpActionOnperformed;
    }

    private void JumpActionOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
    }

    private bool dead;

    void Update()
    {
        if (dead) return;
        if (jumpAction.WasPressedThisFrame())
        {
            Debug.Log("Jump");
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
