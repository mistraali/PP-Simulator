namespace Simulator;

public class Birds : Animals
{
    //properties
    public bool CanFly { get; set; } = true;

    public override char Symbol => (CanFly) ? 'B' : 'b';

    public override string Info => $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>";

    public override void Go(Direction direction)
    {
        if (Position != null && Map != null)
        {
            if (CanFly)
            {
                base.Go(direction);
                base.Go(direction);
            }
            else
            {
                Point nextPosition = Map.NextDiagonal((Point)Position, direction);
                Map.Move((Point)Position, nextPosition, this);
                Position = nextPosition;
            }
        }
        
    }
}
