namespace TravianTest.Snake.Logic
{
    public interface IFieldLogic
    {
        int[,] Field();
        int FieldHeight();
        int FieldWidth();
    }

    public class FieldLogic : IFieldLogic
    {
        private const int FieldWidthConst = 10;
        private const int FieldHeightConst = 10;
        private readonly int[,] _field = new int[FieldWidthConst, FieldHeightConst];

        public int[,] Field() => _field;
        public int FieldHeight() => FieldHeightConst;
        public int FieldWidth() => FieldWidthConst;
    }
}