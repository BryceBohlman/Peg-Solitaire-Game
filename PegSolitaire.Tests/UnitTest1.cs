namespace PegSolitaire.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

       /* [Test]
        public void Initialize_EnglishBoard_HasCorrectCenterEmpty()
        {
            PegBoard board = new PegBoard(7);
            board.Initialize("English");

            Assert.AreEqual(SlotState.Empty, board.Board[3, 3]);
        }*/
    }
}
