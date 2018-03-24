namespace Pixonic.TestTask.Moba.Contracts
{
    public class Vector2
    {
        #region Public Constructors

        //предположим, что вектора движения приходят уже нормализованные
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        #endregion Public Constructors

        #region Public Properties

        public float X { get; }

        public float Y { get; }

        #endregion Public Properties
    }
}