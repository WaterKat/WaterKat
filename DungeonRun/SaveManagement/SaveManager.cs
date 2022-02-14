using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WaterKat.DungeonRun.SaveManagement
{
    public static class SaveManager
    {
        private static Environment.SpecialFolder rootPath = Environment.SpecialFolder.MyDocuments;
        private static string relativePath = @"\WaterKatLLC\DungeonRun\Saves";
        private static string fileName = "save_";
        private static string fileType = ".drsave";

        private static void CreateSaveDirectory()
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;

            Directory.CreateDirectory(completeDirectory);
        }

        public static bool SaveDirectoryExists()
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            return Directory.Exists(completeDirectory);
        }

        public static bool SaveFileExists(int _slot)
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            string filePath = completeDirectory + @"\" + fileName + _slot.ToString() + fileType;
            return File.Exists(filePath);
        }

        private static FileStream CreateSaveFile(int _slot)
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            string filePath = completeDirectory + @"\" + fileName + _slot.ToString() + fileType;

            return File.Create(filePath);
        }
        private static FileStream OpenSaveFile(int _slot)
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            string filePath = completeDirectory + @"\" + fileName + _slot.ToString() + fileType;

            return File.OpenWrite(filePath);
        }

        public static void SaveData(int _slot, GameData _gameData)
        {
            if (!SaveDirectoryExists())
                CreateSaveDirectory();

            FileStream fileStream = null;

            if (!SaveFileExists(_slot))
            {
                fileStream = CreateSaveFile(_slot);
            }
            else
            {
                fileStream = OpenSaveFile(_slot);
            }

            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            string filePath = completeDirectory + @"\" + fileName + _slot.ToString() + fileType;

            TextWriter writer = null;
            try
            {
                string jsonValues = Newtonsoft.Json.JsonConvert.SerializeObject(_gameData);
                writer = new StreamWriter(fileStream);
                writer.Write(jsonValues);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        public static bool LoadData(int _slot, out GameData _gameData)
        {
            GameData newGameData = new GameData();

            if (!SaveDirectoryExists())
            {
                _gameData = newGameData;
                return false;
            }
            if (!SaveFileExists(_slot))
            {
                _gameData = newGameData;
                return false;
            }

            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            string filePath = completeDirectory + @"\" + fileName + _slot.ToString() + fileType;

            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                string fileContents = reader.ReadToEnd();

                newGameData = JsonConvert.DeserializeObject<GameData>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            _gameData = newGameData;
            return true;
        }
    }
}
