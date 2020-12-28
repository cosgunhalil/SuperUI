
namespace LB.Helper.FileHandler 
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;
    public class LB_Writer
    {
        public void Write<T>(T dataObject, string path)
        {
            var data = JsonUtility.ToJson(dataObject);
            Write(path, data);
        }

        public void Write(string saveLocation, string content)
        {
            try
            {
                using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, content);
                        writer.Write(content);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(saveLocation);
                Debug.LogError(e.Message);
                throw;
            }
            finally 
            {
                Debug.LogFormat("<color=green>File is saved successfully!</color> \n " +
                    "<color=yellow>path: </color>{0} \n " +
                    "<color=cyan>content: </color>:{1}", saveLocation, content);
            }
           
        }

    }
}


