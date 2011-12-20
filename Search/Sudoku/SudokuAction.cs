using Search.Types;

namespace Search.Sudoku
{
    public class SudokuAction
    {
        public Point Location { get; set; }

        public int Number { get; set; }

        public SudokuAction(Point location, int number)
        {
            Location = location;
            Number = number;
        }
    }
}
