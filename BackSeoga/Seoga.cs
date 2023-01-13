using System.Runtime.ConstrainedExecution;

namespace BackSeoga
{
    //Modelo de datos del JSON
    public class Seoga
    {
        public predConcello? predConcello { get; set; }

    }
    public class predConcello
    {
        public int idConcello { get; set; }

        public List<listaPredDiaConcello> listaPredDiaConcello { get; set; }
        public string? nome { get; set; }
    }

    public class listaPredDiaConcello
    {
        public DateTime dataPredicion { get; set; }
        public int tMax { get; set; }
        public int tMin { get; set; }

        public ceo ceo { get; set; }
        public pchoiva pchoiva { get; set; }
    }

    public class pchoiva
    {
        public int manha { get; set; }
        public int noite { get; set; }
        public int tarde { get; set; }
    }

    public class ceo
    {
        public int manha { get; set; }
        public int noite { get; set; }
        public int tarde { get; set; }

    }
}