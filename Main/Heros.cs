using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    ///<summary>茂凯</summary>
    
    class aHero : Hero
    {

    }
    class LFL : Hero
    {

    }
    class KGM : Hero
    {

    }
    class FLJME : Hero
    {

    }
    class WLBE : Hero
    {

    }
    class WLK : Hero
    {

    }
    class WJ : Hero
    {

    }
    class WE : Hero
    {

    }
    class XDL : Hero
    {

    }
    class LKD : Hero
    {

    }
    class MAOKAI : Hero
    {
        public MAOKAI(int level,int id)
        {
            heroName = "茂凯";
            heroLevel = level;
            if (id <= 27)
            {
                color = Blue;
            }
            else
            {
                color = Red;
            }
            init();
        }
        public new void Skill()
        {
            target.delHP(300, this);
            LinkToClient.SendCommand("fightLog " + square.squareId + " 茂凯" + "发动了技能");
        }
    }
}
