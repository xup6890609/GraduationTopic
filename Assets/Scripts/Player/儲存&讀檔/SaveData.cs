using System.Collections;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    private static SaveData current;
    internal readonly int hp;
    internal object position;

    public static SaveData data
    {
        get
        {
            if(current == null)
            {
                current = new SaveData();
            }
            return current;
        }
    }

    public int level { get; internal set; }
}
