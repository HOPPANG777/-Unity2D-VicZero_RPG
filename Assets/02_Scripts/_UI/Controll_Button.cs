using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


public enum Button_State
{ 
    Attack,
    Action,
    Skill
}



public class Controll_Button : MonoBehaviour
{
    private void Start()
    {
        On_Choice_Button(Button_State.Attack);
    }

    private void Update()
    {
        
    }

    private void On_Choice_Button(Button_State State)
    {
        var Choice_Button = All_Manager.instance.UI_M.Choice_Controll_Button;

        switch (State)
        {
            case Button_State.Attack:
                {
                    for (int i = 0; i < Choice_Button.Count; i++)
                    {
                        if (Choice_Button[i].name.Contains("Attack"))
                        {
                            Choice_Button[i].onClick.AddListener(() => All_Manager.instance.GameMode_M.On_Attack_Button());
                        }
                    }
                }
                break;
            case Button_State.Action:
                {

                }
                break;
            case Button_State.Skill:
                {

                }
                break;
        }

    }

}
