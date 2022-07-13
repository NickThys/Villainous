using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Villainous.Domain;

namespace Villainous.WinForm
{
    public partial class Game : Form
    {
        public Game(string gameCode,string playerName,List<Player> players)
        {
            InitializeComponent();
        }
    }
}
