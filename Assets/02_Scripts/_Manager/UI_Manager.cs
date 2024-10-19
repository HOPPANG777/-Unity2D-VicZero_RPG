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
    public Image Character_Panel;
    public Canvas First_Player_Unit_Panel;
    public Canvas Second_Player_Unit_Panel;
    public Canvas Third_Player_Unit_Panel;
    public Canvas Fourth_Player_Unit_Panel;

    // Enemy_Unit_State_Panel
    public Canvas Enemy_Unit_State_Panel;
    public Image Choice_Enemy_Panel;
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
    public List<TextMeshProUGUI> Character_Name_Text = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> Character_HP_Text = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> Character_SP_Text = new List<TextMeshProUGUI>();

    //Enemy_Unit
    public List<TextMeshProUGUI> Enemy_Name_Text = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> Enemy_HP_Text = new List<TextMeshProUGUI>();

    [Header("Text")]
    //Select_Controll_Panel
    public List<Text> Choice_Controll_Button_Text = new List<Text>();
    public List<Text> Attack_Choice_Button_Text = new List<Text>();
    public List<Text> Skill_Choice_Button_Text = new List<Text>();
    public List<Text> Action_Choice_Button_Text = new List<Text>();

    [Header("Button")]
    public List<Button> Choice_Controll_Button = new List<Button>();
    public List<Button> Attack_Choice_Button = new List<Button>();
    public List<Button> Skill_Choice_Button = new List<Button>();
    public List<Button> Action_Choice_Button = new List<Button>();

    [Header("Image")]
    // Player_Unit
    public List<Image> Character_Current_HP_Image = new List<Image>();
    public List<Image> Character_HP_Bar_Image = new List<Image>();
    public List<Image> Character_Current_SP_Image = new List<Image>();
    public List<Image> Character_SP_Bar_Image = new List<Image>();

    // Enemy_Unit
    public List<Image> Enemy_Current_HP_Image = new List<Image>();
    public List<Image> Enemy_HP_Bar_Image = new List<Image>();

    //Select_Controlle_Panel
    public Image Choice_Controll_Image;
    public Image Attack_Choice_Image;
    public Image Skill_Choice_Image;
    public Image Action_Choice_Image;


    void Set_UI()
    {
        
    }
}
