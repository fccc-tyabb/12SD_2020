using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3O1_Task1
{
    class ScoreRecord
    {
        public string Player1Score { get; set; }
        public string Player2Score { get; set; }

        public ScoreRecord(string p1, string p2)
        {
            Player1Score = p1;
            Player2Score = p2;
        }
    }
}
