using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Search.Algorithm;
using Search.EightPuzzle;
using Search.Framework;
using Search.Hyperlinks;
using Search.Missionaries;
using Search.PathFinding;
using Search.Romania;
using Search.Sudoku;
using Search.Types;

using Direction = Search.Missionaries.Direction;
using Environment = Search.PathFinding.PathFindingEnvironment;

namespace Search
{
    class Program
    {
        private const int NUMBER = 3;

        static void Main(string[] args)
        {
            SolvePathFindingProblem();
        }

        private static void SolvePathFindingProblem()
        {
            var initialState = new PathFindingState(new Point(1, 1));
            var goalState = new PathFindingState(new Point(5, 5));

            var environment = new PathFindingEnvironment();
            environment.PointLines.Add(new PointLine(new Point(1, 3), new Point(3, 1)));
            environment.PointLines.Add(new PointLine(new Point(3, 1), new Point(5, 3)));
            environment.PointLines.Add(new PointLine(new Point(5, 3), new Point(3, 5)));
            environment.PointLines.Add(new PointLine(new Point(3, 5), new Point(1, 3)));
            environment.PointLines.Add(new PointLine(new Point(3, 1), new Point(3, 5)));
            environment.PointLines.Add(new PointLine(new Point(1, 3), new Point(5, 3)));

            var actionFunction = new PathFindingActionFunction(environment, goalState);
            var resultFunction = new PathFindingResultFunction();
            var goalTest = new PathFindingGoalTest(goalState);
            var stepCost = new PathFindingStepCost();
            var searchAlgorithm = new GraphSearch<PathFindingState, PathFindingAction>();

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, initialState, searchAlgorithm);
        }

        private static void SolveSudokuProblem()
        {
            var initialState =
                new SudokuState(
                    new int[9, 9]
                        {
                            { 0, 0, 5, 0, 3, 0, 0, 6, 2 }, 
                            { 0, 3, 0, 8, 9, 0, 0, 0, 1 }, 
                            { 0, 2, 9, 4, 0, 0, 0, 0, 0 },
                            { 0, 0, 0, 2, 6, 0, 0, 0, 0 }, 
                            { 8, 9, 3, 0, 0, 0, 0, 0, 0 }, 
                            { 6, 0, 0, 0, 0, 0, 8, 5, 0 },
                            { 3, 6, 8, 9, 0, 0, 0, 0, 0 }, 
                            { 0, 0, 4, 0, 0, 0, 0, 9, 6 }, 
                            { 0, 0, 0, 0, 4, 3, 0, 0, 0 }
                        });

            var actionFunction = new SudokuActionFunction();
            var resultFunction = new SudokuResultFunction();
            var goalTest = new SudokuGoalTest();
            var stepCost = new SudokuStepCost();
            var searchAlgorithm = new GraphSearch<SudokuState, SudokuAction>();

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, initialState, searchAlgorithm);
        }

        private static void SolveEightPuzzleProblem()
        {
            var initialState = EightPuzzleState.CreateRandomState();
            var goalState = new EightPuzzleState(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            var actionFunction = new EightPuzzleActionFunction();
            var resultFunction = new EightPuzzleResultFunction();
            var goalTest = new EightPuzzleGoalTest(goalState);
            var stepCost = new EightPuzzleStepCost();
            var heuristic = new EightPuzzleHeuristicFunction(goalState);
            var searchAlgorithm = new AStarGraphSearch<EightPuzzleState, EightPuzzleAction>(heuristic);

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, initialState, searchAlgorithm);
        }

        private static void SolveWeblinkProblem()
        {
            var initialState = new WeblinkState(new Uri("http://www.heise.de"));
            var goalState = new WeblinkState(new Uri("http://www.facebook.com"));
            var actionFunction = new WeblinkActionFunction();
            var resultFunction = new WeblinkResultFunction();
            var goalTest = new WeblinkGoalTest(goalState);
            var stepCost = new WeblinkStepCost();
            var searchAlgorithm = new GraphSearch<WeblinkState, WeblinkAction>();

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, initialState, searchAlgorithm);
        }

        private static void SolveMissionariesProblem()
        {
            var goalState = new MissionariesState(0, 0, 0, 0, NUMBER, NUMBER, Direction.Right);
            var actionFunction = new MissionariesActionFunction(goalState);
            var resultFunction = new MissionariesResultFunction();
            var goalTest = new MissionariesGoalTest(goalState);
            var stepCost = new MissionariesStepCost();
            var initialState = new MissionariesState(NUMBER, NUMBER, 0, 0, 0, 0, Direction.Left);
            var searchAlgorithm = new GraphSearch<MissionariesState, MissionariesAction>();

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, initialState, searchAlgorithm);
        }

        private static void SolveRomaniaProblem()
        {
            var actionFunction = new TravelActionFunction();
            var resultFunction = new TravelResultFunction();
            var goalTest = new TravelGoalTest(TravelState.Lugoj);
            var stepCost = new TravelStepCost();
            var intialState = TravelState.Arad;
            var searchAlgorithm = new GraphSearch<TravelState, TravelAction>();

            SolveProblem(actionFunction, resultFunction, goalTest, stepCost, intialState, searchAlgorithm);
        }

        private static void SolveProblem<TState, TAction>(
            ActionFunction<TState, TAction> actionFunction,
            ResultFunction<TState, TAction> resultFunction,
            GoalTest<TState> goalTest,
            StepCost<TState, TAction> stepCost,
            TState initialState,
            IGraphSearch<TState, TAction> searchAlgorithm)
        {
            var problem = new Problem<TState, TAction>(
                initialState, actionFunction, resultFunction, goalTest, stepCost);

            var solution = searchAlgorithm.Search(problem);

            Console.WriteLine("Solution:");
            Console.WriteLine("=========");
            foreach (var node in solution)
            {
                Console.WriteLine(node.State);
            }

            Console.ReadKey();
        }
    }
}
