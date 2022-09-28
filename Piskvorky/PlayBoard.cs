using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky
{
    public partial class PlayBoard : UserControl
    {
        private int boardSize = 19;
        private int fieldSize = 20;
        private Color colorGrid = Color.Gray;
        private Color colorX = Color.Red;
        private Color colorO = Color.Blue;
        private GamePiece[,] piecesOnBoard;
        private GamePiece currentPlayer = GamePiece.X;
        private GamePiece Opponent 
        {
            get
            {
                if (currentPlayer == GamePiece.X) return GamePiece.O;
                if (currentPlayer == GamePiece.O) return GamePiece.X;
                throw new Exception("Prazdne pole neni hrac");
            }
        }
        public GamePiece[,] PiecesOnBoard
        {
            get
            {
                if (piecesOnBoard == null)
                   ClearBoard();
                return piecesOnBoard;   
            }
        }

        private void ClearBoard()
        {
            piecesOnBoard = new GamePiece[BoardSize, BoardSize];
            for (int x = 0; x < BoardSize; x++)
                for (int y = 0; y < BoardSize; y++)
                    PiecesOnBoard[x, y] = GamePiece.Free;
        }

        public PlayBoard()
        {
            InitializeComponent();
        }

        public int BoardSize
        {
            get => boardSize; set
            {
                boardSize = value;
                Refresh();

            }
        }
        public int FieldSize
        {
            get => fieldSize; set
            {
                fieldSize = value;
                Refresh();

            }
        }
        public Color ColorGrid
        {
            get => colorGrid; set
            {
                penGrid = null;
                colorGrid = value;
                Refresh();
            }
        }
        #region Pens
        private Pen penGrid;
        public Pen PenGrid
        {
            get
            {
                if (penGrid == null)
                    penGrid = new Pen(ColorGrid);
                return penGrid;
            }
        }
        private Pen penX;
        public Pen PenX
        {
            get
            {
                if (penX == null)
                    penX = new Pen(colorX);
                return penX;
            }
        }
        private Pen penO;
        public Pen PenO
        {
            get
            {
                if (penO == null)
                    penO = new Pen(colorO);
                return penO;
            }
        }

        #endregion

        private void PlayBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
        }
        private void DrawBoard(Graphics g)
        {
            for (int i = 0; i <= boardSize; i++)
            {
                g.DrawLine(PenGrid, 0, i * FieldSize, BoardSize * FieldSize, i * FieldSize);
                g.DrawLine(PenGrid, i * FieldSize, 0, i * FieldSize, BoardSize * FieldSize);
            }
        }
        private void DrawPieces(Graphics g)
        {
            for (int x = 0; x < BoardSize; x++)
                for (int y = 0; y < BoardSize; y++)
                    DrawPiece(g, PiecesOnBoard[x, y], x, y);
        }
        private void DrawPiece(Graphics g, GamePiece piece, int x, int y)
        {
            if (!(x < boardSize && x >= 0 && y < boardSize && y >= 0))
            {
                throw new Exception("souradnice jsou mimo hraci plochu");
            }
            if (piece == GamePiece.X)
            {
                g.DrawLine(PenX,
                    x * fieldSize + 1,
                    y * fieldSize + 1,
                    x * fieldSize + fieldSize-1,
                    y * fieldSize + fieldSize-1);
                g.DrawLine(PenX,
                   x * fieldSize + 1,
                   y * fieldSize + fieldSize - 1,
                   x * fieldSize + fieldSize - 1,
                   y * fieldSize + 1);
            }
            if (piece == GamePiece.O)
            {
                g.DrawEllipse(PenO,
                    x * fieldSize + 1,
                    y * fieldSize + 1,
                    fieldSize - 2,
                    fieldSize - 2);
               
            }
        }

        private void PlayBoard_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / fieldSize;
            int y = e.Y / fieldSize;
            if (!(x < boardSize && x >= 0 && y < boardSize && y >= 0))
                return;
            if (PiecesOnBoard[x, y] != GamePiece.Free)
                return;
            PiecesOnBoard[x, y] = currentPlayer;
            currentPlayer = Opponent;
            Refresh();
        }
    }
}
