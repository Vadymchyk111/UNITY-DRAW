using System.IO;
using UnityEngine.Device;

public static class FileTextureSaver
{
    public static void SaveTextureToFile(byte[] bytes)
    {
        File.WriteAllBytes(Application.persistentDataPath + "/texture.png", bytes);
    }

    public static byte[] LoadTextureFromFile()
    {
        return File.ReadAllBytes(Application.persistentDataPath + "/texture.png");
    }
}