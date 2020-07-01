using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    class FileIOService
    {
        private string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<TaskModel> LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TaskModel>();
            }
            
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskModel>>(fileText);
            }

            
        }
        public void SaveData(object taskDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(taskDataList);
                writer.Write(output);
            }
        }
    }
}
