namespace TorreDeControl
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlLateral = new Panel();
            grpResumen = new GroupBox();
            lblColaMaxima = new Label();
            lblTitMaxima = new Label();
            lblAtendidos = new Label();
            lblTitAtendidos = new Label();
            lblEnEspera = new Label();
            lblTitEspera = new Label();
            lblMinuto = new Label();
            lblTitMinuto = new Label();
            grpSimulacion = new GroupBox();
            btnReiniciar = new Button();
            btnPaso = new Button();
            btnIniciar = new Button();
            trkVelocidad = new TrackBar();
            lblVelocidad = new Label();
            nudProbabilidad = new NumericUpDown();
            lblProbabilidad = new Label();
            rbFifo = new RadioButton();
            rbPrioridad = new RadioButton();
            grpNuevo = new GroupBox();
            btnAgregar = new Button();
            cmbOperacion = new ComboBox();
            lblOperacion = new Label();
            cmbTipo = new ComboBox();
            lblTipo = new Label();
            tabPrincipal = new TabControl();
            tabTorre = new TabPage();
            picTorre = new PictureBox();
            grpBitacora = new GroupBox();
            lstBitacora = new ListBox();
            tabEstadisticas = new TabPage();
            picComparacion = new PictureBox();
            dgvComparacion = new DataGridView();
            colCTipo = new DataGridViewTextBoxColumn();
            colFifoProm = new DataGridViewTextBoxColumn();
            colFifoMax = new DataGridViewTextBoxColumn();
            colPrioProm = new DataGridViewTextBoxColumn();
            colPrioMax = new DataGridViewTextBoxColumn();
            colDiferencia = new DataGridViewTextBoxColumn();
            pnlCompBarra = new Panel();
            btnComparar = new Button();
            nudMinutos = new NumericUpDown();
            lblMinutos = new Label();
            nudSemilla = new NumericUpDown();
            lblSemilla = new Label();
            pnlActual = new Panel();
            dgvEstadisticas = new DataGridView();
            colTipo = new DataGridViewTextBoxColumn();
            colPrioridad = new DataGridViewTextBoxColumn();
            colAtendidos = new DataGridViewTextBoxColumn();
            colPromedio = new DataGridViewTextBoxColumn();
            colMaxima = new DataGridViewTextBoxColumn();
            lblActual = new Label();
            tabPruebas = new TabPage();
            lstPruebas = new ListBox();
            pnlBarraPruebas = new Panel();
            lblResumen = new Label();
            btnPruebas = new Button();
            statusStrip = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            tmrSimulacion = new System.Windows.Forms.Timer(components);
            pnlEncabezado.SuspendLayout();
            pnlLateral.SuspendLayout();
            grpResumen.SuspendLayout();
            grpSimulacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudProbabilidad).BeginInit();
            grpNuevo.SuspendLayout();
            tabPrincipal.SuspendLayout();
            tabTorre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTorre).BeginInit();
            grpBitacora.SuspendLayout();
            tabEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picComparacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvComparacion).BeginInit();
            pnlCompBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).BeginInit();
            pnlActual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstadisticas).BeginInit();
            tabPruebas.SuspendLayout();
            pnlBarraPruebas.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(31, 58, 96);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1000, 68);
            pnlEncabezado.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(18, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(420, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "✈  Torre de control: despacho de aviones";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 215, 235);
            lblSubtitulo.Location = new Point(21, 40);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(430, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Simulación con cola de prioridad (lista enlazada ordenada)  •  Estructura de Datos";
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.FromArgb(240, 243, 248);
            pnlLateral.Controls.Add(grpResumen);
            pnlLateral.Controls.Add(grpSimulacion);
            pnlLateral.Controls.Add(grpNuevo);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 68);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(300, 570);
            pnlLateral.TabIndex = 1;
            // 
            // grpNuevo
            // 
            grpNuevo.Controls.Add(btnAgregar);
            grpNuevo.Controls.Add(cmbOperacion);
            grpNuevo.Controls.Add(lblOperacion);
            grpNuevo.Controls.Add(cmbTipo);
            grpNuevo.Controls.Add(lblTipo);
            grpNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpNuevo.ForeColor = Color.FromArgb(31, 58, 96);
            grpNuevo.Location = new Point(12, 12);
            grpNuevo.Name = "grpNuevo";
            grpNuevo.Size = new Size(276, 140);
            grpNuevo.TabIndex = 0;
            grpNuevo.TabStop = false;
            grpNuevo.Text = "1. Solicitud manual de pista";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9F);
            lblTipo.ForeColor = Color.Black;
            lblTipo.Location = new Point(12, 30);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(75, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de vuelo:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 9F);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(100, 26);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(164, 23);
            cmbTipo.TabIndex = 1;
            // 
            // lblOperacion
            // 
            lblOperacion.AutoSize = true;
            lblOperacion.Font = new Font("Segoe UI", 9F);
            lblOperacion.ForeColor = Color.Black;
            lblOperacion.Location = new Point(12, 62);
            lblOperacion.Name = "lblOperacion";
            lblOperacion.Size = new Size(64, 15);
            lblOperacion.TabIndex = 2;
            lblOperacion.Text = "Operación:";
            // 
            // cmbOperacion
            // 
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.Font = new Font("Segoe UI", 9F);
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Location = new Point(100, 58);
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.Size = new Size(164, 23);
            cmbOperacion.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(0, 120, 215);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(12, 94);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(252, 34);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "+  Agregar vuelo a la cola";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // grpSimulacion
            // 
            grpSimulacion.Controls.Add(btnReiniciar);
            grpSimulacion.Controls.Add(btnPaso);
            grpSimulacion.Controls.Add(btnIniciar);
            grpSimulacion.Controls.Add(trkVelocidad);
            grpSimulacion.Controls.Add(lblVelocidad);
            grpSimulacion.Controls.Add(nudProbabilidad);
            grpSimulacion.Controls.Add(lblProbabilidad);
            grpSimulacion.Controls.Add(rbFifo);
            grpSimulacion.Controls.Add(rbPrioridad);
            grpSimulacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpSimulacion.ForeColor = Color.FromArgb(31, 58, 96);
            grpSimulacion.Location = new Point(12, 160);
            grpSimulacion.Name = "grpSimulacion";
            grpSimulacion.Size = new Size(276, 228);
            grpSimulacion.TabIndex = 1;
            grpSimulacion.TabStop = false;
            grpSimulacion.Text = "2. Simulación";
            // 
            // rbPrioridad
            // 
            rbPrioridad.AutoSize = true;
            rbPrioridad.Checked = true;
            rbPrioridad.Font = new Font("Segoe UI", 9F);
            rbPrioridad.ForeColor = Color.Black;
            rbPrioridad.Location = new Point(14, 26);
            rbPrioridad.Name = "rbPrioridad";
            rbPrioridad.Size = new Size(130, 19);
            rbPrioridad.TabIndex = 0;
            rbPrioridad.TabStop = true;
            rbPrioridad.Text = "Cola de prioridad";
            rbPrioridad.UseVisualStyleBackColor = true;
            rbPrioridad.CheckedChanged += RbModo_CheckedChanged;
            // 
            // rbFifo
            // 
            rbFifo.AutoSize = true;
            rbFifo.Font = new Font("Segoe UI", 9F);
            rbFifo.ForeColor = Color.Black;
            rbFifo.Location = new Point(14, 50);
            rbFifo.Name = "rbFifo";
            rbFifo.Size = new Size(200, 19);
            rbFifo.TabIndex = 1;
            rbFifo.Text = "Cola FIFO simple (sin prioridad)";
            rbFifo.UseVisualStyleBackColor = true;
            // 
            // lblProbabilidad
            // 
            lblProbabilidad.AutoSize = true;
            lblProbabilidad.Font = new Font("Segoe UI", 9F);
            lblProbabilidad.ForeColor = Color.Black;
            lblProbabilidad.Location = new Point(12, 84);
            lblProbabilidad.Name = "lblProbabilidad";
            lblProbabilidad.Size = new Size(160, 15);
            lblProbabilidad.TabIndex = 2;
            lblProbabilidad.Text = "Probabilidad de llegada (%):";
            // 
            // nudProbabilidad
            // 
            nudProbabilidad.Font = new Font("Segoe UI", 9F);
            nudProbabilidad.Location = new Point(190, 81);
            nudProbabilidad.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            nudProbabilidad.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudProbabilidad.Name = "nudProbabilidad";
            nudProbabilidad.Size = new Size(74, 23);
            nudProbabilidad.TabIndex = 3;
            nudProbabilidad.TextAlign = HorizontalAlignment.Center;
            nudProbabilidad.Value = new decimal(new int[] { 35, 0, 0, 0 });
            nudProbabilidad.ValueChanged += NudProbabilidad_ValueChanged;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Font = new Font("Segoe UI", 9F);
            lblVelocidad.ForeColor = Color.Black;
            lblVelocidad.Location = new Point(12, 120);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(60, 15);
            lblVelocidad.TabIndex = 4;
            lblVelocidad.Text = "Velocidad:";
            // 
            // trkVelocidad
            // 
            trkVelocidad.Location = new Point(80, 112);
            trkVelocidad.Minimum = 1;
            trkVelocidad.Name = "trkVelocidad";
            trkVelocidad.Size = new Size(184, 45);
            trkVelocidad.TabIndex = 5;
            trkVelocidad.Value = 5;
            trkVelocidad.Scroll += TrkVelocidad_Scroll;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(0, 120, 215);
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.FlatAppearance.BorderSize = 0;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.Location = new Point(12, 152);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(252, 36);
            btnIniciar.TabIndex = 6;
            btnIniciar.Text = "▶  Iniciar simulación";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += BtnIniciar_Click;
            // 
            // btnPaso
            // 
            btnPaso.Cursor = Cursors.Hand;
            btnPaso.Font = new Font("Segoe UI", 9F);
            btnPaso.ForeColor = Color.Black;
            btnPaso.Location = new Point(12, 192);
            btnPaso.Name = "btnPaso";
            btnPaso.Size = new Size(123, 28);
            btnPaso.TabIndex = 7;
            btnPaso.Text = "Avanzar 1 min";
            btnPaso.UseVisualStyleBackColor = true;
            btnPaso.Click += BtnPaso_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Cursor = Cursors.Hand;
            btnReiniciar.Font = new Font("Segoe UI", 9F);
            btnReiniciar.ForeColor = Color.Black;
            btnReiniciar.Location = new Point(141, 192);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(123, 28);
            btnReiniciar.TabIndex = 8;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += BtnReiniciar_Click;
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblColaMaxima);
            grpResumen.Controls.Add(lblTitMaxima);
            grpResumen.Controls.Add(lblAtendidos);
            grpResumen.Controls.Add(lblTitAtendidos);
            grpResumen.Controls.Add(lblEnEspera);
            grpResumen.Controls.Add(lblTitEspera);
            grpResumen.Controls.Add(lblMinuto);
            grpResumen.Controls.Add(lblTitMinuto);
            grpResumen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpResumen.ForeColor = Color.FromArgb(31, 58, 96);
            grpResumen.Location = new Point(12, 396);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(276, 138);
            grpResumen.TabIndex = 2;
            grpResumen.TabStop = false;
            grpResumen.Text = "3. Resumen";
            // 
            // lblTitMinuto
            // 
            lblTitMinuto.AutoSize = true;
            lblTitMinuto.Font = new Font("Segoe UI", 9F);
            lblTitMinuto.ForeColor = Color.DimGray;
            lblTitMinuto.Location = new Point(14, 28);
            lblTitMinuto.Name = "lblTitMinuto";
            lblTitMinuto.Size = new Size(83, 15);
            lblTitMinuto.TabIndex = 0;
            lblTitMinuto.Text = "Minuto actual:";
            // 
            // lblMinuto
            // 
            lblMinuto.AutoSize = true;
            lblMinuto.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblMinuto.ForeColor = Color.Black;
            lblMinuto.Location = new Point(170, 26);
            lblMinuto.Name = "lblMinuto";
            lblMinuto.Size = new Size(16, 18);
            lblMinuto.TabIndex = 1;
            lblMinuto.Text = "0";
            // 
            // lblTitEspera
            // 
            lblTitEspera.AutoSize = true;
            lblTitEspera.Font = new Font("Segoe UI", 9F);
            lblTitEspera.ForeColor = Color.DimGray;
            lblTitEspera.Location = new Point(14, 54);
            lblTitEspera.Name = "lblTitEspera";
            lblTitEspera.Size = new Size(103, 15);
            lblTitEspera.TabIndex = 2;
            lblTitEspera.Text = "Vuelos en espera:";
            // 
            // lblEnEspera
            // 
            lblEnEspera.AutoSize = true;
            lblEnEspera.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblEnEspera.ForeColor = Color.FromArgb(0, 90, 200);
            lblEnEspera.Location = new Point(170, 52);
            lblEnEspera.Name = "lblEnEspera";
            lblEnEspera.Size = new Size(16, 18);
            lblEnEspera.TabIndex = 3;
            lblEnEspera.Text = "0";
            // 
            // lblTitAtendidos
            // 
            lblTitAtendidos.AutoSize = true;
            lblTitAtendidos.Font = new Font("Segoe UI", 9F);
            lblTitAtendidos.ForeColor = Color.DimGray;
            lblTitAtendidos.Location = new Point(14, 80);
            lblTitAtendidos.Name = "lblTitAtendidos";
            lblTitAtendidos.Size = new Size(100, 15);
            lblTitAtendidos.TabIndex = 4;
            lblTitAtendidos.Text = "Vuelos atendidos:";
            // 
            // lblAtendidos
            // 
            lblAtendidos.AutoSize = true;
            lblAtendidos.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblAtendidos.ForeColor = Color.Black;
            lblAtendidos.Location = new Point(170, 78);
            lblAtendidos.Name = "lblAtendidos";
            lblAtendidos.Size = new Size(16, 18);
            lblAtendidos.TabIndex = 5;
            lblAtendidos.Text = "0";
            // 
            // lblTitMaxima
            // 
            lblTitMaxima.AutoSize = true;
            lblTitMaxima.Font = new Font("Segoe UI", 9F);
            lblTitMaxima.ForeColor = Color.DimGray;
            lblTitMaxima.Location = new Point(14, 106);
            lblTitMaxima.Name = "lblTitMaxima";
            lblTitMaxima.Size = new Size(140, 15);
            lblTitMaxima.TabIndex = 6;
            lblTitMaxima.Text = "Cola máxima / espera prom.:";
            // 
            // lblColaMaxima
            // 
            lblColaMaxima.AutoSize = true;
            lblColaMaxima.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblColaMaxima.ForeColor = Color.Black;
            lblColaMaxima.Location = new Point(170, 104);
            lblColaMaxima.Name = "lblColaMaxima";
            lblColaMaxima.Size = new Size(16, 18);
            lblColaMaxima.TabIndex = 7;
            lblColaMaxima.Text = "0";
            // 
            // tabPrincipal
            // 
            tabPrincipal.Controls.Add(tabTorre);
            tabPrincipal.Controls.Add(tabEstadisticas);
            tabPrincipal.Controls.Add(tabPruebas);
            tabPrincipal.Dock = DockStyle.Fill;
            tabPrincipal.Font = new Font("Segoe UI", 9.75F);
            tabPrincipal.Location = new Point(300, 68);
            tabPrincipal.Name = "tabPrincipal";
            tabPrincipal.Padding = new Point(12, 5);
            tabPrincipal.SelectedIndex = 0;
            tabPrincipal.Size = new Size(700, 570);
            tabPrincipal.TabIndex = 2;
            // 
            // tabTorre
            // 
            tabTorre.Controls.Add(picTorre);
            tabTorre.Controls.Add(grpBitacora);
            tabTorre.Location = new Point(4, 30);
            tabTorre.Name = "tabTorre";
            tabTorre.Padding = new Padding(6);
            tabTorre.Size = new Size(692, 536);
            tabTorre.TabIndex = 0;
            tabTorre.Text = "Torre de control";
            tabTorre.UseVisualStyleBackColor = true;
            // 
            // picTorre
            // 
            picTorre.BackColor = Color.White;
            picTorre.Dock = DockStyle.Fill;
            picTorre.Location = new Point(6, 6);
            picTorre.Name = "picTorre";
            picTorre.Size = new Size(680, 374);
            picTorre.TabIndex = 0;
            picTorre.TabStop = false;
            picTorre.Paint += PicTorre_Paint;
            // 
            // grpBitacora
            // 
            grpBitacora.Controls.Add(lstBitacora);
            grpBitacora.Dock = DockStyle.Bottom;
            grpBitacora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpBitacora.ForeColor = Color.FromArgb(31, 58, 96);
            grpBitacora.Location = new Point(6, 380);
            grpBitacora.Name = "grpBitacora";
            grpBitacora.Padding = new Padding(8);
            grpBitacora.Size = new Size(680, 150);
            grpBitacora.TabIndex = 1;
            grpBitacora.TabStop = false;
            grpBitacora.Text = "Bitácora de la torre";
            // 
            // lstBitacora
            // 
            lstBitacora.BorderStyle = BorderStyle.None;
            lstBitacora.Dock = DockStyle.Fill;
            lstBitacora.Font = new Font("Consolas", 9F);
            lstBitacora.ForeColor = Color.Black;
            lstBitacora.HorizontalScrollbar = true;
            lstBitacora.IntegralHeight = false;
            lstBitacora.ItemHeight = 14;
            lstBitacora.Location = new Point(8, 24);
            lstBitacora.Name = "lstBitacora";
            lstBitacora.Size = new Size(664, 118);
            lstBitacora.TabIndex = 0;
            // 
            // tabEstadisticas
            // 
            tabEstadisticas.Controls.Add(picComparacion);
            tabEstadisticas.Controls.Add(dgvComparacion);
            tabEstadisticas.Controls.Add(pnlCompBarra);
            tabEstadisticas.Controls.Add(pnlActual);
            tabEstadisticas.Location = new Point(4, 30);
            tabEstadisticas.Name = "tabEstadisticas";
            tabEstadisticas.Padding = new Padding(8);
            tabEstadisticas.Size = new Size(692, 536);
            tabEstadisticas.TabIndex = 1;
            tabEstadisticas.Text = "Estadísticas y comparación";
            tabEstadisticas.UseVisualStyleBackColor = true;
            // 
            // pnlActual
            // 
            pnlActual.Controls.Add(dgvEstadisticas);
            pnlActual.Controls.Add(lblActual);
            pnlActual.Dock = DockStyle.Top;
            pnlActual.Location = new Point(8, 8);
            pnlActual.Name = "pnlActual";
            pnlActual.Size = new Size(676, 160);
            pnlActual.TabIndex = 0;
            // 
            // lblActual
            // 
            lblActual.Dock = DockStyle.Top;
            lblActual.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblActual.ForeColor = Color.FromArgb(31, 58, 96);
            lblActual.Location = new Point(0, 0);
            lblActual.Name = "lblActual";
            lblActual.Size = new Size(676, 24);
            lblActual.TabIndex = 0;
            lblActual.Text = "Simulación actual: esperas por tipo de vuelo";
            // 
            // dgvEstadisticas
            // 
            dgvEstadisticas.AllowUserToAddRows = false;
            dgvEstadisticas.AllowUserToDeleteRows = false;
            dgvEstadisticas.AllowUserToResizeRows = false;
            dgvEstadisticas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstadisticas.BackgroundColor = Color.White;
            dgvEstadisticas.BorderStyle = BorderStyle.None;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estiloEncabezado.BackColor = Color.FromArgb(31, 58, 96);
            estiloEncabezado.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.White;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(31, 58, 96);
            estiloEncabezado.SelectionForeColor = Color.White;
            estiloEncabezado.WrapMode = DataGridViewTriState.True;
            dgvEstadisticas.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvEstadisticas.ColumnHeadersHeight = 34;
            dgvEstadisticas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstadisticas.Columns.AddRange(new DataGridViewColumn[] { colTipo, colPrioridad, colAtendidos, colPromedio, colMaxima });
            dgvEstadisticas.Dock = DockStyle.Fill;
            dgvEstadisticas.EnableHeadersVisualStyles = false;
            dgvEstadisticas.Font = new Font("Segoe UI", 9F);
            dgvEstadisticas.Location = new Point(0, 24);
            dgvEstadisticas.Name = "dgvEstadisticas";
            dgvEstadisticas.ReadOnly = true;
            dgvEstadisticas.RowHeadersVisible = false;
            dgvEstadisticas.RowTemplate.Height = 24;
            dgvEstadisticas.Size = new Size(676, 136);
            dgvEstadisticas.TabIndex = 1;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo de vuelo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colPrioridad
            // 
            colPrioridad.HeaderText = "Prioridad";
            colPrioridad.Name = "colPrioridad";
            colPrioridad.ReadOnly = true;
            // 
            // colAtendidos
            // 
            colAtendidos.HeaderText = "Atendidos";
            colAtendidos.Name = "colAtendidos";
            colAtendidos.ReadOnly = true;
            // 
            // colPromedio
            // 
            colPromedio.HeaderText = "Espera promedio (min)";
            colPromedio.Name = "colPromedio";
            colPromedio.ReadOnly = true;
            // 
            // colMaxima
            // 
            colMaxima.HeaderText = "Espera máxima (min)";
            colMaxima.Name = "colMaxima";
            colMaxima.ReadOnly = true;
            // 
            // pnlCompBarra
            // 
            pnlCompBarra.Controls.Add(btnComparar);
            pnlCompBarra.Controls.Add(nudMinutos);
            pnlCompBarra.Controls.Add(lblMinutos);
            pnlCompBarra.Controls.Add(nudSemilla);
            pnlCompBarra.Controls.Add(lblSemilla);
            pnlCompBarra.Dock = DockStyle.Top;
            pnlCompBarra.Location = new Point(8, 168);
            pnlCompBarra.Name = "pnlCompBarra";
            pnlCompBarra.Size = new Size(676, 48);
            pnlCompBarra.TabIndex = 1;
            // 
            // lblSemilla
            // 
            lblSemilla.AutoSize = true;
            lblSemilla.Font = new Font("Segoe UI", 9F);
            lblSemilla.Location = new Point(2, 17);
            lblSemilla.Name = "lblSemilla";
            lblSemilla.Size = new Size(48, 15);
            lblSemilla.TabIndex = 0;
            lblSemilla.Text = "Semilla:";
            // 
            // nudSemilla
            // 
            nudSemilla.Font = new Font("Segoe UI", 9F);
            nudSemilla.Location = new Point(56, 14);
            nudSemilla.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudSemilla.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSemilla.Name = "nudSemilla";
            nudSemilla.Size = new Size(80, 23);
            nudSemilla.TabIndex = 1;
            nudSemilla.TextAlign = HorizontalAlignment.Center;
            nudSemilla.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblMinutos
            // 
            lblMinutos.AutoSize = true;
            lblMinutos.Font = new Font("Segoe UI", 9F);
            lblMinutos.Location = new Point(150, 17);
            lblMinutos.Name = "lblMinutos";
            lblMinutos.Size = new Size(54, 15);
            lblMinutos.TabIndex = 2;
            lblMinutos.Text = "Minutos:";
            // 
            // nudMinutos
            // 
            nudMinutos.Font = new Font("Segoe UI", 9F);
            nudMinutos.Location = new Point(210, 14);
            nudMinutos.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudMinutos.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            nudMinutos.Name = "nudMinutos";
            nudMinutos.Size = new Size(70, 23);
            nudMinutos.TabIndex = 3;
            nudMinutos.TextAlign = HorizontalAlignment.Center;
            nudMinutos.Value = new decimal(new int[] { 480, 0, 0, 0 });
            // 
            // btnComparar
            // 
            btnComparar.BackColor = Color.FromArgb(0, 120, 215);
            btnComparar.Cursor = Cursors.Hand;
            btnComparar.FlatAppearance.BorderSize = 0;
            btnComparar.FlatStyle = FlatStyle.Flat;
            btnComparar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnComparar.ForeColor = Color.White;
            btnComparar.Location = new Point(296, 8);
            btnComparar.Name = "btnComparar";
            btnComparar.Size = new Size(270, 34);
            btnComparar.TabIndex = 4;
            btnComparar.Text = "▶  Comparar FIFO vs. prioridad";
            btnComparar.UseVisualStyleBackColor = false;
            btnComparar.Click += BtnComparar_Click;
            // 
            // dgvComparacion
            // 
            dgvComparacion.AllowUserToAddRows = false;
            dgvComparacion.AllowUserToDeleteRows = false;
            dgvComparacion.AllowUserToResizeRows = false;
            dgvComparacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComparacion.BackgroundColor = Color.White;
            dgvComparacion.BorderStyle = BorderStyle.None;
            dgvComparacion.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvComparacion.ColumnHeadersHeight = 34;
            dgvComparacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvComparacion.Columns.AddRange(new DataGridViewColumn[] { colCTipo, colFifoProm, colFifoMax, colPrioProm, colPrioMax, colDiferencia });
            dgvComparacion.Dock = DockStyle.Top;
            dgvComparacion.EnableHeadersVisualStyles = false;
            dgvComparacion.Font = new Font("Segoe UI", 9F);
            dgvComparacion.Location = new Point(8, 216);
            dgvComparacion.Name = "dgvComparacion";
            dgvComparacion.ReadOnly = true;
            dgvComparacion.RowHeadersVisible = false;
            dgvComparacion.RowTemplate.Height = 22;
            dgvComparacion.Size = new Size(676, 148);
            dgvComparacion.TabIndex = 2;
            // 
            // colCTipo
            // 
            colCTipo.HeaderText = "Tipo de vuelo";
            colCTipo.Name = "colCTipo";
            colCTipo.ReadOnly = true;
            // 
            // colFifoProm
            // 
            colFifoProm.HeaderText = "FIFO: espera prom.";
            colFifoProm.Name = "colFifoProm";
            colFifoProm.ReadOnly = true;
            // 
            // colFifoMax
            // 
            colFifoMax.HeaderText = "FIFO: espera máx.";
            colFifoMax.Name = "colFifoMax";
            colFifoMax.ReadOnly = true;
            // 
            // colPrioProm
            // 
            colPrioProm.HeaderText = "Prioridad: espera prom.";
            colPrioProm.Name = "colPrioProm";
            colPrioProm.ReadOnly = true;
            // 
            // colPrioMax
            // 
            colPrioMax.HeaderText = "Prioridad: espera máx.";
            colPrioMax.Name = "colPrioMax";
            colPrioMax.ReadOnly = true;
            // 
            // colDiferencia
            // 
            colDiferencia.HeaderText = "Cambio en la espera prom.";
            colDiferencia.Name = "colDiferencia";
            colDiferencia.ReadOnly = true;
            // 
            // picComparacion
            // 
            picComparacion.BackColor = Color.White;
            picComparacion.Dock = DockStyle.Fill;
            picComparacion.Location = new Point(8, 364);
            picComparacion.Name = "picComparacion";
            picComparacion.Size = new Size(676, 164);
            picComparacion.TabIndex = 3;
            picComparacion.TabStop = false;
            picComparacion.Paint += PicComparacion_Paint;
            // 
            // tabPruebas
            // 
            tabPruebas.Controls.Add(lstPruebas);
            tabPruebas.Controls.Add(pnlBarraPruebas);
            tabPruebas.Location = new Point(4, 30);
            tabPruebas.Name = "tabPruebas";
            tabPruebas.Padding = new Padding(8);
            tabPruebas.Size = new Size(692, 536);
            tabPruebas.TabIndex = 2;
            tabPruebas.Text = "Casos de prueba";
            tabPruebas.UseVisualStyleBackColor = true;
            // 
            // pnlBarraPruebas
            // 
            pnlBarraPruebas.Controls.Add(lblResumen);
            pnlBarraPruebas.Controls.Add(btnPruebas);
            pnlBarraPruebas.Dock = DockStyle.Top;
            pnlBarraPruebas.Location = new Point(8, 8);
            pnlBarraPruebas.Name = "pnlBarraPruebas";
            pnlBarraPruebas.Size = new Size(676, 50);
            pnlBarraPruebas.TabIndex = 0;
            // 
            // btnPruebas
            // 
            btnPruebas.BackColor = Color.FromArgb(0, 120, 215);
            btnPruebas.Cursor = Cursors.Hand;
            btnPruebas.FlatAppearance.BorderSize = 0;
            btnPruebas.FlatStyle = FlatStyle.Flat;
            btnPruebas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPruebas.ForeColor = Color.White;
            btnPruebas.Location = new Point(0, 8);
            btnPruebas.Name = "btnPruebas";
            btnPruebas.Size = new Size(200, 34);
            btnPruebas.TabIndex = 0;
            btnPruebas.Text = "▶  Ejecutar pruebas";
            btnPruebas.UseVisualStyleBackColor = false;
            btnPruebas.Click += BtnPruebas_Click;
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblResumen.Location = new Point(215, 15);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(0, 20);
            lblResumen.TabIndex = 1;
            // 
            // lstPruebas
            // 
            lstPruebas.BorderStyle = BorderStyle.FixedSingle;
            lstPruebas.Dock = DockStyle.Fill;
            lstPruebas.Font = new Font("Consolas", 10F);
            lstPruebas.HorizontalScrollbar = true;
            lstPruebas.IntegralHeight = false;
            lstPruebas.ItemHeight = 15;
            lstPruebas.Location = new Point(8, 58);
            lstPruebas.Name = "lstPruebas";
            lstPruebas.Size = new Size(676, 470);
            lstPruebas.TabIndex = 1;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblEstado });
            statusStrip.Location = new Point(0, 638);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1000, 22);
            statusStrip.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(35, 17);
            lblEstado.Text = "Listo";
            // 
            // tmrSimulacion
            // 
            tmrSimulacion.Interval = 600;
            tmrSimulacion.Tick += TmrSimulacion_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 660);
            Controls.Add(tabPrincipal);
            Controls.Add(pnlLateral);
            Controls.Add(pnlEncabezado);
            Controls.Add(statusStrip);
            MinimumSize = new Size(1016, 699);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Torre de control – Cola de prioridad";
            Load += Form1_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlLateral.ResumeLayout(false);
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            grpSimulacion.ResumeLayout(false);
            grpSimulacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudProbabilidad).EndInit();
            grpNuevo.ResumeLayout(false);
            grpNuevo.PerformLayout();
            tabPrincipal.ResumeLayout(false);
            tabTorre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTorre).EndInit();
            grpBitacora.ResumeLayout(false);
            tabEstadisticas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picComparacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvComparacion).EndInit();
            pnlCompBarra.ResumeLayout(false);
            pnlCompBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemilla).EndInit();
            pnlActual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEstadisticas).EndInit();
            tabPruebas.ResumeLayout(false);
            pnlBarraPruebas.ResumeLayout(false);
            pnlBarraPruebas.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlLateral;
        private GroupBox grpNuevo;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblOperacion;
        private ComboBox cmbOperacion;
        private Button btnAgregar;
        private GroupBox grpSimulacion;
        private RadioButton rbPrioridad;
        private RadioButton rbFifo;
        private Label lblProbabilidad;
        private NumericUpDown nudProbabilidad;
        private Label lblVelocidad;
        private TrackBar trkVelocidad;
        private Button btnIniciar;
        private Button btnPaso;
        private Button btnReiniciar;
        private GroupBox grpResumen;
        private Label lblTitMinuto;
        private Label lblMinuto;
        private Label lblTitEspera;
        private Label lblEnEspera;
        private Label lblTitAtendidos;
        private Label lblAtendidos;
        private Label lblTitMaxima;
        private Label lblColaMaxima;
        private TabControl tabPrincipal;
        private TabPage tabTorre;
        private PictureBox picTorre;
        private GroupBox grpBitacora;
        private ListBox lstBitacora;
        private TabPage tabEstadisticas;
        private Panel pnlActual;
        private Label lblActual;
        private DataGridView dgvEstadisticas;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colPrioridad;
        private DataGridViewTextBoxColumn colAtendidos;
        private DataGridViewTextBoxColumn colPromedio;
        private DataGridViewTextBoxColumn colMaxima;
        private Panel pnlCompBarra;
        private Label lblSemilla;
        private NumericUpDown nudSemilla;
        private Label lblMinutos;
        private NumericUpDown nudMinutos;
        private Button btnComparar;
        private DataGridView dgvComparacion;
        private DataGridViewTextBoxColumn colCTipo;
        private DataGridViewTextBoxColumn colFifoProm;
        private DataGridViewTextBoxColumn colFifoMax;
        private DataGridViewTextBoxColumn colPrioProm;
        private DataGridViewTextBoxColumn colPrioMax;
        private DataGridViewTextBoxColumn colDiferencia;
        private PictureBox picComparacion;
        private TabPage tabPruebas;
        private Panel pnlBarraPruebas;
        private Button btnPruebas;
        private Label lblResumen;
        private ListBox lstPruebas;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.Timer tmrSimulacion;
    }
}