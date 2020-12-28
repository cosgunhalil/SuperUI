
namespace LB.Helper.FileHandler 
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;

    public class LB_Loader
    {
        public T Load<T>(string path)
        {
            var data = ReadDataFromPath(path);
            return JsonUtility.FromJson<T>(data);
        }

        public string ReadDataFromPath(string path)
        {
            string data = null;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        var dataString = binaryFormatter.Deserialize(fileStream) as string;

                        data = reader.ReadToEnd();

                        return dataString;
                    }
                }
            }
            catch (System.Exception exception)
            {
                Debug.LogError(exception);
            }

            return data;
        }
    }

}

