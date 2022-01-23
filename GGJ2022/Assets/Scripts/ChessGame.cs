using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChessGame : MonoBehaviour
{
    [SerializeField] private ChessSpace blackSquarePrefab;
    [SerializeField] private ChessSpace whiteSquarePrefab;
    [SerializeField] private ChessPiece QueenPrefab;
    [SerializeField] private ChessPiece KingPrefab;
    [SerializeField] private ChessPiece RookPrefab;
    [SerializeField] private ChessPiece BishopPrefab;
    [SerializeField] private ChessPiece PawnPrefab;
    [SerializeField] private ChessPiece KnightPrefab;
    [SerializeField] private Transform centerTransform;
    [SerializeField] private float squareSize;
    [SerializeField] private int numSquares;
    [SerializeField] private PhysicsRaycaster Raycaster;

    private ChessStateMachine Machine { get; } = new ChessStateMachine();
    private ChessSpace[][] Squares;

    // Start is called before the first frame update
    void Start()
    {
        Machine.StateChanged += MachineOnStateChanged;
        Squares = new ChessSpace[numSquares][];
        for (int i = 0; i < numSquares; i++)
        {
            Squares[i] = new ChessSpace[numSquares];
        }

        float offset = -numSquares / 2f * squareSize + squareSize / 2;
        for (int i = 0; i < numSquares; i++)
        {
            for (int j = 0; j < numSquares; j++)
            {
                bool isBlack = (i + j) % 2 == 0;
                ChessSpace prefab = isBlack ? blackSquarePrefab : whiteSquarePrefab;
                ChessSpace newSquare = Instantiate(prefab, centerTransform);
                Transform squareTransform = newSquare.transform;
                squareTransform.localPosition = new Vector3(squareSize * i + offset, 0, squareSize * j + offset);
                Squares[i][j] = newSquare;
                newSquare.X = i;
                newSquare.Y = j;
            }
        }

        

        CreatePiece(0,0 , ChessPieceType.King);
        CreatePiece(1,1 , ChessPieceType.Bishop);
        CreatePiece(1,2 , ChessPieceType.Knight);
        CreatePiece(2,3 , ChessPieceType.Knight);
        CreatePiece(0,1, ChessPieceType.Rook);
        CreatePiece(3, 2, ChessPieceType.Knight);
        CreatePiece(3,3 , ChessPieceType.Bishop);
        CreatePiece(1,0 , ChessPieceType.Knight);
        CreatePiece(0,2 , ChessPieceType.Knight);
        CreatePiece(0,3 , ChessPieceType.Knight);
        CreatePiece(3,0 , ChessPieceType.Pawn);
        CreatePiece(3,1 , ChessPieceType.Pawn);
    }

    private void CreatePiece(int x, int y, ChessPieceType type)
    {
        ChessPiece Prefab;
        switch (type)
        {
            case ChessPieceType.Pawn:
                Prefab = PawnPrefab;
                break;
            case ChessPieceType.Knight:
                Prefab = KnightPrefab;
                break;
            case ChessPieceType.Bishop:
                Prefab = BishopPrefab;
                break;
            case ChessPieceType.Rook:
                Prefab = RookPrefab;
                break;
            case ChessPieceType.Queen:
                Prefab = QueenPrefab;
                break;
            case ChessPieceType.King:
                Prefab = KingPrefab;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        

        ChessPiece bishop2 = Instantiate(Prefab, this.transform, true);
        bishop2.MoveToSpace(Squares[x][y]);
    }

    private void MachineOnStateChanged(object sender, StateChangedEventArgs args)
    {
        if (args.newState is ChessObjectSelectedState)
        {
            Raycaster.eventMask = ~(1 <<LayerMask.NameToLayer("ChessPiece"));
        }
        else
        {
            Raycaster.eventMask = ~0;
        }
    }

    public void Clicked(IInteractable interactable)
    {
        Machine.Clicked(interactable);
    }

    public void Hover(IInteractable chessPiece)
    {
        Machine.Hover(chessPiece);
    }

    public void UnHover(IInteractable chessPiece)
    {
        Machine.UnHover(chessPiece);
    }

    public void PieceSelected(IInteractable chessPiece)
    {
        //highlight squares.
    }

    public bool TryMoveToSpace(ChessSpace chessSpace, ChessPiece piece)
    {
        if (piece == null)
        {
            return false;
        }

        if (!piece.CanMoveToSpace(chessSpace))
        { //if the space being clicked is invalid do nothing.
            return false;
        }

        piece.MoveToSpace(chessSpace);
        return true;
    }
}