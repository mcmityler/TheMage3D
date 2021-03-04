using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SavePlayerInfo : MonoBehaviour
{
    //Save Player function called when you want to Save Player file
    public static void SavePI(PlayerInfo player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "PlayerInfo.tm";
        FileStream stream = new FileStream(path, FileMode.Create);

        PIData data = new PIData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    //Load player function called when you want to load player file
    public static PIData LoadPI()
    {
        string path = Application.persistentDataPath + "PlayerInfo.tm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PIData data = formatter.Deserialize(stream) as PIData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file no found in " + path);
            return null;
        }

    }
}
