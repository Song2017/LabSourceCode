using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class NQueue
    {
        public int solveNQueues(int size)
        {
            var board = new string[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = ".";

            var ret = new List<List<string>>();
            dfs(board, 0, ret, size);
            return ret.Count();
        }

        private bool canPlace(string[,] board, int row, int col, int size)
        {
            for (int i = 1; i < row + 1; i++)
            {
                if (board[row - i, col].Equals("Q"))
                    return false;
                if (col - i >= 0 && board[row - i, col - i].Equals("Q"))
                    return false;
                if (col + i < size && board[row - i, col + i].Equals("Q"))
                    return false;
            }

            return true;
        }

        private void dfs(string[,] board, int row, List<List<string>> ret, int size)
        {
            if (row == size)
            {
                List<string> ans = new List<string>();
                var sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sb.Append(board[i, j]);
                    }
                    ans.Add(sb.ToString());
                    sb.Clear();
                }
                
                ret.Add(ans);
            }

            for (int i = 0; i < size; i++)
            {
                if (!canPlace(board, row, i, size))
                    continue;
                board[row, i] = "Q";
                dfs(board, row + 1, ret, size);
                board[row, i] = ".";
            }

        }

    }
}
