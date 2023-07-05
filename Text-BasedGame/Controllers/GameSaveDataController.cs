using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_BasedGame.Models;

namespace Text_BasedGame.Controllers
{
    public class GameSaveDataController
    {
        public bool SaveGame(GameSaveData saveData, string saveFilePath)
        {
            try
            {
                string jsonData = saveData.ToJson();
                File.WriteAllText(saveFilePath, jsonData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public GameSaveData LoadGame(string saveFilePath)
        {
            if (File.Exists(saveFilePath))
            {
                string jsonData = File.ReadAllText(saveFilePath);
                GameSaveData saveData = GameSaveData.FromJson(jsonData);
                return saveData;
            }
            else
            {
                return null;
            }
        }
    }
}
