using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public int Keys = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddKey()
    {
        Keys++;
    }


    public bool UseKey()
    {
        if(Keys > 0) 
        {
            Keys--;
            return true;
        }
        return false;
    }
}
