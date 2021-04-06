using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class InteractableObject :MonoBehaviour
    {
        public Camera Camera;
        public Vector3 PlayerPostion;
        public GameObject Object;
        public bool DialogDone { get; private set; } = false;
        private int _currentDialog = 0;

        public void Talk(Text text)
        {
            DialogDone = false;
            switch (_currentDialog)
            {
                case 0:
                    {
                        text.text = "Yeet";
                        _currentDialog++;
                        break;
                    }
                case 1:
                    {
                        text.text = "Double Yeet";
                        _currentDialog++;
                        break;
                    }
                case 2:
                    {
                        text.text = @"
                                    You know they say that all men are created equal,
                                    but you look at me and you look at Samoa Joe and you can see that statement
                                    is not true.
                                    See, normally if you go one on one with another wrestler,
                                    you got a 50/50 chance of winning.
                                    But I'm a genetic freak and I'm not normal!
                                    So you got a 25%, AT BEST, at beat me.
                                    Then you add Kurt Angle to the mix, your chances of winning drastic go down.
                                    See the 3 way at Sacrifice, you got a 33 1/3 chance of winning,
                                    but I, I got a 66 and 2/3 chance of winning,
                                    because Kurt Angle KNOWS he can't beat me and he's not even gonna try!
                                    So Samoa Joe, you take your 33 1/3 chance,
                                    minus my 25% chance and you got an 8 1/3 chance of winning at Sacrifice.
                                    But then you take my 75% chance of winning, if we was to go one on one,
                                    and then add 66 2/3 per cents,
                                    I got 141 2/3 chance of winning at Sacrifice.
                                    See Joe, the numbers don't lie, and they spell disaster for you at Sacrifice.
                                    ";
                        _currentDialog++;
                        break;
                    }
                case 3:
                    {
                        text.text = "ByeBye";
                        _currentDialog = 0;
                        DialogDone = true;
                        break;
                    }
            }
        }
    }

}
