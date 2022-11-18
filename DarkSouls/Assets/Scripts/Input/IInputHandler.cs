namespace DarkSouls
{
    public interface IInputHandler
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public float MoveAmount { get; }
        public float MouseX { get; }
        public float MouseY { get; }
    }
}