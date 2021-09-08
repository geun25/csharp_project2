using System;

namespace Tetris
{
    class Board
    {
        internal static Board GameBoard
        {
            get;
            private set;
        }

        static Board()
        {
            GameBoard = new Board();
        }
        Board()
        {
        }
        
        int[,] board = new int[GameRule.BX, GameRule.BY];
        internal int this[int x, int y] // 보드의 특정 영역이 어떤 값인지 확인
        {
            get
            {
                return board[x, y];
            }
        }

        internal bool MoveEnable(int bn, int tn, int x, int y)
        {
            for(int xx=0; xx<4; xx++)
            {
                for(int yy=0; y<4; yy++)
                {
                    if(BlockValue.bvals[bn,tn,xx,yy] != 0)
                    {
                        if(board[x+xx, y+yy] != 0)
                            return false;
                    }
                }
            }
            return true;
        }

        internal void Store(int bn, int turn, int x, int y)
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; y < 4; yy++)
                {
                    if(((x+xx) >= 0) && (x+xx<GameRule.BX) && (y+yy >= 0) && (y+yy < GameRule.BY))
                        board[x + xx, y + yy] += BlockValue.bvals[bn, turn, xx, yy];
                }
            }
            CheckLines(y + 3); // 꽉 차게 되면 밑에서부터 지워나가야 함.
        }

        private void CheckLines(int y)
        {
            int yy = 0;
            for(yy = 0; yy < 4; yy++)
            {
                if(y-yy<GameRule.BY)
                {
                    if(CheckLine(y - yy))
                    {
                        ClearLine(y - yy);
                        y++; // 해당 라인 그대로 다시 체크
                    }
                }
            }
        }

        private void ClearLine(int y)
        {
            for(; y > 0; y--) // 밑에서부터 위로 삭제
            {
                for(int xx = 0; xx < GameRule.BX; xx++)
                {
                    board[xx, y] = board[xx, y - 1]; // 위의 줄을 밑의 줄에 복사
                }
            }
        }

        private bool CheckLine(int y) // 해당라인이 꽉 차있는지 체크
        {
            for(int xx = 0; xx < GameRule.BX; xx++)
            {
                if (board[xx, y] == 0) // 비어있는 공간이 하나라도 존재할 경우
                    return false;
            }
            return true;
        }

        internal void ClearBoard()
        {
            for(int xx = 0; xx < GameRule.BX; xx++)
            {
                for(int yy = 0; yy < GameRule.BY; yy++)
                {
                    board[xx, yy] = 0;
                }
            }
        }
    }
}
