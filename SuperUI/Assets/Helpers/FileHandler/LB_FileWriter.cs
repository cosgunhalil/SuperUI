
namespace LB.Helper.FileHandler 
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;
    public class LB_Writer
    {
        public void Write(string content, string saveLocation)
        {
            try
            {
                using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
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


