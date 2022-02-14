using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterKat.DungeonRun.SaveManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterKat.DungeonRun.SaveManagement.Tests
{
    [TestClass()]
    public class SaveManagerTests
    {
        [TestMethod()]
        public void SaveDataTest()
        {
            SaveManager saveManager = new SaveManager();
            GameData gameData1 = new GameData();
            GameData gameData2;

            int slot = 0;

            saveManager.SaveData(slot, gameData1);
            saveManager.LoadData(slot, out gameData2);

            Assert.AreEqual(gameData1, gameData2);
        }

        [TestMethod()]
        public void LoadDataTest()
        {
            SaveManager saveManager = new SaveManager();
            GameData gameData1 = new GameData();
            GameData gameData2;

            int slot = 0;

            saveManager.SaveData(slot, gameData1);
            saveManager.LoadData(slot, out gameData2);

            Assert.AreEqual(gameData1, gameData2);
        }
    }
}