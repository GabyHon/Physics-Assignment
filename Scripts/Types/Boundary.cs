struct Boundary
// Keeping track of boundary points
// creating a struct which will, group floating point number of the boarders
{
    public float Top, Bottom, Left, Right;

    // creating a constructor
    public Boundary(float top, float bottom, float left, float right)
    {
        Top = top; Bottom = bottom; Left = left; Right = right;
    }
}
