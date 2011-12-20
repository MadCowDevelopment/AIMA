using System;
using System.Collections.Generic;
using System.Text;

using Search.Types;

namespace Search.EightPuzzle
{
    public class EightPuzzleState
    {
        private static Random _random = new Random((int)DateTime.Now.Ticks);

        public int[,] Fields { get; private set; }

        public EightPuzzleState(int[,] fields)
        {
            Fields = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Fields[i, j] = fields[i, j];
                }
            }
        }

        public static EightPuzzleState CreateRandomState()
        {
            var result = new int[3, 3];

            var randomizedNumbers = new Queue<int>(9);
            for (int i = 0; i <= 8; i++)
            {
                int rnd;
                do
                {
                    rnd = _random.Next(0, 9);
                }
                while (randomizedNumbers.Contains(rnd));

                randomizedNumbers.Enqueue(rnd);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = randomizedNumbers.Dequeue();
                }
            }

            return new EightPuzzleState(result);
        }

        public Point FindLocationOfNumber(int x)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Fields[i, j] == x)
                    {
                        return new Point(i, j);
                    }
                }
            }

            return null;
        }

        public Point FindLocationOfEmptyField()
        {
            return FindLocationOfNumber(0);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    builder.Append(Fields[i, j]);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        public bool Equals(EightPuzzleState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (other.Fields[i, j] != Fields[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(EightPuzzleState))
            {
                return false;
            }

            return Equals((EightPuzzleState)obj);
        }

        public override int GetHashCode()
        {
            return (Fields != null ? Fields.GetHashCode() : 0);
        }
    }
}
