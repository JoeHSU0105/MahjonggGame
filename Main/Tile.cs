using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Mahjongg
{
    public enum TileType
    {
        None = 0,
        [Description("萬")]
        Wan,
        [Description("筒")]
        Circle,
        [Description("條")]
        Bamboo,
        Dragon,
        Wind,
        Flower
    }



    public class Tiles
    {
        public List<Tile> item = new List<Tile>();

        public int Count
        {
            get
            {
                return item.Count;
            }
        }
    }

    public class Tile
    {

        TileType _type = TileType.None;
        int _num = 0;

        public Tile(TileType type, int num)
        {
            _type = type;
            _num = num;
        }

        public TileType Type
        {
            get
            {
                return _type;
            }
        }

        public int Num
        {
            get
            {
                return _num; ;
            }
        }

        private string GetWindString(int value)
        {
            if (value == 1)
                return "東";
            else if (value == 2)
                return "南";
            else if (value == 3)
                return "西";
            else if (value == 4)
                return "北";
            else
                return "emptyWind";
        }

        private string GetDroganString(int value)
        {
            if (value == 1)
                return "中";
            else if (value == 2)
                return "發";
            else if (value == 3)
                return "白";
            else
                return "emptyDrogan";
        }

        /// <summary>
        ///  11: 春 ; 21: 梅
        ///  12: 夏 ; 22: 蘭
        ///  13: 秋 ; 23: 竹
        ///  14: 冬 ; 24: 菊
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetFlowerString(int value)
        {
            switch (value)
            {
                case 11:
                    return "春";
                case 12:
                    return "夏";
                case 13:
                    return "秋";
                case 14:
                    return "冬";
                case 21 :
                    return "梅";
                case 22 :
                    return "蘭";
                case 23:
                    return "竹";
                case 24:
                    return "菊";
                default:
                    return "empty Flower";


            }
        }

        public static string GetEnumDescription(Enum value)
        {


            FieldInfo fi = value.GetType().GetField(value.ToString());



            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(


            typeof(DescriptionAttribute), false);



            if (attributes.Length > 0)


                return attributes[0].Description;



            return value.ToString();


        }

        public string GetString()
        {
            switch (this.Type)
            {
                case TileType.Bamboo:
                case TileType.Circle:
                case TileType.Wan:
                    return string.Format("{0} {1}", this.Num, GetEnumDescription(this.Type));
                    
                case TileType.Dragon:
                    return GetDroganString(this.Num);

                case TileType.Flower:
                    return GetFlowerString(this.Num);

                case TileType.Wind:
                    return GetWindString(this.Num);

                default:
                    return "empty";

            }
        }

        public bool Equels(Tile value)
        {
            if (value.Num == this.Num && value.Type == this.Type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
