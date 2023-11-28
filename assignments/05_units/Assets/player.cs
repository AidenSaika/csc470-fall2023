using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Renderer SpaceShipRenderer;
    public CharacterController cc;
    public GameObject particalSYS;

    public Color selectedColor;
    public Color hoverColor;
    Color defaultColor;

    public float moveSpeed;
    public float Contain;
    public float fuel;
    public float fuelCost;
    public float CoinGet;

    bool InsideFuelArea = false;

    bool hover = false;
    public bool selected = false;

    Vector3 target;
    bool hasTarget = false;

    float gravityModifier = 2f;
    float yVelocity = 0;

    public float currentCoin = 0f;
    public float Currentfuel;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = SpaceShipRenderer.material.color;
        GameManager.SharedInstance.units.Add(this);
        Currentfuel = fuel;
        currentCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!InsideFuelArea && Currentfuel != 0)
        {
            Currentfuel = Currentfuel - fuelCost * Time.deltaTime;
        }
        if (Currentfuel <= 0)
        {
            Currentfuel = 0;
        }

        if (!cc.isGrounded)
        {
            yVelocity += Physics.gravity.y * Time.deltaTime * gravityModifier;
        }
        else
        {
            yVelocity = -1;
        }
        Vector3 amountToMove = Vector3.zero;



        if (hasTarget && Currentfuel != 0)
        {
            Vector3 ToTarget = (target - transform.position).normalized;
            float step = 5 * Time.deltaTime;
            Vector3 rotatedTowardsVector = Vector3.RotateTowards(transform.forward, ToTarget, step, 1);
            rotatedTowardsVector.y = 0;
            transform.forward = rotatedTowardsVector;
            amountToMove = transform.forward * moveSpeed * Time.deltaTime;
            amountToMove.y = yVelocity;
      
            cc.Move(amountToMove);

            if (Input.GetKeyDown(KeyCode.S))
            {
                hasTarget = false;
            }
            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                hasTarget = false;
            }
        }

    }
    private void OnDestroy()
    {
        GameManager.SharedInstance.units.Remove(this);
    }
    public void SetTarget(Vector3 t)
    {
        target = t;
        hasTarget = true;
    }

    private void OnMouseDown()
    {
        GameManager.SharedInstance.SelectUnit(this);
        SetUnitColor();
    }

    private void OnMouseEnter()
    {
        hover = true;
        SetUnitColor();
    }

    private void OnMouseExit()
    {
        hover = false;
        SetUnitColor();
    }

    public void SetUnitColor()
    {
        if (selected)
        {
            SpaceShipRenderer.material.color = selectedColor;
        }
        else if (hover)
        {
            SpaceShipRenderer.material.color = hoverColor;
        }
        else
        {
            SpaceShipRenderer.material.color = defaultColor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("savecoin"))
        {
            CoinGet = CoinGet + currentCoin;
            currentCoin = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mine"))
        {
            if (currentCoin < Contain)
            {
                currentCoin = currentCoin + MineCode.CoinProduce * Time.deltaTime*0.2f;
            }
            if (currentCoin >= Contain)
            {
                currentCoin = Contain;
            }
        }
        if (other.CompareTag("fuel"))
        {
            if (Currentfuel < fuel)
            {
                InsideFuelArea = true;
                Currentfuel = Currentfuel + 10 * Time.deltaTime;
            }
            if (Currentfuel >= fuel)
            {
                Currentfuel = fuel;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("fuel"))
        {
            InsideFuelArea = false;
        }
    }

}
