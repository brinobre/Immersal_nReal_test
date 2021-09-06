using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class nRealTowerAnimation : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] float timeBeforeAnimation;
    [SerializeField] float animationTime;

    float yAxisValue = -240;
    bool isAnimating = false;

    private void Start()
    {
        if (NRInput.GetButtonDown(ControllerButton.TRIGGER))
        {
            StartAnimation();
        }
    }

    private void Update()
    {
        //returns a int value of how many available controllers currently
        NRInput.GetAvailableControllersCount();

        //returns true if a Trigger button is currently pressed
        NRInput.GetButton(ControllerButton.TRIGGER);

        //returns true if a Trigger button was pressed down this frame
        NRInput.GetButtonDown(ControllerButton.TRIGGER);

        //returns true if a Trigger button was released this frame
        NRInput.GetButtonUp(ControllerButton.TRIGGER);

        //returns Vector3.zero if controller is 3DoF, otherwise returns the position of the domain controller
        NRInput.GetPosition();

        //returns the rotation of the domain controller
        NRInput.GetRotation();

        //returns the ControllerType of the domain controller
        ControllerType controllerType = NRInput.GetControllerType();

        //returns true if the touchpad is being touched
        NRInput.IsTouching();

        //returns a Vector2 value of the touchpad, x(-1f ~ 1f), y(-1f ~ 1f)
        NRInput.GetTouch();

        //returns a Vector3 value of gyro if supports
        NRInput.GetGyro();

        //to get what hand mode is using now, left-hand or right-hand
        ControllerHandEnum domainHand = NRInput.DomainHand;

        //the same as NRInput.GetRotation()
        NRInput.GetRotation(NRInput.DomainHand);

        //returns the rotaion of the left hand controller
        NRInput.GetRotation(ControllerHandEnum.Right);


        Animate();
    }

    //function runs when button is pressed
    public void StartAnimation()
    {

//        button.SetActive(false);
        //Starts the coroutine
        StartCoroutine(SetStartPositionAndWait());
    }

    private IEnumerator SetStartPositionAndWait()
    {
        transform.position = new Vector3(transform.position.x, yAxisValue, transform.position.z);
        yield return new WaitForSeconds(timeBeforeAnimation);
        //coroutine turns the isAnimating bool to "true"
        isAnimating = true;
    }

    private void Animate()
    {
        //Debug.Log("animate void activated");

        //whilst isAnimating is "true", run "isAnimating
        if (isAnimating)
        {
            yAxisValue += animationTime * 3;
            transform.position = new Vector3(transform.position.x, yAxisValue, transform.position.z);
            transform.Rotate(0, animationTime * 2, 0);
            if (yAxisValue >= 0)
            {
                isAnimating = false;
            }
            Debug.Log("animating");
        }
    }
}
