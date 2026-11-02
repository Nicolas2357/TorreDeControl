namespace TorreDeControl;

/// <summary>Tipo de vuelo. El valor numérico es su prioridad (0 = la más alta).</summary>
public enum TipoVuelo
{
    Emergencia = 0,
    Medico = 1,
    Comercial = 2,
    Carga = 3
}

public enum TipoOperacion
{
    Aterrizaje,
    Despegue
}

/// <summary>Vuelo que solicita la pista. Guarda cuándo llegó y cuándo fue atendido.</summary>
public class Vuelo
{
    public const int MinutosAterrizaje = 3;
    public const int MinutosDespegue = 2;

    public Vuelo(string codigo, TipoVuelo tipo, TipoOperacion operacion, int minutoLlegada)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código del vuelo es obligatorio.");

        Codigo = codigo;
        Tipo = tipo;
        Operacion = operacion;
        MinutoLlegada = minutoLlegada;
    }

    public string Codigo { get; }
    public TipoVuelo Tipo { get; }
    public TipoOperacion Operacion { get; }
    public int MinutoLlegada { get; }
    public int? MinutoAtencion { get; set; }

    /// <summary>Minutos que ocupa la pista.</summary>
    public int Duracion => Operacion == TipoOperacion.Aterrizaje ? MinutosAterrizaje : MinutosDespegue;

    /// <summary>Minutos que esperó desde que llegó hasta que se le asignó la pista.</summary>
    public int Espera => MinutoAtencion is int atencion ? atencion - MinutoLlegada : 0;

    public static string Nombre(TipoVuelo tipo) => tipo switch
    {
        TipoVuelo.Emergencia => "Emergencia",
        TipoVuelo.Medico => "Médico",
        TipoVuelo.Comercial => "Comercial",
        _ => "Carga"
    };

    public string NombreOperacion => Operacion == TipoOperacion.Aterrizaje ? "aterrizaje" : "despegue";

    public override string ToString() => $"{Codigo} ({Nombre(Tipo)}, {NombreOperacion})";
}