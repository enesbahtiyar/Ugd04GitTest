using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    [Header("Settings")]
    [SerializeField] float speed;
    [SerializeField] float slideSpeed;
    [SerializeField] bool canMove = false;

    float roadWidth = 10;

    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;
    [SerializeField] PlayerAnimator playerAnimator;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        GameManager.onGameStateChanged += GameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChanged;
    }


    void Update()
    {
        if(canMove)
        {
            MoveForward();
            ManageControl();
        }
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void ManageControl()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;


            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = position;

            //transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;

        }
    }

    private void StartMoving()
    {
        canMove = true;

        playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove = false;

        playerAnimator.Idle();
    }

    private void GameStateChanged(GameState gameState)
    {
        if (gameState == GameState.Game)
            StartMoving();
    }
}
