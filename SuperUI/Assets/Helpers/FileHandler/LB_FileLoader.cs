
//TODO: refactor - seperate binary and pure loader
//TODO: Apply Decorator Design Pattern
namespace LB.Helper.FileHandler 
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;

    public class LB_Loader
    {
        public string Load(string path)
        {
            string data = null;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        data = reader.ReadToEnd();
                        return data;
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
