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
        private static string version = "0.0.1";

        private static Environment.SpecialFolder rootPath = Environment.SpecialFolder.MyDocuments;
        private static string relativePath = @"\WaterKatLLC\DungeonRun\Saves";
        private static string fileName = "save_";
        private static string fileType = ".drsave";

        private static string GetSaveDirectory()
        {
            string completeDirectory = Environment.GetFolderPath(rootPath) + relativePath;
            return completeDirectory;
        }
        private static string GetSaveFilePath(int _slot)
        {
            string filePath = GetSaveDirectory() + @"\" + fileName + _slot.ToString() + fileType;
            return filePath;
        }

        private static void CreateSaveDirectory()
        {
            Directory.CreateDirectory(GetSaveDirectory());
        }

        public static bool SaveDirectoryExists()
        {
            return Directory.Exists(GetSaveDirectory());
        }

        public static bool SaveFileExists(int _slot)
        {
            return File.Exists(GetSaveFilePath(_slot));
        }

        private static FileStream CreateSaveFile(int _slot)
        {
            return File.Create(GetSaveFilePath(_slot));
        }
        private static FileStream OpenSaveFile(int _slot)
        {
            return File.OpenWrite(GetSaveFilePath(_slot));
        }

        public static void SaveData(int _slot, GameData _gameData)
        {
            if (!SaveDirectoryExists())
                CreateSaveDirectory();

            FileStream fileStream = CreateSaveFile(_slot);

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

            TextReader reader = null;
            try
            {
                reader = new StreamReader(GetSaveFilePath(_slot));
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
