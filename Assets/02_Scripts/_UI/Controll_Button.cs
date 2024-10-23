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
        On_Choice_Button(Button_State.Action);
        On_Choice_Button(Button_State.Skill);
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
                            Choice_Button[i].onClick.AddListener(() => Activated_Attack_Controll_Panel());
                        }
                    }
                }
                break;
            case Button_State.Action:
                {
                    for (int i = 0; i < Choice_Button.Count; i++)
                    {
                        if (Choice_Button[i].name.Contains("Action"))
                        {
                            Choice_Button[i].onClick.AddListener(() => Activated_Action_Controll_Panel());
                        }
                    }
                }
                break;
            case Button_State.Skill:
                {
                    for (int i = 0; i < Choice_Button.Count; i++)
                    {
                        if (Choice_Button[i].name.Contains("Skill"))
                        {
                            Choice_Button[i].onClick.AddListener(() => Activated_Skill_Controll_Panel());
                        }
                    }
                }
                break;
        }

    }

    private void Activated_Attack_Controll_Panel()
    {
        var Attack_Buttons = All_Manager.instance.UI_M.Attack_Choice_Button;
        var Choice_Panel = All_Manager.instance.UI_M.Choice_Controll_Panel;
        var Attack_Panel = All_Manager.instance.UI_M.Attack_Choice_Panel;

        {
            Choice_Panel.gameObject.SetActive(false);

            Attack_Panel.gameObject.SetActive(true);
        }

        {
            //Attack_Buttons[0].onClick.AddListener(() => );
            //Attack_Buttons[1].onClick.AddListener(() => );
            //Attack_Buttons[2].onClick.AddListener(() => );
            Attack_Buttons[3].onClick.AddListener(() => Activated_Controll_Choice_Panel());
        }
    }

    private void Activated_Skill_Controll_Panel()
    {
        var Skill_Buttons = All_Manager.instance.UI_M.Skill_Choice_Button;
        var Choice_Panel = All_Manager.instance.UI_M.Choice_Controll_Panel;
        var Skill_Panel = All_Manager.instance.UI_M.Skill_Choice_Panel;

        {
            Choice_Panel.gameObject.SetActive(false);

            Skill_Panel.gameObject.SetActive(true);
        }

        {
            //Skill_Buttons[0].onClick.AddListener(() => );
            //Skill_Buttons[1].onClick.AddListener(() => );
            //Skill_Buttons[2].onClick.AddListener(() => );
            Skill_Buttons[3].onClick.AddListener(() => Activated_Controll_Choice_Panel());
        }
    }

    private void Activated_Action_Controll_Panel()
    {
        var Action_Buttons = All_Manager.instance.UI_M.Action_Choice_Button;
        var Choice_Panel = All_Manager.instance.UI_M.Choice_Controll_Panel;
        var Action_Panel = All_Manager.instance.UI_M.Action_Choice_Panel;

        {
            Choice_Panel.gameObject.SetActive(false);

            Action_Panel.gameObject.SetActive(true);
        }

        {
            //Action_Buttons[0].onClick.AddListener(() => );
            //Action_Buttons[1].onClick.AddListener(() => );
            //Action_Buttons[2].onClick.AddListener(() => );
            Action_Buttons[3].onClick.AddListener(() => Activated_Controll_Choice_Panel());
        }
    }

    private void Activated_Controll_Choice_Panel()
    {
        var Choice_Panel = All_Manager.instance.UI_M.Choice_Controll_Panel;
        var Attack_Panel = All_Manager.instance.UI_M.Attack_Choice_Panel;
        var Skill_Panel = All_Manager.instance.UI_M.Skill_Choice_Panel;
        var Action_Panel = All_Manager.instance.UI_M.Action_Choice_Panel;

        {
            Attack_Panel.gameObject.SetActive(false);
            Skill_Panel.gameObject.SetActive(false);
            Action_Panel.gameObject.SetActive(false);

            Choice_Panel.gameObject.SetActive(true);
        }
    }
}
