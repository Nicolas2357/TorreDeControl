using System.Drawing.Drawing2D;

namespace TorreDeControl;

/// <summary>
/// Interfaz de la torre de control: dibuja la pista y la cola de prioridad, controla la
/// simulación, muestra estadísticas, compara FIFO contra prioridad y ejecuta los casos de prueba.
/// </summary>
public partial class Form1 : Form
{
    private static readonly Color ColorAzul = Color.FromArgb(31, 58, 96);
    private static readonly Color[] ColoresTipo =
    {
        Color.FromArgb(200, 40, 40),    // Emergencia
        Color.FromArgb(140, 60, 180),   // Médico
        Color.FromArgb(0, 110, 200),    // Comercial
        Color.FromArgb(110, 110, 110)   // Carga
    };
    private const int MaxBitacora = 500;

    private readonly Font _fuenteGrande = new("Segoe UI", 14F, FontStyle.Bold);
    private readonly Font _fuenteNegrita = new("Segoe UI", 9F, FontStyle.Bold);
    private readonly Font _fuenteChica = new("Segoe UI", 8F);
    private readonly SolidBrush _pincel = new(Color.White);

    private Simulador _sim = new(1, 0.35, true);
    private (Simulador Fifo, Simulador Prioridad)? _comparacion;
    private int _aprobadas, _total;

    public Form1()
    {
        InitializeComponent();
        picTorre.Resize += (_, _) => picTorre.Invalidate();
        picComparacion.Resize += (_, _) => picComparacion.Invalidate();
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        foreach (TipoVuelo t in Enum.GetValues<TipoVuelo>())
        {
            cmbTipo.Items.Add(Vuelo.Nombre(t));
            dgvEstadisticas.Rows.Add(Vuelo.Nombre(t), (int)t, 0, "0.0", 0);
        }
        cmbOperacion.Items.AddRange(new object[] { "Aterrizaje (3 min)", "Despegue (2 min)" });
        cmbTipo.SelectedIndex = 0;
        cmbOperacion.SelectedIndex = 0;
        TrkVelocidad_Scroll(null, EventArgs.Empty);
        Reiniciar();
    }

    // ═══════════════════════ CONTROL DE LA SIMULACIÓN ═══════════════════════

    private void Reiniciar()
    {
        tmrSimulacion.Stop();
        btnIniciar.Text = "▶  Iniciar simulación";
        int semilla = Random.Shared.Next(1, 100_000);
        _sim = new Simulador(semilla, (double)nudProbabilidad.Value / 100, rbPrioridad.Checked);
        lstBitacora.Items.Clear();
        Registrar($"Simulación reiniciada ({(_sim.UsarPrioridad ? "cola de prioridad" : "cola FIFO simple")}, semilla {semilla})");
        ActualizarVista();
    }

    private void BtnReiniciar_Click(object? sender, EventArgs e) => Reiniciar();

    private void RbModo_CheckedChanged(object? sender, EventArgs e) => Reiniciar();

    private void BtnIniciar_Click(object? sender, EventArgs e)
    {
        if (tmrSimulacion.Enabled)
        {
            tmrSimulacion.Stop();
            btnIniciar.Text = "▶  Continuar simulación";
        }
        else
        {
            tmrSimulacion.Start();
            btnIniciar.Text = "⏸  Pausar simulación";
        }
    }

    private void BtnPaso_Click(object? sender, EventArgs e) => AvanzarMinuto();

    private void TmrSimulacion_Tick(object? sender, EventArgs e) => AvanzarMinuto();

    private void AvanzarMinuto()
    {
        foreach (string evento in _sim.AvanzarMinuto())
            Registrar(evento);
        ActualizarVista();
    }

    private void TrkVelocidad_Scroll(object? sender, EventArgs e) =>
        tmrSimulacion.Interval = 1100 - trkVelocidad.Value * 100;     // 1000 ms (lento) a 100 ms (rápido)

    private void NudProbabilidad_ValueChanged(object? sender, EventArgs e) =>
        _sim.ProbabilidadLlegada = (double)nudProbabilidad.Value / 100;

    private void BtnAgregar_Click(object? sender, EventArgs e)
    {
        var tipo = (TipoVuelo)cmbTipo.SelectedIndex;
        var operacion = (TipoOperacion)cmbOperacion.SelectedIndex;
        Vuelo vuelo = _sim.CrearVuelo(tipo, operacion);
        _sim.AgregarVuelo(vuelo);
        Registrar($"[{_sim.Minuto:000}] Solicitud manual: {vuelo} → en espera: {_sim.EnEspera}");
        ActualizarVista();
    }

    private void Registrar(string texto)
    {
        lstBitacora.Items.Insert(0, texto);
        if (lstBitacora.Items.Count > MaxBitacora)
            lstBitacora.Items.RemoveAt(lstBitacora.Items.Count - 1);
        lblEstado.Text = texto;
    }

    private void ActualizarVista()
    {
        lblMinuto.Text = _sim.Minuto.ToString();
        lblEnEspera.Text = _sim.EnEspera.ToString();
        lblAtendidos.Text = _sim.TotalAtendidos.ToString();
        lblColaMaxima.Text = $"{_sim.ColaMaxima} / {_sim.EsperaPromedioGeneral:0.0}";

        foreach (TipoVuelo t in Enum.GetValues<TipoVuelo>())
        {
            EstadisticaTipo est = _sim.Estadistica(t);
            DataGridViewRow fila = dgvEstadisticas.Rows[(int)t];
            fila.Cells[2].Value = est.Atendidos;
            fila.Cells[3].Value = est.EsperaPromedio.ToString("0.0");
            fila.Cells[4].Value = est.EsperaMaxima;
        }
        picTorre.Invalidate();
    }

    // ═══════════════════════ DIBUJO DE LA TORRE ═══════════════════════

    private void PicTorre_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        int ancho = picTorre.Width;

        TextRenderer.DrawText(g, _sim.UsarPrioridad ? "Modo: cola de prioridad" : "Modo: cola FIFO simple",
            _fuenteNegrita, new Point(14, 12), ColorAzul);
        TextRenderer.DrawText(g, $"Minuto {_sim.Minuto}", _fuenteGrande, new Rectangle(ancho - 210, 4, 196, 30),
            ColorAzul, TextFormatFlags.Right);

        // Pista
        var pista = new Rectangle(14, 38, ancho - 28, 64);
        _pincel.Color = Color.FromArgb(60, 64, 70);
        g.FillRectangle(_pincel, pista);
        using (var lineaCentral = new Pen(Color.White, 2F) { DashStyle = DashStyle.Dash })
            g.DrawLine(lineaCentral, pista.Left + 70, pista.Top + pista.Height / 2, pista.Right - 10, pista.Top + pista.Height / 2);
        TextRenderer.DrawText(g, "PISTA 1", _fuenteNegrita, new Point(pista.Left + 8, pista.Top + 6), Color.White);

        string estadoPista;
        if (_sim.VueloEnPista is Vuelo enPista)
        {
            double avance = (enPista.Duracion - _sim.MinutosRestantes) / (double)enPista.Duracion;
            const int anchoAvion = 140;
            int x = pista.Left + 80 + (int)((pista.Width - 100 - anchoAvion) * avance);
            var avion = new Rectangle(x, pista.Top + 14, anchoAvion, 36);
            _pincel.Color = ColoresTipo[(int)enPista.Tipo];
            g.FillRectangle(_pincel, avion);
            g.DrawRectangle(Pens.White, avion);
            TextRenderer.DrawText(g, $"✈ {enPista.Codigo}", _fuenteNegrita, avion, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            estadoPista = $"{enPista} en la pista: libera en {_sim.MinutosRestantes} min";
        }
        else
        {
            estadoPista = "Pista libre";
        }
        TextRenderer.DrawText(g, estadoPista, _fuenteNegrita, new Point(14, pista.Bottom + 4), Color.Black);

        // Cola de espera (del frente al final)
        int yCola = pista.Bottom + 44;
        TextRenderer.DrawText(g, $"Cola de espera (frente → final): {_sim.EnEspera} vuelo(s)", _fuenteNegrita,
            new Point(14, yCola - 20), ColorAzul);

        const int anchoT = 122, altoT = 56, sep = 8;
        int porFila = Math.Max(1, (ancho - 28 + sep) / (anchoT + sep));
        int maxTarjetas = porFila * 3, i = 0;

        foreach (var (vuelo, _) in _sim.VuelosEnEspera())
        {
            if (i == maxTarjetas)
                break;

            int x = 14 + i % porFila * (anchoT + sep);
            int y = yCola + i / porFila * (altoT + sep);
            var tarjeta = new Rectangle(x, y, anchoT, altoT);

            _pincel.Color = ColoresTipo[(int)vuelo.Tipo];
            g.FillRectangle(_pincel, tarjeta);
            TextRenderer.DrawText(g, $"{i + 1}. {vuelo.Codigo}", _fuenteNegrita, new Point(x + 5, y + 4), Color.White);
            TextRenderer.DrawText(g, $"{Vuelo.Nombre(vuelo.Tipo)} · {vuelo.NombreOperacion}", _fuenteChica, new Point(x + 5, y + 22), Color.White);
            TextRenderer.DrawText(g, $"esperando {_sim.Minuto - vuelo.MinutoLlegada} min", _fuenteChica, new Point(x + 5, y + 37), Color.White);
            i++;
        }

        if (_sim.EnEspera == 0)
            TextRenderer.DrawText(g, "No hay vuelos esperando.", _fuenteNegrita, new Point(14, yCola + 8), Color.Gray);
        else if (_sim.EnEspera > maxTarjetas)
            TextRenderer.DrawText(g, $"+ {_sim.EnEspera - maxTarjetas} vuelo(s) más", _fuenteNegrita,
                new Point(14, yCola + 3 * (altoT + sep)), Color.Gray);

        // Leyenda
        int xLey = 14, yLey = picTorre.Height - 22;
        foreach (TipoVuelo t in Enum.GetValues<TipoVuelo>())
        {
            _pincel.Color = ColoresTipo[(int)t];
            g.FillRectangle(_pincel, xLey, yLey + 3, 12, 12);
            string texto = $"{Vuelo.Nombre(t)} (prioridad {(int)t})";
            TextRenderer.DrawText(g, texto, _fuenteChica, new Point(xLey + 16, yLey + 2), Color.Black);
            xLey += TextRenderer.MeasureText(texto, _fuenteChica).Width + 34;
        }
    }

    // ═══════════════════════ COMPARACIÓN FIFO VS. PRIORIDAD ═══════════════════════

    private async void BtnComparar_Click(object? sender, EventArgs e)
    {
        int semilla = (int)nudSemilla.Value;
        int minutos = (int)nudMinutos.Value;
        double probabilidad = (double)nudProbabilidad.Value / 100;

        btnComparar.Enabled = false;
        var resultado = await Task.Run(() => Simulador.Comparar(semilla, probabilidad, minutos));
        _comparacion = resultado;
        btnComparar.Enabled = true;

        dgvComparacion.Rows.Clear();
        foreach (TipoVuelo t in Enum.GetValues<TipoVuelo>())
        {
            EstadisticaTipo f = resultado.Fifo.Estadistica(t), p = resultado.Prioridad.Estadistica(t);
            double cambio = p.EsperaPromedio - f.EsperaPromedio;
            dgvComparacion.Rows.Add(Vuelo.Nombre(t), $"{f.EsperaPromedio:0.0}", f.EsperaMaxima,
                $"{p.EsperaPromedio:0.0}", p.EsperaMaxima, $"{cambio:+0.0;-0.0;0.0} min");
        }
        dgvComparacion.Rows.Add("Todos", $"{resultado.Fifo.EsperaPromedioGeneral:0.0}", "",
            $"{resultado.Prioridad.EsperaPromedioGeneral:0.0}", "", "");

        lblEstado.Text = $"Comparación: {minutos} min, {probabilidad:P0} de llegada, semilla {semilla}. " +
                         $"Atendidos: {resultado.Fifo.TotalAtendidos} (FIFO) y {resultado.Prioridad.TotalAtendidos} (prioridad)";
        picComparacion.Invalidate();
    }

    /// <summary>Barras agrupadas: espera promedio por tipo de vuelo en cada modo.</summary>
    private void PicComparacion_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (_comparacion is not (Simulador fifo, Simulador prioridad))
        {
            TextRenderer.DrawText(g, "Presiona «Comparar FIFO vs. prioridad» para ver la gráfica.", Font,
                picComparacion.ClientRectangle, Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            return;
        }

        var area = new Rectangle(50, 26, picComparacion.Width - 70, picComparacion.Height - 50);
        TipoVuelo[] tipos = Enum.GetValues<TipoVuelo>();
        double maximo = 1;
        foreach (TipoVuelo t in tipos)
            maximo = Math.Max(maximo, Math.Max(fifo.Estadistica(t).EsperaPromedio, prioridad.Estadistica(t).EsperaPromedio));
        maximo = Math.Ceiling(maximo / 5) * 5;

        using var rejilla = new Pen(Color.Gainsboro);
        for (int k = 0; k <= 5; k++)
        {
            float y = area.Bottom - k * area.Height / 5f;
            g.DrawLine(rejilla, area.Left, y, area.Right, y);
            TextRenderer.DrawText(g, $"{maximo * k / 5:0}", _fuenteChica, new Rectangle(0, (int)y - 7, area.Left - 4, 14),
                Color.DimGray, TextFormatFlags.Right);
        }

        TextRenderer.DrawText(g, "Espera promedio por tipo de vuelo (minutos)", _fuenteNegrita, new Point(area.Left, 4), Color.Black);

        float anchoGrupo = area.Width / (float)tipos.Length;
        float anchoBarra = anchoGrupo * 0.3F;
        using var pincelFifo = new SolidBrush(Color.FromArgb(150, 160, 175));
        using var pincelPrioridad = new SolidBrush(Color.FromArgb(25, 135, 60));

        for (int i = 0; i < tipos.Length; i++)
        {
            float centro = area.Left + anchoGrupo * (i + 0.5F);
            DibujarBarra(g, pincelFifo, centro - anchoBarra - 2, anchoBarra, fifo.Estadistica(tipos[i]).EsperaPromedio, maximo, area);
            DibujarBarra(g, pincelPrioridad, centro + 2, anchoBarra, prioridad.Estadistica(tipos[i]).EsperaPromedio, maximo, area);
            TextRenderer.DrawText(g, Vuelo.Nombre(tipos[i]), _fuenteNegrita,
                new Rectangle((int)(centro - anchoGrupo / 2), area.Bottom + 3, (int)anchoGrupo, 18), ColoresTipo[i], TextFormatFlags.HorizontalCenter);
        }

        // Leyenda
        g.FillRectangle(pincelFifo, area.Right - 190, 6, 12, 12);
        TextRenderer.DrawText(g, "FIFO", _fuenteChica, new Point(area.Right - 174, 5), Color.Black);
        g.FillRectangle(pincelPrioridad, area.Right - 120, 6, 12, 12);
        TextRenderer.DrawText(g, "Prioridad", _fuenteChica, new Point(area.Right - 104, 5), Color.Black);
    }

    private void DibujarBarra(Graphics g, Brush pincel, float x, float ancho, double valor, double maximo, Rectangle area)
    {
        float alto = (float)(valor / maximo * area.Height);
        g.FillRectangle(pincel, x, area.Bottom - alto, ancho, alto);
        TextRenderer.DrawText(g, valor.ToString("0.0"), _fuenteChica,
            new Rectangle((int)x - 10, (int)(area.Bottom - alto) - 15, (int)ancho + 20, 14), Color.Black, TextFormatFlags.HorizontalCenter);
    }

    // ═══════════════════════ CASOS DE PRUEBA ═══════════════════════

    private void BtnPruebas_Click(object? sender, EventArgs e)
    {
        lstPruebas.Items.Clear();
        _aprobadas = _total = 0;

        // ----- Cola de prioridad -----
        var c = new ColaPrioridad<string>();
        Verificar("Cola nueva: EstaVacia = true y Cantidad = 0", c.EstaVacia && c.Cantidad == 0);
        Verificar("Desencolar en cola vacía lanza InvalidOperationException", Lanza<InvalidOperationException>(() => c.Desencolar()));

        c.Encolar("C", 2); c.Encolar("A", 0); c.Encolar("B", 1);
        Verificar("Sale primero la mayor prioridad: (C,2),(A,0),(B,1) → A, B, C",
            c.Desencolar() == "A" && c.Desencolar() == "B" && c.Desencolar() == "C");

        c.Encolar("X1", 2); c.Encolar("X2", 2); c.Encolar("X3", 2);
        Verificar("Misma prioridad respeta FIFO: X1, X2, X3", c.Desencolar() == "X1" && c.Desencolar() == "X2" && c.Desencolar() == "X3");

        c.Encolar("a", 0); c.Encolar("c", 2); c.Encolar("b1", 1); c.Encolar("b2", 1);
        Verificar("Inserción en medio estable: a, b1, b2, c", Texto(c) == "a,b1,b2,c");
        Verificar("VerFrente() devuelve 'a' sin eliminarlo", c.VerFrente() == "a" && c.Cantidad == 4);

        c.Limpiar();
        Verificar("Limpiar() deja la cola vacía", c.EstaVacia && Lanza<InvalidOperationException>(() => c.VerFrente()));

        // ----- Vuelo -----
        var v1 = new Vuelo("AM-100", TipoVuelo.Comercial, TipoOperacion.Aterrizaje, 5);
        var v2 = new Vuelo("AM-200", TipoVuelo.Carga, TipoOperacion.Despegue, 5) { MinutoAtencion = 12 };
        Verificar("Duración: aterrizaje = 3 min y despegue = 2 min", v1.Duracion == 3 && v2.Duracion == 2);
        Verificar("Espera = minuto de atención − minuto de llegada (12 − 5 = 7)", v2.Espera == 7);
        Verificar("Código vacío lanza ArgumentException", Lanza<ArgumentException>(() => new Vuelo(" ", TipoVuelo.Carga, TipoOperacion.Despegue, 0)));

        // ----- Simulador -----
        var simP = new Simulador(1, 0, usarPrioridad: true);    // probabilidad 0: solo vuelos manuales
        AgregarComercialesYEmergencia(simP);
        simP.AvanzarMinuto();
        Verificar("Con prioridad, una emergencia que llegó al último recibe la pista primero",
            simP.VueloEnPista?.Tipo == TipoVuelo.Emergencia);

        var simF = new Simulador(1, 0, usarPrioridad: false);
        AgregarComercialesYEmergencia(simF);
        simF.AvanzarMinuto();
        Verificar("En modo FIFO la pista se asigna al primero que llegó", simF.VueloEnPista?.Tipo == TipoVuelo.Comercial);

        var simD = new Simulador(1, 0, usarPrioridad: true);
        var a = simD.CrearVuelo(TipoVuelo.Comercial, TipoOperacion.Aterrizaje);
        var b = simD.CrearVuelo(TipoVuelo.Comercial, TipoOperacion.Despegue);
        simD.AgregarVuelo(a); simD.AgregarVuelo(b);
        simD.AvanzarMinuto(); simD.AvanzarMinuto(); simD.AvanzarMinuto();
        bool ocupada = simD.VueloEnPista == a;
        simD.AvanzarMinuto();
        Verificar("Un aterrizaje ocupa la pista 3 minutos; el siguiente vuelo entra en el minuto 4", ocupada && simD.VueloEnPista == b);
        Verificar("Se registra la espera del segundo vuelo (4 min)", b.Espera == 4 && simD.Estadistica(TipoVuelo.Comercial).EsperaMaxima == 4);

        Verificar("Probabilidad fuera de 0..1 lanza ArgumentException", Lanza<ArgumentException>(() => new Simulador(1, 1.5, true)));

        var r1 = Simulador.Comparar(2026, 0.35, 480);
        var r2 = Simulador.Comparar(2026, 0.35, 480);
        Verificar("La misma semilla produce exactamente los mismos resultados",
            r1.Prioridad.TotalAtendidos == r2.Prioridad.TotalAtendidos &&
            r1.Prioridad.EsperaPromedioGeneral == r2.Prioridad.EsperaPromedioGeneral);
        Verificar("FIFO y prioridad reciben los mismos vuelos (atendidos + en espera iguales)",
            r1.Fifo.TotalAtendidos + r1.Fifo.EnEspera == r1.Prioridad.TotalAtendidos + r1.Prioridad.EnEspera);
        Verificar("La prioridad reduce la espera promedio de las emergencias frente a FIFO",
            r1.Prioridad.Estadistica(TipoVuelo.Emergencia).EsperaPromedio < r1.Fifo.Estadistica(TipoVuelo.Emergencia).EsperaPromedio);

        MostrarResumen();
    }

    private static void AgregarComercialesYEmergencia(Simulador sim)
    {
        for (int i = 0; i < 3; i++)
            sim.AgregarVuelo(sim.CrearVuelo(TipoVuelo.Comercial, TipoOperacion.Despegue));
        sim.AgregarVuelo(sim.CrearVuelo(TipoVuelo.Emergencia, TipoOperacion.Aterrizaje));
    }

    private static string Texto(ColaPrioridad<string> cola)
    {
        var partes = new List<string>();
        foreach (var (valor, _) in cola.Recorrer())
            partes.Add(valor);
        return string.Join(",", partes);
    }

    private void Verificar(string descripcion, bool aprobada)
    {
        _total++;
        if (aprobada) _aprobadas++;
        lstPruebas.Items.Add($"{(aprobada ? "✔" : "✖")}  {_total,2}. {descripcion}");
    }

    private static bool Lanza<TExcepcion>(Action accion) where TExcepcion : Exception
    {
        try
        {
            accion();
            return false;
        }
        catch (TExcepcion)
        {
            return true;
        }
    }

    private void MostrarResumen()
    {
        bool todas = _aprobadas == _total;
        lblResumen.Text = $"{_aprobadas} de {_total} pruebas aprobadas";
        lblResumen.ForeColor = todas ? Color.FromArgb(25, 110, 50) : Color.FromArgb(170, 30, 30);
        lblEstado.Text = lblResumen.Text;
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        tmrSimulacion.Stop();
        _fuenteGrande.Dispose();
        _fuenteNegrita.Dispose();
        _fuenteChica.Dispose();
        _pincel.Dispose();
        base.OnFormClosed(e);
    }
}