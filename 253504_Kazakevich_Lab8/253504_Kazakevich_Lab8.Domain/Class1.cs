namespace _253504_Kazakevich_Lab8.Domain
{
    public class Automobile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double EngineDisplacement { get; set; }

        public Automobile(int id, string name, double displacement) =>
            (Id, Name, EngineDisplacement) = (id, name, displacement);
        public Automobile() =>
            (Id, Name, EngineDisplacement) = (-1, "undefiend", 0);

        public override string ToString() =>
            $"{Id},{Name},{EngineDisplacement};";
    }
}