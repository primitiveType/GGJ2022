using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeMonkey : MonoBehaviour
{
    [SerializeField] private GameObject[] leftArmSlotPivots;
    [SerializeField] private GameObject[] rightArmSlotPivots;
    [SerializeField] private GameObject[] leftArmPrefabs;
    [SerializeField] private GameObject[] rightArmPrefabs;
    [SerializeField] private Light winnerLight;
    [SerializeField] private Location nextLocation;

    [SerializeField] private Monkey[] monkeys;

    private GameObject[] leftArms = new GameObject[3];
    private GameObject[] rightArms = new GameObject[3];

    
    private int[] leftArmSlot = new int[3];
    private int[] rightArmSlot = new int[3];
    void Start()
    {
        for(var i=0;i<3;i++) {
            GameObject leftArm = Instantiate(leftArmPrefabs[i], leftArmSlotPivots[i].transform, false);
            leftArm.transform.localPosition = Vector3.zero;
            leftArms[i] = leftArm;
            leftArmSlot[i] = i;
            GameObject rightArm = Instantiate(rightArmPrefabs[i], rightArmSlotPivots[i].transform, false);
            rightArms[i] = rightArm;
            rightArm.transform.localPosition = Vector3.zero;
            rightArmSlot[i] = i;
        }
        winnerLight.enabled = false;
        //simulate scrambling, this way I know it can be solved
        // ShiftRight();
        // ShiftRight();
        // ShiftLeft();

        ShiftLeft();
        ShiftRight();

        RotateArms();

        ShiftRight();
        ShiftLeft();
        ShiftLeft();

        SetProperPivots();
    }

    public void Clicked(Monkey monkey) {
        switch(monkey.Slot) {
            case 0:
                ShiftRight();
                ShiftLeft();
                ShiftLeft();
                break;
            case 1:
                // ShiftRight();
                // ShiftRight();
                // ShiftLeft();
                RotateArms();
                break;
            case 2:
                ShiftLeft();
                ShiftRight();  
                break;  
            default:
                break;            
        }
        SetProperPivots();
        if (CheckWin()) {
            SetWinCondition();
        }
    }
    private void ShiftRight() {
        int tmp = rightArmSlot[0];
        rightArmSlot[0] = rightArmSlot[1];
        rightArmSlot[1] = rightArmSlot[2];
        rightArmSlot[2] = tmp;
    }

    private void ShiftLeft() {
        int tmp = leftArmSlot[0];
        leftArmSlot[0] = leftArmSlot[1];
        leftArmSlot[1] = leftArmSlot[2];
        leftArmSlot[2] = tmp;
    }

    private void RotateArms() {
        int tmp = leftArmSlot[0];
        leftArmSlot[0] = leftArmSlot[2];
        leftArmSlot[2] = tmp;

        tmp = rightArmSlot[0];
        rightArmSlot[0] = rightArmSlot[2];
        rightArmSlot[2] = tmp;
    }

    private void SetProperPivots() {
        for(var i=0;i<3;i++) {
            Transform myTransform = leftArms[leftArmSlot[i]].transform;
            myTransform.SetParent(leftArmSlotPivots[i].transform);
            myTransform.localPosition = Vector3.zero;
            myTransform = rightArms[rightArmSlot[i]].transform;
            myTransform.SetParent(rightArmSlotPivots[i].transform);
            myTransform.localPosition = Vector3.zero;
        }
    }

    public void SetWinCondition() {
        winnerLight.enabled=true;
        foreach (Monkey monkey in monkeys) {
            monkey.SetDisabled();
        }
        nextLocation.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckWin(){
        for (int i=0;i<3;i++) {
            if (rightArmSlot[i] != i || leftArmSlot[i] != i) {
                return false;
            }
        }
        return true;
    }
}
