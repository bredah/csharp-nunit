namespace CSharp.Unit
{
    public class Calculator
    {
        public enum Operations
        {
            Add,
            Sub,
            Mult,
            Div,
        }

        public int valueA { get; set; }
        public int valueB { get; set; }

        public int getResult(Operations calc)
        {
            int result = 0;
            switch (calc)
            {
                case Operations.Add:
                    result = valueA + valueB;
                    break;
                case Operations.Sub:
                    result = valueA - valueB;
                    break;
                case Operations.Mult:
                    result = valueA * valueB;
                    break;
                case Operations.Div:
                    result = valueA / valueB;
                    break;
            }
            return result;
        }
    }
}
