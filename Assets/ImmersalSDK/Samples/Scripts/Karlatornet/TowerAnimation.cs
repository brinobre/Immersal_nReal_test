using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] float timeBeforeAnimation;
    [SerializeField] float animationTime;

    float yAxisValue = -240;
    bool isAnimating = false;

    private void Update()
    {
        Animate();
    }

    public void StartAnimation()
    {
        button.SetActive(false);
        StartCoroutine(SetStartPositionAndWait());
    }

    private IEnumerator SetStartPositionAndWait()
    {
        transform.position = new Vector3(transform.position.x, yAxisValue, transform.position.z);
        yield return new WaitForSeconds(timeBeforeAnimation);
        isAnimating = true;
    }

    private void Animate()
    {
        if (isAnimating)
        {
            yAxisValue += animationTime * 3;
            transform.position = new Vector3(transform.position.x, yAxisValue, transform.position.z);
            transform.Rotate(0, animationTime * 2, 0);
            if (yAxisValue >= 0)
            {
                isAnimating = false;
            }
        }
    }
}
