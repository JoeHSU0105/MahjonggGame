using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mahjongg;

namespace UnitTestProject1
{
    [TestClass]
    public class TableTest
    {
        MahjonggTable _table = new MahjonggTable();

        [TestInitialize]
        public void Init()
        {
            _table = new MahjonggTable();
        }


        [TestMethod]
        public void TotalTile()
        {
            const int TileCount = 144;

            Assert.AreEqual(_table.TileCount, TileCount, 0, string.Format("The Title count is not equal {0} ! .... now: {1}", TileCount, _table.TileCount));
        }

        [TestMethod]
        public void ShuffleTest()
        {
            MahjonggTable newTable = new MahjonggTable();
            newTable.Shuffle();

            bool isShuffle = false;
            for(int i=0; i<newTable.TileCount; i++)
            {
                if (_table.tiles.item[i].Equels(newTable.tiles.item[i]) == false)
               {
                   isShuffle = true;
               }   
            }

            Assert.IsTrue(isShuffle, "Shuffle is fail ... isShuffle!");




            MahjonggTable checkTable2nd = new MahjonggTable();
            checkTable2nd.Shuffle();

            bool isShuffle2nd = false;
            for (int i = 0; i < newTable.TileCount; i++)
            {
                if (checkTable2nd.tiles.item[i].Equels(newTable.tiles.item[i]) == false)
                {
                    isShuffle2nd = true;
                }
            }
            Assert.IsTrue(isShuffle2nd, "Shuffle is fail ... isShuffle2nd!");

        }


    }
}
