using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Polenter.Serialization;
using System.Runtime.CompilerServices;
using System.ComponentModel;


namespace WenceyWang . Richman4L .Missions
{
    public class MissionGame : Game
    {
        public Mission Mission { get; protected set; }

        public override void NextDay()
        {

            base.NextDay();
        }

        public MissionGame(Mission misssion) : base()
        {

        }
    }
}
