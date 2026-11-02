namespace TorreDeControl;

/// <summary>Acumula las esperas de un tipo de vuelo.</summary>
public class EstadisticaTipo
{
    public int Atendidos { get; private set; }
    public long EsperaTotal { get; private set; }
    public int EsperaMaxima { get; private set; }
    public double EsperaPromedio => Atendidos == 0 ? 0 : (double)EsperaTotal / Atendidos;

    public void Registrar(int espera)
    {
        Atendidos++;
        EsperaTotal += espera;
        if (espera > EsperaMaxima)
            EsperaMaxima = espera;
    }
}

/// <summary>
/// Simula una torre de control con una pista. Cada minuto puede llegar un vuelo
/// (con la probabilidad indicada); los vuelos esperan en una cola de prioridad y la pista
/// se asigna al vuelo del frente cuando queda libre.
/// </summary>
public class Simulador
{
    private static readonly string[] Aerolineas = { "AM", "VB", "Y4", "UA", "AA", "IB", "DL", "CM" };

    private readonly Random _random;
    private readonly ColaPrioridad<Vuelo> _cola = new();
    private readonly EstadisticaTipo[] _estadisticas = { new(), new(), new(), new() };
    private double _probabilidad;
    private int _minutosRestantes;

    /// <param name="semilla">Semilla del generador aleatorio (la misma semilla produce los mismos vuelos).</param>
    /// <param name="probabilidadLlegada">Probabilidad de que llegue un vuelo en cada minuto (0 a 1).</param>
    /// <param name="usarPrioridad">true = cola de prioridad; false = cola FIFO simple.</param>
    public Simulador(int semilla, double probabilidadLlegada, bool usarPrioridad)
    {
        _random = new Random(semilla);
        ProbabilidadLlegada = probabilidadLlegada;
        UsarPrioridad = usarPrioridad;
    }

    public double ProbabilidadLlegada
    {
        get => _probabilidad;
        set
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("La probabilidad de llegada debe estar entre 0 y 1.");
            _probabilidad = value;
        }
    }

    public bool UsarPrioridad { get; }
    public int Minuto { get; private set; }
    public Vuelo? VueloEnPista { get; private set; }
    public int MinutosRestantes => _minutosRestantes;
    public int EnEspera => _cola.Cantidad;
    public int ColaMaxima { get; private set; }
    public int TotalAtendidos { get; private set; }

    public EstadisticaTipo Estadistica(TipoVuelo tipo) => _estadisticas[(int)tipo];

    public double EsperaPromedioGeneral
    {
        get
        {
            long total = 0;
            int atendidos = 0;
            foreach (var e in _estadisticas)
            {
                total += e.EsperaTotal;
                atendidos += e.Atendidos;
            }
            return atendidos == 0 ? 0 : (double)total / atendidos;
        }
    }

    public IEnumerable<(Vuelo Vuelo, int Prioridad)> VuelosEnEspera() => _cola.Recorrer();

    /// <summary>Crea un vuelo que llega en el minuto actual (para agregarlo manualmente).</summary>
    public Vuelo CrearVuelo(TipoVuelo tipo, TipoOperacion operacion) => new(GenerarCodigo(), tipo, operacion, Minuto);

    /// <summary>Formula la solicitud de pista: en modo FIFO todos tienen la misma prioridad.</summary>
    public void AgregarVuelo(Vuelo vuelo)
    {
        ArgumentNullException.ThrowIfNull(vuelo);
        _cola.Encolar(vuelo, UsarPrioridad ? (int)vuelo.Tipo : 0);
        ColaMaxima = Math.Max(ColaMaxima, _cola.Cantidad);
    }

    /// <summary>Avanza el reloj un minuto: llegadas, liberación de la pista y asignación. Devuelve los eventos.</summary>
    public List<string> AvanzarMinuto()
    {
        var eventos = new List<string>();
        Minuto++;

        // 1. Llegada aleatoria de un vuelo
        if (_random.NextDouble() < _probabilidad)
        {
            Vuelo nuevo = GenerarVuelo();
            AgregarVuelo(nuevo);
            eventos.Add($"[{Minuto:000}] Solicita pista {nuevo} → en espera: {_cola.Cantidad}");
        }

        // 2. El vuelo en pista termina su operación
        if (VueloEnPista is not null && --_minutosRestantes == 0)
        {
            eventos.Add($"[{Minuto:000}] {VueloEnPista.Codigo} terminó su {VueloEnPista.NombreOperacion}; pista libre");
            VueloEnPista = null;
        }

        // 3. Si la pista está libre, se asigna al vuelo del frente de la cola
        if (VueloEnPista is null && !_cola.EstaVacia)
        {
            Vuelo siguiente = _cola.Desencolar();
            siguiente.MinutoAtencion = Minuto;
            VueloEnPista = siguiente;
            _minutosRestantes = siguiente.Duracion;
            _estadisticas[(int)siguiente.Tipo].Registrar(siguiente.Espera);
            TotalAtendidos++;
            eventos.Add($"[{Minuto:000}] Pista asignada a {siguiente} (esperó {siguiente.Espera} min)");
        }
        return eventos;
    }

    public void Simular(int minutos)
    {
        for (int i = 0; i < minutos; i++)
            AvanzarMinuto();
    }

    /// <summary>
    /// Ejecuta dos simulaciones con la misma semilla (mismos vuelos y mismos minutos de llegada):
    /// una con cola FIFO y otra con cola de prioridad.
    /// </summary>
    public static (Simulador Fifo, Simulador Prioridad) Comparar(int semilla, double probabilidad, int minutos)
    {
        if (minutos < 1)
            throw new ArgumentException("Los minutos de simulación deben ser mayores que 0.");

        var fifo = new Simulador(semilla, probabilidad, usarPrioridad: false);
        var prioridad = new Simulador(semilla, probabilidad, usarPrioridad: true);
        fifo.Simular(minutos);
        prioridad.Simular(minutos);
        return (fifo, prioridad);
    }

    private Vuelo GenerarVuelo()
    {
        int r = _random.Next(100);              // 5 % emergencia, 10 % médico, 60 % comercial, 25 % carga
        TipoVuelo tipo = r < 5 ? TipoVuelo.Emergencia
                       : r < 15 ? TipoVuelo.Medico
                       : r < 75 ? TipoVuelo.Comercial
                       : TipoVuelo.Carga;
        TipoOperacion operacion = _random.Next(2) == 0 ? TipoOperacion.Aterrizaje : TipoOperacion.Despegue;
        return new Vuelo(GenerarCodigo(), tipo, operacion, Minuto);
    }

    private string GenerarCodigo() => $"{Aerolineas[_random.Next(Aerolineas.Length)]}-{_random.Next(100, 1000)}";
}