using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private int jumpCount = 0;
    public bool isGameover = false;

    [SerializeField] private float jumpPower = 5.0f;//unityのインスペクターで値を操作できるカプセル化。メソッドからはアクセスできない
    [SerializeField] private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()//Start()よりもゲーム起動時の反応が早い
    {
        playerControls = new PlayerControls();
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerControls.Enable();
    }
    private void Update()
    {
        if(isGameover)
        {
            Invoke("Gameover", 1.0f);
        }
    }
    private void OnJump()
    {
        if (jumpCount >= 3 || isGameover)
        {
            return;//
        }
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//Vector2.upで上方向に力を与えて、ForceMode2Dで一瞬のみ力を与える
        anim.SetBool("IsJump", true);
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stage"))
        {
            jumpCount = 0;
            anim.SetBool("IsJump", false);
        }

    }
    private void OnTriggerEnter2D()
    {
        isGameover = true;
    }
    private void Gameover()
    {
        playerControls.Disable();
        UIController.instance.Gameover();
    }
}
