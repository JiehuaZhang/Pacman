using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using CommonType.Const;
using OperationManager.DataManager;
using OperationManager.Helper;
using OperationManager.Interface;

namespace OperationManager.StoreDataManager
{
    public class StoreData : IStoreData
    {
        private readonly ISqLiteConnection _sqLiteConnection;
        public StoreData(ISqLiteConnection sqLiteConnection)
        {
            _sqLiteConnection = sqLiteConnection;
        }

        public void StoreGameResult(Pacman[] pacmans)
        {
            var insertValue = new List<string>();
            foreach (var pacman in pacmans)
            {
                var sb = new StringBuilder();
                sb.Append("(");
                sb.Append($"'{string.Join(",", pacman.Points)}','{StringHelper.GenerateStrategyString(pacman.Strategy)}', '{pacman.Weight}','{pacman.Generation}', '{pacman.AveragePoints}','{pacman.MaxPoints}', '{pacman.PositivePointsCount}'");
                sb.Append(")");
                insertValue.Add(sb.ToString());
            }
            _sqLiteConnection.InsertConnection(insertValue);
        }

    }
}