using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : Singleton<UI_Manager>
{
    [Header("Canvas")]
    // Canvas
    public Canvas Battle_Panel;

    // Player_Unit_State_Panel
    public Canvas Player_Unit_State_Panel;
    public Canvas Character_Panel;
    public Canvas First_Player_Unit_Panel;
    public Canvas Second_Player_Unit_Panel;
    public Canvas Third_Player_Unit_Panel;
    public Canvas Fourth_Player_Unit_Panel;

    // Enemy_Unit_State_Panel
    public Canvas Enemy_Unit_State_Panel;
    public Canvas Choice_Enemy_Panel;
    public Canvas First_Enemy_Unit_Panel;
    public Canvas Second_Enemy_Unit_Panel;
    public Canvas Third_Enemy_Unit_Panel;
    public Canvas Fourth_Enemy_Unit_Panel;

    // Select_Controlle_Panel
    public Canvas Select_Controll_Panel;
    public Canvas Choice_Controll_Panel;
    public Canvas Attack_Choice_Panel;
    public Canvas Skill_Choice_Panel;
    public Canvas Action_Choice_Panel;

    [Header("TextMeshPro")]
    // Player_Unit
    public TextMeshPro First_Character_Name_Text;
    public TextMeshPro First_Character_HP_Text;
    public TextMeshPro First_Character_SP_Text;

    public TextMeshPro Second_Character_Name_Text;
    public TextMeshPro Second_Character_HP_Text;
    public TextMeshPro Second_Character_SP_Text;

    public TextMeshPro Third_Character_Name_Text;
    public TextMeshPro Third_Character_HP_Text;
    public TextMeshPro Third_Character_SP_Text;

    public TextMeshPro Fourth_Character_Name_Text;
    public TextMeshPro Fourth_Character_HP_Text;
    public TextMeshPro Fourth_Character_SP_Text;

    //Enemy_Unit
    public TextMeshPro First_Enemy_Name_Text;
    public TextMeshPro First_Enemy_HP_Text;

    public TextMeshPro Second_Enemy_Name_Text;
    public TextMeshPro Second_Enemy_HP_Text;

    public TextMeshPro Third_Enemy_Name_Text;
    public TextMeshPro Third_Enemy_HP_Text;

    public TextMeshPro Fourth_Enemy_Name_Text;
    public TextMeshPro Fourth_Enemy_HP_Text;

    [Header("Text")]
    //Select_Controll_Panel
    public Text Attack_Button_Text;
    public Text Skill_Button_Text;
    public Text Action_Button_Text;

    public Text Attack_1_Button_Text;
    public Text Attack_2_Button_Text;
    public Text Attack_3_Button_Text;
    public Text Attack_Back_Button_Text;

    public Text Skill_1_Button_Text;
    public Text Skill_2_Button_Text;
    public Text Skill_3_Button_Text;
    public Text Skill_Back_Button_Text;

    public Text Action_1_Button_Text;
    public Text Action_2_Button_Text;
    public Text Action_3_Button_Text;
    public Text Action_Back_Button_Text;

    [Header("Button")]
    public Button Attack_Button;
    public Button Skill_Button;
    public Button Action_Button;

    public Text Attack_1_Button;
    public Text Attack_2_Button;
    public Text Attack_3_Button;
    public Text Attack_Back_Button;

    public Text Skill_1_Button;
    public Text Skill_2_Button;
    public Text Skill_3_Button;
    public Text Skill_Back_Button;

    public Text Action_1_Button;
    public Text Action_2_Button;
    public Text Action_3_Button;
    public Text Action_Back_Button;

    [Header("Image")]
    // Player_Unit
    public Image First_Character_Current_HP_Image;
    public Image First_Character_HP_Bar_Image;
    public Image First_Character_Current_SP_Image;
    public Image First_Character_SP_Bar_Image;

    public Image Second_Character_Current_HP_Image;
    public Image Second_Character_HP_Bar_Image;
    public Image Second_Character_Current_SP_Image;
    public Image Second_Character_SP_Bar_Image;

    public Image Third_Character_Current_HP_Image;
    public Image Third_Character_HP_Bar_Image;
    public Image Third_Character_Current_SP_Image;
    public Image Third_Character_SP_Bar_Image;

    public Image Fourth_Character_Current_HP_Image;
    public Image Fourth_Character_HP_Bar_Image;
    public Image Fourth_Character_Current_SP_Image;
    public Image Fourth_Character_SP_Bar_Image;

    // Enemy_Unit
    public Image First_Enemy_Current_HP_Image;
    public Image First_Enemy_HP_Bar_Image;

    public Image Second_Enemy_Current_HP_Image;
    public Image Second_Enemy_HP_Bar_Image;

    public Image Third_Enemy_Current_HP_Image;
    public Image Third_Enemy_HP_Bar_Image;

    public Image Fourth_Enemy_Current_HP_Image;
    public Image Fourth_Enemy_HP_Bar_Image;

    //Select_Controlle_Panel
    public Image Choice_Controll_Image;
    public Image Attack_Choice_Image;
    public Image Skill_Choice_Image;
    public Image Action_Choice_Image;


    void Set_UI()
    {
        
    }
}
