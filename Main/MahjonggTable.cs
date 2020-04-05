using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Mahjongg
{
    public class MahjonggTable
    {
        #region var
        const int PerTileCount = 16;    // 每人持有的牌數

        private Tiles _tileList = new Tiles();
        private Tiles _resortList = new Tiles();
        private int _diceNumber = 0;
        private int _tileIdx = 0;   // 目前取到牌的第幾個位置

        #endregion
        

        public MahjonggTable()
        {
            InitTiles();
        }

        #region property

        private int TileIdx
        {
            get
            {
                return _tileIdx;
            }
            set
            {
                _tileIdx = value;
            }
        }

        public Tiles tiles
        {
            get
            {
                return _resortList;

            }
        }
        public int TileCount
        {
            get
            {
                return _tileList.item.Count();
            }
        }

        #endregion

        #region private function
        
        private void InitTiles()
        {
            int tmpNum = 0;
            TileType tmpType = TileType.None;

            // 放進萬子
            tmpType = TileType.Wan;
            for (int i = 0; i < 9; i++)
            {
                tmpNum = i + 1;

                for (int j = 0; j < 4; j++)
                {
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
                }
            }


            // 放進條子
            tmpType = TileType.Bamboo;
            for (int i = 0; i < 9; i++)
            {
                tmpNum = i + 1;
                for (int j = 0; j < 4; j++)
                {
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
                }
            }

            // 放進筒子
            tmpType = TileType.Circle;
            for (int i = 0; i < 9; i++)
            {
                tmpNum = i + 1;
                for (int j = 0; j < 4; j++)
                {
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
                }
            }

            // 放進風牌
            tmpType = TileType.Wind;
            for (int i = 0; i < 4; i++)
            {
                tmpNum = i + 1;
                for (int j = 0; j < 4; j++)
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
            }

            // 放進三元牌
            // 1: 紅中
            // 2: 發財
            // 3: 白板
            tmpType = TileType.Dragon;
            for (int i = 0; i < 3; i++)
            {
                tmpNum = i + 1;
                for (int j = 0; j < 4; j++)
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
            }

            // 放進花牌
            //  11: 春 ; 21: 梅
            //  12: 夏 ; 22: 蘭
            //  13: 秋 ; 23: 竹
            //  14: 冬 ; 24: 菊

            tmpType = TileType.Flower;
            for (int i = 0; i < 2; i++)
            {
                tmpNum = (i + 1) * 10;
                for (int j = 0; j < 4; j++)
                {
                    tmpNum += 1;
                    _tileList.item.Add(new Tile(tmpType, tmpNum));
                }
            }

            for (int i = 0; i < _tileList.item.Count; i++)
            {
                _resortList.item.Add(_tileList.item[i]);
            }

            Shuffle(_resortList);
        }
       
        private void Shuffle(Tiles list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.item.Count;

            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));

                int k = (box[0] % n);
                n--;
                Tile value = list.item[k];
                list.item[k] = list.item[n];
                list.item[n] = value;
            }

        }

        #endregion

        #region public function

        /// <summary>
        /// 洗牌
        /// </summary>
        public void Shuffle()
        {
            _resortList.item.Clear();

            for (int i = 0; i < _tileList.item.Count; i++)
            {
                _resortList.item.Add(_tileList.item[i]);
            }

            Shuffle(_resortList);
        }

        /// <summary>
        /// 分牌
        /// </summary>
        /// <param name="diceNum">骰子數</param>
        public void ArrangeTile(int diceNum, Tiles firOne, Tiles secOne, Tiles thirdOne, Tiles forOne)
        {
            // version 1 不理會骰子數, 直接給牌
            firOne.item.Clear();
            secOne.item.Clear();
            thirdOne.item.Clear();
            forOne.item.Clear();

            TileIdx =0;

            for(int i=0; i<PerTileCount; i++)
            {
                firOne.item.Add(_resortList.item[TileIdx]);
                TileIdx += 1;
                secOne.item.Add(_resortList.item[TileIdx]);
                TileIdx += 1;
                thirdOne.item.Add(_resortList.item[TileIdx]);
                TileIdx += 1;
                forOne.item.Add(_resortList.item[TileIdx]);
                TileIdx += 1;
            }

            
        }

        /// <summary>
        /// 擲骰子
        /// </summary>
        /// <returns></returns>
        public int TakeDice()
        {
            List<int> diceNums = new List<int>();
            diceNums.Add(3);
            diceNums.Add(18);

            for (int i = 0; i < 3; i++)
            {
                diceNums.Add(4);
                diceNums.Add(17);
            }

            for (int i = 0; i < 6; i++)
            {
                diceNums.Add(5);
                diceNums.Add(16);
            }
            for (int i = 0; i < 10; i++)
            {
                diceNums.Add(6);
                diceNums.Add(15);
            }
            for (int i = 0; i < 15; i++)
            {
                diceNums.Add(7);
                diceNums.Add(14);
            }
            for (int i = 0; i < 21; i++)
            {
                diceNums.Add(8);
                diceNums.Add(13);
            }
            for (int i = 0; i < 25; i++)
            {
                diceNums.Add(9);
                diceNums.Add(12);
            }
            for (int i = 0; i < 27; i++)
            {
                diceNums.Add(10);
                diceNums.Add(11);
            }

            Random randomTool = new Random();
            _diceNumber = diceNums[randomTool.Next(1, 216) - 1];

            return _diceNumber;
        }

        #endregion

        
    }
}
