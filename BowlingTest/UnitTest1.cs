using System.Xml.Serialization;
using Labb_TDD_Bowling;
using Xunit;

namespace BowlingTest
{
    public class UnitTest1
    {


        [Fact]
        public void Test_Of_An_All_Zeroed_Game_Score_Should_Return_0()
        {
            Game game = new Game();
            for(int i = 0; i < 20; i++)
                game.Roll(0);

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Score_Should_Return_60_After_20_Rolls_With_Input_3()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
                game.Roll(3);

            Assert.Equal(60, game.Score());
        }

        [Fact]
        public void Test_Of_One_Strike_Plus_Two_Extra_Rolls_Input_5_And_1_Score_Should_Equal_22()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(5);
            game.Roll(1);

            Assert.Equal(22,game.Score());
        }

        [Fact]
        public void Test_Of_On_Strike_In_The_Middle_Of_The_Series_Score_Should_Equal_36()
        {
            Game game = new Game();
            game.Roll(3);
            game.Roll(5);
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);

            Assert.Equal(36, game.Score());
        }

        [Fact]
        public void Test_Of_One_Spare_Should_Return_27_With_Iputs_3_7_8_1()
        {
            Game game = new Game();
            game.Roll(3);
            game.Roll(7);
            game.Roll(8);
            game.Roll(1);

            Assert.Equal(27, game.Score());
        }

        [Fact]
        public void Test_Of_3_Strikes_In_A_Row_Should_Return_50()
        {
            Game game = new Game();

            for (int i = 0; i < 3; i++)
            {
                game.Roll(10);
            }
            
            Assert.Equal(60, game.Score());
        }


        [Fact]
        public void Test_Of_6_Strikes_In_A_Row_Should_Return_110()
        {
            Game game = new Game();

            for (int i = 0; i < 6; i++)
            {
                game.Roll(10);
            }

            Assert.Equal(150, game.Score());
        }

        [Fact]
        public void Test_Of_Perfect_Game_Score_Should_Return_300()
        {
            Game game = new Game();

            for (int i = 0; i < 22; i++)
            {
                game.Roll(10);
            }

            Assert.Equal(300, game.Score());
        }
    }
}