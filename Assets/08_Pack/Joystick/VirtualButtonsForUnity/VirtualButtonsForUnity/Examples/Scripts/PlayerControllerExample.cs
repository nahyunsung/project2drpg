using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum PlayerState
{
    idle,
    run,
    comboattack1,
    comboattack2,
    comboattack3,
    frontattack,
    shield
}

public class PlayerControllerExample : MonoBehaviour
{

    float delayTime = 5f;
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

        PlayerDataCalculate();
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

    public void OnComboAttackUp()
    {
        if(playerState == PlayerState.idle)
        {
            playerState = PlayerState.comboattack1;
            anim.SetBool("isAttack", true);
        }
        else if(playerState == PlayerState.comboattack1 && anim.GetBool("isAttack"))
        {
            playerState = PlayerState.comboattack2;
        }
        else if (playerState == PlayerState.comboattack2 && anim.GetBool("isAttack2"))
        {
            playerState = PlayerState.comboattack3;
        }
    }

    public void OnFrontAttack()
    {
        if(playerState == PlayerState.idle)
        {
            playerState = PlayerState.frontattack;
            anim.SetBool("isFrontAttack", true);
        }
    }

    public void OnUpAttack()
    {
        if (playerState == PlayerState.idle)
        {
            playerState = PlayerState.frontattack;
            anim.SetBool("isUpAttack", true);
        }
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
        if (playerState == PlayerState.shield)
        {
            anim.SetBool("isShield", false);
            playerState = PlayerState.idle;
        }
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
            StartCoroutine(MoveDelay());
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

    public void PlayerDataCalculate()
    {
        playerLvUpMoney = (10 * ((Mathf.Pow(1.06f, 10) - Mathf.Pow(1.06f, 10 + playerLV)) / (1 - 1.06f)));
        playerAttack = playerLvUpMoney * 0.4f;
        playerMaxHp = playerLvUpMoney * 2;
        playercurHp = playerMaxHp;
        Heart.value = playercurHp / playerMaxHp;
    }

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
