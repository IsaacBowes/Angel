using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class int2roman : MonoBehaviour {

    public static string convert(int value)
    {
        int[] arabic = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] roman = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        string result = "";
        for (int i = 0; i < 13; i++)
        {
            while (value >= arabic[i])
            {
                result = result + roman[i].ToString();
                value = value - arabic[i];
            }
        }
        return result;
    }
}
