Console.WriteLine("Jogador UM, escolha uma ferramenta!");
var nomeFerramentaUM = Console.ReadLine();

Console.WriteLine("Jogador DOIS, escolha uma ferramenta!");
var nomeFerramentaDOIS = Console.ReadLine();

var ferrametaUm = FactoryFerramenta.ObtemFerramenta(nomeFerramentaUM);
var ferrametaDois = FactoryFerramenta.ObtemFerramenta(nomeFerramentaDOIS);

if (ferrametaUm.Forcas.Any(f => ferrametaDois.Fraquesas.ContainsKey(f.Key)) )
    Console.WriteLine("Jogador UM ganhou!");

if (ferrametaDois.Forcas.Any(f => ferrametaUm.Fraquesas.ContainsKey(f.Key)))
    Console.WriteLine("Jogador DOIS ganhou!");


public abstract class Ferramenta
{
    public Dictionary<string, string> Forcas { get; set; } = new Dictionary<string, string>();
    public Dictionary<string, string> Fraquesas { get; set; } = new Dictionary<string, string>();
    public string Nome { get; set; } = null!;
}

public class Lagarto : Ferramenta
{
    public Lagarto()
    {
        Nome = this.GetType().Name;
        Forcas.Add("come", "O lagarto come");
        Forcas.Add("envenena", "O lagarto envenena");

        Fraquesas.Add("mata", "o largata morre por morte matada");
        Fraquesas.Add("esmaga", "o largata pode ser esmagado");
    }
}

public class Spock : Ferramenta
{
    public Spock()
    {
        Nome = this.GetType().Name;
        Forcas.Add("quebra", "O spock quebra");
        Forcas.Add("vaporiza", "o spock vaporiza");

        Fraquesas.Add("refuta", "O spock pode ser refutado");
        Fraquesas.Add("envenena", "O spock pode ser envenenado");
    }
}

public class Pedra : Ferramenta
{
    public Pedra() {
        Nome = this.GetType().Name;
        Forcas.Add("esmaga", "A pedra esmaga");
        Forcas.Add("quebra", "A pedra quebra");

        Fraquesas.Add("vaporizada", "vaporiza a pedra");
        Fraquesas.Add("cobre", "cobre a pedra");
    }
}

public class Papel : Ferramenta
{
    public Papel()
    {
        Nome = this.GetType().Name;
        Forcas.Add("cobre", "O papel cobre");
        Forcas.Add("refuta", "O papel refuta");

        Fraquesas.Add("come", "o papel pode ser comido");
        Fraquesas.Add("corta", "o papel pode ser cortado");
    }
}

public class Tesoura : Ferramenta
{
    public Tesoura() {
        Nome = this.GetType().Name;
        Forcas.Add("mata", "A tesoura mata");
        Forcas.Add("corta", "A tesoura corta");

        Fraquesas.Add("quebra", "quebra a tesoura");        
    }
}

public class FactoryFerramenta
{
    public static Ferramenta ObtemFerramenta(string nome)
    {
        return nome.ToLower() switch
        {
            "tesoura" => new Tesoura(),
            "papel" => new Papel(),
            "pedra" => new Pedra(),
            "spock" => new Spock(),
            "lagarto" => new Lagarto(),
            _ => throw new NotImplementedException($"Ferramenta não localizado: {nome}")
        };
    }
}





