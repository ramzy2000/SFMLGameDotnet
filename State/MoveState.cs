public enum MoveStateEnum
{
    none = 0,
    moveForward,
    moveBack,
    moveRight,
    moveLeft,
}

public class MoveState
{
    public bool isMoveingForward = false;
    public bool isMovingBackward = false;
    public bool isMoveingRight = false;

    public bool isMoveingLeft = false;
}