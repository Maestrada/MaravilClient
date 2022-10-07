namespace MaravilClient
{
    partial class OrderList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuOrdenesDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verUsuariosDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarMiContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOrderState = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checketd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAddToQeue = new System.Windows.Forms.Button();
            this.btnShowQeue = new System.Windows.Forms.Button();
            this.btnUnMarkAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrdenesDeCompraToolStripMenuItem,
            this.administracionToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.clientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1374, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuOrdenesDeCompraToolStripMenuItem
            // 
            this.menuOrdenesDeCompraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCompraToolStripMenuItem,
            this.editarCompraToolStripMenuItem,
            this.borrarCompraToolStripMenuItem});
            this.menuOrdenesDeCompraToolStripMenuItem.Name = "menuOrdenesDeCompraToolStripMenuItem";
            this.menuOrdenesDeCompraToolStripMenuItem.Size = new System.Drawing.Size(203, 25);
            this.menuOrdenesDeCompraToolStripMenuItem.Text = "Menu Ordenes de compra";
            // 
            // agregarCompraToolStripMenuItem
            // 
            this.agregarCompraToolStripMenuItem.Name = "agregarCompraToolStripMenuItem";
            this.agregarCompraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.agregarCompraToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.agregarCompraToolStripMenuItem.Text = "Agregar Compra";
            this.agregarCompraToolStripMenuItem.Click += new System.EventHandler(this.agregarCompraToolStripMenuItem_Click);
            // 
            // editarCompraToolStripMenuItem
            // 
            this.editarCompraToolStripMenuItem.Name = "editarCompraToolStripMenuItem";
            this.editarCompraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editarCompraToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.editarCompraToolStripMenuItem.Text = "Editar Compra";
            this.editarCompraToolStripMenuItem.Click += new System.EventHandler(this.editarCompraToolStripMenuItem_Click);
            // 
            // borrarCompraToolStripMenuItem
            // 
            this.borrarCompraToolStripMenuItem.Name = "borrarCompraToolStripMenuItem";
            this.borrarCompraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.borrarCompraToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.borrarCompraToolStripMenuItem.Text = "Borrar Compra";
            this.borrarCompraToolStripMenuItem.Click += new System.EventHandler(this.borrarCompraToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verUsuariosDelSistemaToolStripMenuItem,
            this.toolStripSeparator2,
            this.cambiarMiContraseñaToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(127, 25);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // verUsuariosDelSistemaToolStripMenuItem
            // 
            this.verUsuariosDelSistemaToolStripMenuItem.Name = "verUsuariosDelSistemaToolStripMenuItem";
            this.verUsuariosDelSistemaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.verUsuariosDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.verUsuariosDelSistemaToolStripMenuItem.Text = "Ver Usuarios del Sistema";
            this.verUsuariosDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.verUsuariosDelSistemaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(300, 6);
            // 
            // cambiarMiContraseñaToolStripMenuItem
            // 
            this.cambiarMiContraseñaToolStripMenuItem.Name = "cambiarMiContraseñaToolStripMenuItem";
            this.cambiarMiContraseñaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.cambiarMiContraseñaToolStripMenuItem.Size = new System.Drawing.Size(303, 26);
            this.cambiarMiContraseñaToolStripMenuItem.Text = "Cambiar mi contraseña";
            this.cambiarMiContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarMiContraseñaToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirDelSistemaToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir del sistema";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbOrderState);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1359, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado de la compra";
            // 
            // cbOrderState
            // 
            this.cbOrderState.FormattingEnabled = true;
            this.cbOrderState.Items.AddRange(new object[] {
            "Todas",
            "Pendientes de entrega",
            "Entregadas"});
            this.cbOrderState.Location = new System.Drawing.Point(200, 41);
            this.cbOrderState.Name = "cbOrderState";
            this.cbOrderState.Size = new System.Drawing.Size(269, 29);
            this.cbOrderState.TabIndex = 0;
            this.cbOrderState.SelectedIndexChanged += new System.EventHandler(this.cbOrderState_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1359, 437);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registros";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoCompra,
            this.Cliente,
            this.Detalle,
            this.Telefono,
            this.Direccion,
            this.Referencia,
            this.Amount,
            this.checketd});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1353, 409);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // NoCompra
            // 
            this.NoCompra.HeaderText = "NoCompra";
            this.NoCompra.Name = "NoCompra";
            this.NoCompra.ReadOnly = true;
            this.NoCompra.Width = 110;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 200;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 240;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 140;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 240;
            // 
            // Referencia
            // 
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 230;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Monto";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // checketd
            // 
            this.checketd.HeaderText = "";
            this.checketd.Name = "checketd";
            this.checketd.Width = 50;
            // 
            // btnAddToQeue
            // 
            this.btnAddToQeue.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddToQeue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddToQeue.Location = new System.Drawing.Point(42, 140);
            this.btnAddToQeue.Name = "btnAddToQeue";
            this.btnAddToQeue.Size = new System.Drawing.Size(158, 50);
            this.btnAddToQeue.TabIndex = 3;
            this.btnAddToQeue.Text = "Agregar a la cola de impresion";
            this.btnAddToQeue.UseVisualStyleBackColor = false;
            this.btnAddToQeue.Click += new System.EventHandler(this.btnAddToQeue_Click);
            // 
            // btnShowQeue
            // 
            this.btnShowQeue.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnShowQeue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowQeue.Location = new System.Drawing.Point(212, 140);
            this.btnShowQeue.Name = "btnShowQeue";
            this.btnShowQeue.Size = new System.Drawing.Size(158, 50);
            this.btnShowQeue.TabIndex = 4;
            this.btnShowQeue.Text = "Ver cola de impresion";
            this.btnShowQeue.UseVisualStyleBackColor = false;
            this.btnShowQeue.Click += new System.EventHandler(this.btnShowQeue_Click);
            // 
            // btnUnMarkAll
            // 
            this.btnUnMarkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnMarkAll.ForeColor = System.Drawing.Color.Coral;
            this.btnUnMarkAll.Location = new System.Drawing.Point(1211, 146);
            this.btnUnMarkAll.Name = "btnUnMarkAll";
            this.btnUnMarkAll.Size = new System.Drawing.Size(151, 38);
            this.btnUnMarkAll.TabIndex = 6;
            this.btnUnMarkAll.Text = "Desmarcar todos";
            this.btnUnMarkAll.UseVisualStyleBackColor = true;
            this.btnUnMarkAll.Click += new System.EventHandler(this.btnUnMarkAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnCheckAll.Location = new System.Drawing.Point(1037, 146);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(151, 38);
            this.btnCheckAll.TabIndex = 5;
            this.btnCheckAll.Text = "Marcar todos";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1374, 630);
            this.Controls.Add(this.btnUnMarkAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnShowQeue);
            this.Controls.Add(this.btnAddToQeue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.MediumBlue;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderList";
            this.Text = "Maravil - Orden de Compra";
            this.Load += new System.EventHandler(this.OrderList_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuOrdenesDeCompraToolStripMenuItem;
        private ToolStripMenuItem agregarCompraToolStripMenuItem;
        private ToolStripMenuItem borrarCompraToolStripMenuItem;
        private ToolStripMenuItem editarCompraToolStripMenuItem;
        private ToolStripMenuItem administracionToolStripMenuItem;
        private ToolStripMenuItem verUsuariosDelSistemaToolStripMenuItem;
        private ToolStripMenuItem cambiarMiContraseñaToolStripMenuItem;
        private ToolStripMenuItem sistemaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cbOrderState;
        private GroupBox groupBox2;
        private Button btnAddToQeue;
        private Button btnShowQeue;
        private DataGridView dataGridView1;
        private Button btnUnMarkAll;
        private Button btnCheckAll;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private DataGridViewTextBoxColumn NoCompra;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Detalle;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Referencia;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewCheckBoxColumn checketd;
    }
}