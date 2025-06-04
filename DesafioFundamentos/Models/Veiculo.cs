namespace DesafioFundamentos.Models;

/// <summary>
/// Representa um veículo.
/// </summary>
public record struct Veiculo
{
    public string Placa { get; }
    public DateTime DataEntrada { get; }
            
    public Veiculo(string placa, DateTime dataEntrada) { Placa = placa; DataEntrada = dataEntrada;}
}