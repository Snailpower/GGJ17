﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{

    private string leftStickHorName = "HorizontalLeftStick";

    private string leftStickVerName = "VerticalLeftStick";

    private string rightStickHorName = "HorizontalRightStick";

    private string rightStickVerName = "VerticalRightStick";

    private float horInput;

    private float verInput;

    public float movementSpeed = 1f;

    [SerializeField]
    private int playerNumber = 0;

    private Rigidbody2D rigidbodyCurrent;

    // Use this for initialization
    private void Start()
    {
        rigidbodyCurrent = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetPlayerNumber(int playerNr)
    {
        playerNumber = playerNr;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AssignInput();

        float independentSpeed = movementSpeed * Time.deltaTime;
        float angle = Mathf.Atan2(verInput, horInput);
        float amplitude = Mathf.Sqrt(verInput * verInput + horInput * horInput);

        amplitude = Mathf.Clamp(amplitude, 0, 1) * independentSpeed;
        Vector2 movementVector = new Vector2(Mathf.Cos(angle) * amplitude, Mathf.Sin(angle) * amplitude);
        
        rigidbodyCurrent.AddForce(movementVector);
    }

    private void AssignInput()
    {
        if (playerNumber <= 4)
        {
            horInput = Input.GetAxisRaw(leftStickHorName + playerNumber);

            verInput = Input.GetAxisRaw(leftStickVerName + playerNumber);
        }

        else if (playerNumber >= 5)
        {
            horInput = Input.GetAxisRaw(rightStickHorName + (playerNumber - 4));

            verInput = Input.GetAxisRaw(rightStickVerName + (playerNumber - 4));
        }
    }


}