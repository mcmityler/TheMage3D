using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SavePlayerController : MonoBehaviour
{
    //Save Player function called when you want to Save Player file
    public static void SavePC(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "PlayerController.tm";
        FileStream stream = new FileStream(path, FileMode.Create);

        PCData data = new PCData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    //Load player function called when you want to load player file
    public static PCData LoadPC()
    {
        string path = Application.persistentDataPath + "PlayerController.tm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PCData data = formatter.Deserialize(stream) as PCData;
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
