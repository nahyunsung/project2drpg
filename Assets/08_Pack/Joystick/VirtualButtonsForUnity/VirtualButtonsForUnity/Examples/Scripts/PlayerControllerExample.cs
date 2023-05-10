using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControllerExample : MonoBehaviour
{
    public enum PlayerState
    {
        idle,
        run,
        attack,
        shield
    }

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] public Animator anim;
    [SerializeField] private Transform dunposition;
    [SerializeField] private List<Material> mat;
    [SerializeField] private GameObject attackBox;

    protected CharacterController controller;
    protected PlayerActionsExample playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    Vector3 move;
    bool isDunGo = false;
    bool isDunExit = false;
    public PlayerState playerState = PlayerState.idle;
    public Slider Heart;

    public int playerLV = 1;
    public float playerAttack;
    public float playerLvUpMoney;
    public float playerMaxHp;
    public float playercurHp;

    private void Awake()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
        playerInput = new PlayerActionsExample();

        playerLvUpMoney = (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + playerLV)) / (1 - 1.06f)));
        playerAttack = playerLvUpMoney * 0.4f;
        playerMaxHp = playerLvUpMoney * 2;
        playercurHp = playerMaxHp;
        Heart.value = playercurHp / playerMaxHp;
    }

    private void FixedUpdate()
    {
        if (move.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Update()
    {
        if(playerState == PlayerState.idle || playerState == PlayerState.run)
        {
            Move();
        }


        if (isDunGo)
        {
            gameObject.transform.localPosition = dunposition.position;
            RenderSettings.skybox = mat[1];
            isDunGo = false;
        }
        if (isDunExit)
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            RenderSettings.skybox = mat[0];
            isDunExit = false;
        }

        if(playercurHp < 0)
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            RenderSettings.skybox = mat[0];
            playercurHp = playerMaxHp;
            Heart.value = playercurHp / playerMaxHp;
        }
    }

    public void OnAttackDown()
    {
        if(playerState == PlayerState.idle)
        {
            playerState = PlayerState.attack;
            anim.SetBool("isAttack", true);
            attackBox.SetActive(true);
            //Debug.Log(anim.GetBool("isAttack"));
        }
    }

    public void OnAttackUp()
    {
        anim.SetBool("isAttack", false);
        attackBox.SetActive(false);
        playerState = PlayerState.idle;
    }

    public void OnShieldDown()
    {
        if(playerState == PlayerState.idle)
        {
            playerState = PlayerState.shield;
            anim.SetBool("isShield", true);
        }
    }

    public void OnShieldUp()
    {
        anim.SetBool("isShield", false);
        playerState = PlayerState.idle;
    }

    public void DungeonGo()
    {
        isDunGo = true;
    }

    public void DungeonExit()
    {
        isDunExit = true;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Move()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        //Debug.Log(move);
        

        if (move != Vector3.zero)
        {
            playerState = PlayerState.run;
            if (move.x == -1)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            playerState = PlayerState.idle;
        }
        

        // bool jumpPress = playerInput.Player.Jump.IsPressed();
        /*
        bool jumpPress = playerInput.Player.Jump.triggered;
        if (jumpPress && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        */
        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    public void AttackDamage(float damage)
    {
        if(playerState == PlayerState.shield)
        {
            return;
        }
        playercurHp -= damage;
        Heart.value = playercurHp / playerMaxHp;
    }
}
