using System;
using UnityEngine;
using UnityEditor;


namespace FirstShuter.Editor
{
    public class MenuItems
    {
        [MenuItem("I am/Пункт меню №0 ")]
        private static void MenuOption()
        {
        }
        [MenuItem("I am/Пункт меню №1 %#a")]
        private static void NewMenuOption()
        {
        }
        [MenuItem("I am/Пункт меню №2 %g")]
        private static void NewNestedOption()
        {
        }
        [MenuItem("I am/Пункт меню №3 _g")]
        private static void NewOptionWithHotkey()
        {
        }



        [MenuItem("Assets/Geekbrains")]
        private static void LoadAdditiveScene()
        {
        }
        [MenuItem("Assets/Create/Geekbrains")]
        private static void AddConfig()
        {
        }
        [MenuItem("CONTEXT/Rigidbody/Geekbrains")]
        private static void NewOpenForRigidBody()
        {
        }
    }
}