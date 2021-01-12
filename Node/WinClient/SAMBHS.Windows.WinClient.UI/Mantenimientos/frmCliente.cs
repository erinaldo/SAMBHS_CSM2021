﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAMBHS.Common.BE;
using SAMBHS.Common.BL;
using SAMBHS.CommonWIN.BL;
using SAMBHS.Common.Resource;
using SAMBHS.Venta.BL;
using SAMBHS.Security.BL;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using SAMBHS.Cobranza.BL;
using Infragistics.Win.UltraWinTabControl;

namespace SAMBHS.Windows.WinClient.UI.Mantenimientos
{
    /// <summary>
    /// Autor: Eduardo Quiroz Cosme
    /// Fecha: 27/10/2014
    /// </summary>
    public partial class frmCliente : Form
    {
        ClienteBL _objClienteBL = new ClienteBL();
        CarteraClienteBL _objCarteraClienteBL = new CarteraClienteBL();
        SecurityBL _obSecurityBL = new SecurityBL();
        SystemParameterBL _objSystemParameterBL = new SystemParameterBL();
        DatahierarchyBL _objDatahierarchyBL = new DatahierarchyBL();
        ClienteAvalBL _objClienteAvalBL = new ClienteAvalBL();
        avalclienteDto _avalclienteDto = new avalclienteDto();
        clienteDto _clienteDto = new clienteDto();
        carteraclienteDto _carteraclienteDto = new carteraclienteDto();
        lineacreditoempresaDto _lineacreditoempresaDto = new lineacreditoempresaDto();
        string _strFilterExpression, _mode, _v_IdCliente, _modeAval;
        string _Parametro;
        bool _btnNuevo = true, _btnEliminar = true, _btnGuardar = true;
        bool _btnAgregarAval = true, _btnAvalEditar = true, _btnChoferEliminar = true;


        public frmCliente(string Parametro)
        {
            InitializeComponent();
            _Parametro = Parametro;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            using (GlobalFormColors colors = new GlobalFormColors())
            {
                panel1.BackColor = colors.FormColor;
                this.BackColor = colors.FormColor;
                Tabs.BackColor = colors.FormColor;
                //tpDatos.BackColor = colors.FormColor;
                //tpAdicionales.BackColor = colors.FormColor;
                //tpLineaCredito.BackColor = colors.FormColor;
                //tpServicios.BackColor = colors.FormColor;

            }

            OperationResult objOperationResult = new OperationResult();

            //#region CONTROL DE ACCIONES
            //var _formActions = _obSecurityBL.GetFormAction(ref objOperationResult, Globals.ClientSession.i_CurrentExecutionNodeId, Globals.ClientSession.i_SystemUserId, "frmCliente", Globals.ClientSession.i_RoleId);

            //_btnNuevo = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Add", _formActions);
            //_btnEliminar = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Delete", _formActions);
            //_btnGuardar = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Save", _formActions);

            //_btnAgregarAval = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Aval_Add", _formActions);
            //_btnAvalEditar = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Aval_Edit", _formActions);
            //_btnChoferEliminar = SAMBHS.Common.Resource.Utils.Windows.IsActionEnabled("frmCliente_Aval_Delete", _formActions);

            //btnAgregar.Enabled = _btnNuevo;
            //btnEliminar.Enabled = _btnEliminar;
            //btnGrabar.Enabled = _btnGuardar;

            //btnAgregarAval.Enabled = _btnAgregarAval;
            //btnAvalEditar.Enabled = _btnAvalEditar;
            //btnChoferEliminar.Enabled = _btnChoferEliminar;
            //#endregion

            #region Cargar combos
            //Combo País
            var ListaPaises = (_objSystemParameterBL.GetSystemParameterForComboKeyValueDto(ref objOperationResult, 112, null)).FindAll(p => p.Value3 == "-1");
            Utils.Windows.LoadUltraComboEditorList(ddlPais, "Value1", "Id", ListaPaises, DropDownListAction.Select);
            //Combo Departamento
            Utils.Windows.LoadUltraComboEditorList(ddlDepartamento, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);
            //Combo Provincia
            Utils.Windows.LoadUltraComboEditorList(ddlProvincia, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);
            //Combo Distrito
            Utils.Windows.LoadUltraComboEditorList(ddlDistrito, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboTipoPersona, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 2, null), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboGenero, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 3, null), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboGrupoCliente, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 4, null), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboZona, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 5, null), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboListaPrecios, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 47, null), DropDownListAction.Select);

            Utils.Windows.LoadUltraComboEditorList(cboMoneda, "Value1", "Id", _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 18, null), DropDownListAction.Select);

            var DobleTributacion = _objDatahierarchyBL.GetDataHierarchiesForCombo(ref objOperationResult, 146, null).ToList().OrderBy(x => x.Value2).ToList();

            Utils.Windows.LoadUltraComboEditorList(cboDobleTributacion, "Value1", "Id", DobleTributacion, DropDownListAction.Select);

            cboDobleTributacion.Value = "-1";
            #endregion

            txtFecNac.CustomFormat = "dd/MM/yyyy";
            _mode = "New";
            _modeAval = "New";
            cboGenero.Value = "-1";
            ddlPais.Value = "1";
            ddlDepartamento.Value = "1391";
            ddlProvincia.Value = "1392";
            ddlDistrito.Value = "1393";

           // Tabs.Tabs["tpDatos"].Enabled = false;
            if (_Parametro == "V") //Proveedor
            {
               
                Tabs.Controls.RemoveAt(3);
                Tabs.Controls.RemoveAt(2);
                this.Text = "Administración de Proveedor";
               
                btnAgregar.Text = "Nuevo Proveedor";
                btnEliminar.Text = "Eliminar Proveedor";
                btnGrabar.Text = "Guardar Proveedor";
            }
            else
            {
               
                Tabs.Controls.RemoveAt(4);
                btnAgregar.Text = "Nuevo Cliente";
                btnEliminar.Text = "Eliminar Cliente";
                btnGrabar.Text = "Guardar Cliente";
            }
            if (!Globals.ClientSession.EsEmisorElectronico)
                txtPassword.Visible = ulbClave.Visible = false;
            btnBuscar_Click(sender, e);
            btnActualizarDirecciones.Visible = Globals.ClientSession.i_SystemUserId == 1;
            btnDirecciones.Visible = _Parametro == "C" ? true : false;
             
        }

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNroDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
            {
                if (cboTipoDocumento.Value.ToString() != "-1" && cboTipoDocumento.Value.ToString() != "0")
                {
                    if (txtNroDocumento.TextLength != txtNroDocumento.MaxLength)
                    {
                        UltraMessageBox.Show("Nro. Documento Inválido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtApeMaterno.Clear();
                        txtApePaterno.Clear();
                        txtPrimerNombre.Clear();
                        txtSegundoNombre.Clear();
                        txtDireccion.Clear();
                        _clienteDto.v_NroDocIdentificacion = null;
                        txtNroDocumento.Focus();
                    }
                    else if (cboTipoDocumento.Value.ToString() == "6")
                    {
                        if (Utils.Windows.ValidarRuc(txtNroDocumento.Text.Trim()) == false)
                        {
                            UltraMessageBox.Show("Nro. Documento Inválido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtApeMaterno.Clear();
                            txtApePaterno.Clear();
                            txtPrimerNombre.Clear();
                            txtSegundoNombre.Clear();
                            txtDireccion.Clear();
                            _clienteDto.v_NroDocIdentificacion = null;
                            txtNroDocumento.Focus();
                        }
                    }
                }
            }
        }

        #region Cabecera
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Get the filters from the UI
            List<string> Filters = new List<string>();
            if (!string.IsNullOrEmpty(txtBuscarDoc.Text)) Filters.Add("v_NroDocIdentificacion.Contains(\"" + txtBuscarDoc.Text.Trim().ToUpper() + "\")");
            if (!string.IsNullOrEmpty(txtBuscarNombre.Text)) Filters.Add("(" + "v_PrimerNombre.Contains(\"" + txtBuscarNombre.Text.Trim().ToUpper() + "\")" +
                                                                         " || " + "v_SegundoNombre.Contains(\"" + txtBuscarNombre.Text.Trim().ToUpper() + "\")" +
                                                                         " || " + "v_ApePaterno.Contains(\"" + txtBuscarNombre.Text.Trim().ToUpper() + "\")" +
                                                                         " || " + "v_ApeMaterno.Contains(\"" + txtBuscarNombre.Text.Trim().ToUpper() + "\")" +
                                                                         " || " + "v_RazonSocial.Contains(\"" + txtBuscarNombre.Text.Trim().ToUpper() + "\")" + ")"
                                                                         );
            Filters.Add("v_FlagPantalla.Contains(\"" + _Parametro + "\")");
            _strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    _strFilterExpression = _strFilterExpression + item + " && ";
                }
                _strFilterExpression = _strFilterExpression.Substring(0, _strFilterExpression.Length - 4);
            }

            this.BindGrid();
            //tcDetalle.Controls["tpDatos"].Enabled = grdData.Rows.Count() == 0 ? false : true;

            Tabs.Tabs["tpDatos"].Enabled = grdData.Rows.Count() == 0 ? false : true;
            btnEliminar.Enabled = grdData.Rows.Count() == 0 ? false : _btnEliminar;
            if (grdData.Rows.Count() == 0)
            {
                LimpiaDetalle();
                if (_Parametro == "C")
                {
                    Tabs.Tabs["tpAdicionales"].Enabled = false;
                }; 
            }
            else
            {
                if (_Parametro == "C")
                {
                    Tabs.Tabs["tpAdicionales"].Enabled = true;
                }; 
            }
        }

        private void BindGrid()
        {
            var objData = GetData("v_PrimerNombre ASC", _strFilterExpression);

            grdData.DataSource = objData;
            lblContadorFilas.Text = string.Format("Se encontraron {0} registros.", objData.Count);
        }

        private List<clienteshortDto> GetData(string pstrSortExpression, string pstrFilterExpression)
        {
            OperationResult objOperationResult = new OperationResult();
            var _objData = _objClienteBL.ObtenerListadoCliente(ref objOperationResult, pstrSortExpression, pstrFilterExpression);

            if (objOperationResult.Success != 1)
            {
                UltraMessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _objData;
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPais.Enabled) ddlPais.Value = "1";// Select Peru)
            ddlPais.Enabled = (cboTipoPersona.Value.ToString().Equals("3"));

            OperationResult objOperationResult = new OperationResult();
            if (cboTipoPersona.Value.ToString() != "-1")
            {
                Utils.Windows.LoadUltraComboEditorList(cboTipoDocumento, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboKeyValueDto(ref objOperationResult, 150, null), DropDownListAction.Select);

                if (cboTipoPersona.Value.ToString() == "2")
                {

                    cboTipoDocumento.Value = "6";
                    cboTipoDocumento.Enabled = false;
                    lblNombreRS.Text = "Razón Social:";
                    txtSegundoNombre.Enabled = false;
                    txtApeMaterno.Enabled = false;
                    txtApePaterno.Enabled = false;
                    txtPrimerNombre.MaxLength = 120;

                }
                else
                {
                    cboTipoDocumento.Value = "-1";
                    cboTipoDocumento.Enabled = true;
                    lblNombreRS.Text = "Primer Nombre:";
                    txtSegundoNombre.Enabled = true;
                    txtApeMaterno.Enabled = true;
                    txtApePaterno.Enabled = true;
                    txtPrimerNombre.MaxLength = 30;
                }
            }
            else
            {
                Utils.Windows.LoadUltraComboEditorList(cboTipoDocumento, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboKeyValueDto(ref objOperationResult, -1, null), DropDownListAction.Select);
            }
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento.Value != "-1")
            {
                var x = (KeyValueDTO)cboTipoDocumento.SelectedItem.ListObject;
                if (x == null) return;
                txtNroDocumento.MaxLength = int.Parse(x.Value2);
                txtNroDocumento.Focus();
                btnConsultaInternet.Enabled = cboTipoDocumento.Value.ToString() == "6" || cboTipoDocumento.Value.ToString() == "1" ? true : false;
            }
        }

        private void grdData_AfterRowActivate(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            string Idcliente = "";
            //_mode = "Edit";
            if (grdData.ActiveRow != null)
            {
                using (new LoadingClass.PleaseWait(this.Location, "Por favor espere..."))
                {
                    _mode = "Edit";
                    Idcliente = grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdCliente"].Value.ToString();
                    _v_IdCliente = Idcliente;
                    _clienteDto = new clienteDto();
                    _clienteDto = _objClienteBL.ObtenerCliente(ref objOperationResult, Idcliente);
                    _carteraclienteDto = _objCarteraClienteBL.ObtenerNombreVendedor(ref objOperationResult, Idcliente);
                    txtCodigoAnexo.Text = _clienteDto.v_CodCliente;
                    cboTipoPersona.Value = _clienteDto.i_IdTipoPersona.ToString();
                    if (_clienteDto.i_IdTipoPersona.ToString() == "2" || _clienteDto.i_IdTipoPersona.ToString() == "3")
                    {
                        cboTipoDocumento.Value = "6";
                        cboTipoDocumento.Enabled = false;
                        lblNombreRS.Text = "Razón Social:";
                        txtSegundoNombre.Enabled = false;
                        txtApeMaterno.Enabled = false;
                        txtApePaterno.Enabled = false;
                        txtPrimerNombre.Text =
                            (_clienteDto.v_ApePaterno + " " + _clienteDto.v_ApeMaterno + " " +
                             _clienteDto.v_PrimerNombre + " " + _clienteDto.v_SegundoNombre + " " +
                             _clienteDto.v_RazonSocial).Trim();
                        txtPrimerNombre.MaxLength = 120;
                    }
                    else
                    {
                        cboTipoDocumento.Value = "-1";
                        cboTipoDocumento.Enabled = true;
                        lblNombreRS.Text = "Primer Nombre:";
                        txtSegundoNombre.Enabled = true;
                        txtApeMaterno.Enabled = true;
                        txtApePaterno.Enabled = true;
                        txtPrimerNombre.Text = _clienteDto.v_PrimerNombre;
                        txtPrimerNombre.MaxLength = 30;
                    }
                    cboTipoDocumento.Value = _clienteDto.i_IdTipoIdentificacion.ToString();
                    txtNroDocumento.Text = _clienteDto.v_NroDocIdentificacion;
                    txtSegundoNombre.Text = _clienteDto.v_SegundoNombre;
                    txtApeMaterno.Text = _clienteDto.v_ApeMaterno;
                    txtApePaterno.Text = _clienteDto.v_ApePaterno;
                    cboGenero.Value = _clienteDto.i_IdSexo.ToString();
                    txtDireccion.Text = _clienteDto.v_DirecPrincipal;
                    txtDireccionSec.Text = _clienteDto.v_DirecSecundaria;
                    ddlPais.Value = _clienteDto.i_IdPais.ToString();
                    ddlDepartamento.Value = _clienteDto.i_IdDepartamento.ToString();
                    ddlProvincia.Value = _clienteDto.i_IdProvincia.ToString();
                    ddlDistrito.Value = _clienteDto.i_IdDistrito.ToString();
                    txtTelefono.Text = _clienteDto.v_TelefonoFijo;
                    txtFax.Text = _clienteDto.v_TelefonoFax;
                    txtCelular.Text = _clienteDto.v_TelefonoMovil;
                    txtEmail.Text = _clienteDto.v_Correo;
                    txtContacto.Text = _clienteDto.v_NombreContacto;
                    txtWeb.Text = _clienteDto.v_PaginaWeb;
                    chkActivo.Checked = _clienteDto.i_Activo == 1 ? true : false;
                    chkExtrangero.Checked = _clienteDto.i_Nacionalidad == 1 ? true : false;
                    txtFecNac.Text = _clienteDto.t_FechaNacimiento.ToString();
                    txtPassword.Text = new string(' ', 6);
                    txtPassword.Tag = _clienteDto.v_Password;
                    txtAlias.Text = _clienteDto.v_Alias;
                    txtClienteNroCuentaDetraccion.Text = _clienteDto.v_NroCuentaDetraccion;
                    if (_clienteDto.i_EsPrestadorServicios == null || _clienteDto.i_EsPrestadorServicios == 0)
                    {
                        rbtnNoPrestador.Checked = true;
                    }
                    else
                    {
                        rbtnSiPrestador.Checked = true;
                    }
                    if (_Parametro == "C")
                    {
                        //Tabs.Tabs["tpAdicionales"].Enabled = false;
                        //Tabs.Tabs["tpAdicionales"].Enabled = true;            //tcDetalle.Controls["tpAdicionales"].Enabled = true;

                    }
                    cboGrupoCliente.Value = _clienteDto.i_IdGrupoCliente.ToString();
                    cboZona.Value = _clienteDto.i_IdZona.ToString();
                    lblNombreVendedor.Text = _carteraclienteDto == null ? String.Empty : _carteraclienteDto.NombreVendedor;
                    txtProveedorServicio.Text = _clienteDto.v_Servicio;
                    txtProveedorNroCuentaDetraccion.Text = _clienteDto.v_NroCuentaDetraccion;
                    chkProveedorAfectoT.Checked = _clienteDto.i_AfectoDetraccion != 0;
                    cboListaPrecios.Value = _clienteDto.i_IdListaPrecios.ToString();
                    txtNroDocumento.Enabled = false;
                    cboDobleTributacion.Value = _clienteDto.i_IdConvenioDobleTributacion ==null ?"-1" : _clienteDto.i_IdConvenioDobleTributacion.ToString(); 
                    CargarLineaCredito(_clienteDto.v_IdCliente);
                    grdData.Focus();
                    LimpiarAvalDatos();
                    ActivaDesactivaBotonesAval();
                    grdAvales.DataSource = _objClienteAvalBL.ObtenerListadoAvalCliente(ref objOperationResult, null, null, Idcliente);
                    lblAvalContadorFilas.Text = string.Format("Se encontraron {0} registros.", grdAvales.Rows.Count());
                }
            }
        }

        private void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (ddlDepartamento.Value == null) return;

            if ((string)ddlDepartamento.Value == "-1")
            {
                Utils.Windows.LoadUltraComboEditorList(ddlProvincia, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);
            }
            else
            {
                Utils.Windows.LoadUltraComboEditorList(ddlProvincia, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, int.Parse(ddlDepartamento.Value.ToString()), 112, ""), DropDownListAction.Select);
            }
            ddlProvincia.Value = "-1";
        }

        private void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (ddlProvincia.Value == null) return;

            if ((string)ddlProvincia.Value == "-1")
            {
                Utils.Windows.LoadUltraComboEditorList(ddlDistrito, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);
            }
            else
            {
                Utils.Windows.LoadUltraComboEditorList(ddlDistrito, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, int.Parse(ddlProvincia.Value.ToString()), 112, ""), DropDownListAction.Select);      
            }
            ddlDistrito.Value = "-1";
        }

        private void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (ddlPais.Value == null) return;
            //si el combo esta en seleccione tengo que reiniciar el combo departamento
            if ((string)ddlPais.Value == "-1")
            {
                Utils.Windows.LoadUltraComboEditorList(ddlDepartamento, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, null, 112, ""), DropDownListAction.Select);
            }
            else
            {
                Utils.Windows.LoadUltraComboEditorList(ddlDepartamento, "Value1", "Id", _objSystemParameterBL.GetSystemParameterForComboUbigeoKeyValueDto(ref objOperationResult, int.Parse(ddlPais.Value.ToString()), 112, ""), DropDownListAction.Select);
            }
            ddlDepartamento.Value = "-1";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiaDetalle();
            // tcDetalle.Controls["tpDatos"].Enabled = true;
            Tabs.Tabs["tpDatos"].Enabled = true;
            _mode = "New";
           // if (_Parametro == "C") Tabs.Tabs["tpAdicionales"].Enabled = false;         //tcDetalle.Controls["tpAdicionales"].Enabled = false;
            txtCodigoAnexo.Focus(); 
            ddlPais.Value = "1";
            ddlDepartamento.Value = "1391";
            ddlProvincia.Value = "1392";
            ddlDistrito.Value = "1393";
            cboListaPrecios.Value = "1";
            _clienteDto = new clienteDto(); //Agregado Julissa
            txtNroDocumento.Enabled = true;
            SecuentialBL objSecuentialBL = new SecuentialBL();
            List<string> ClientSession = Globals.ClientSession.GetAsList();
            int intNodeId = int.Parse(ClientSession[0]);
            int SecuentialId = objSecuentialBL.GetNextSecuentialId_Client(intNodeId, 14);
            txtCodigoAnexo.Text = (SecuentialId + 1).ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            //V Proveedor
           bool existenciaClienteProveedor =  _objClienteBL.ExistenciaProveedorDiversosProcesos (grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdCliente"].Value.ToString());

            if (!existenciaClienteProveedor)
            {

                DialogResult Result = UltraMessageBox.Show("¿Está seguro de eliminar este registro?:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    _objClienteBL.Eliminarcliente(ref objOperationResult, grdData.Rows[grdData.ActiveRow.Index].Cells["v_IdCliente"].Value.ToString(), Globals.ClientSession.GetAsList());
                    btnBuscar_Click(sender, e);
                    LimpiaDetalle();
                }
            }
            else
            {
                UltraMessageBox.Show(
                    _Parametro == "V"
                        ? "Proveedor está contenido en otros procesos ,no se puede Eliminar"
                        : "Cliente está contenido en otros procesos ,no se puede Eliminar", "Sistema");
            }
        }

        private void grdData_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new System.Drawing.Point(e.X, e.Y);
            Infragistics.Win.UIElement uiElement = ((Infragistics.Win.UltraWinGrid.UltraGridBase)sender).DisplayLayout.UIElement.ElementFromPoint(point);

            if (uiElement == null || uiElement.Parent == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)uiElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (row == null)
            {
                btnEliminar.Enabled = false;
            }
            else
            {

                btnEliminar.Enabled = _btnEliminar;
            }
        }
        #endregion

        #region Detalle
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (uvDatos.Validate(true, false).IsValid)
            {
               // ComprobarExistenciaPredeterminada
                if ((txtNroDocumento.Text.Trim() == "" || txtNroDocumento.Text.Trim() == null) && cboTipoPersona.Value.ToString() != "3" && cboTipoDocumento.Value.ToString() != "0")
                {
                    UltraMessageBox.Show("Por favor ingrese Número Documento Válido", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }

                if (txtCodigoAnexo.Text.Trim() == "")
                {
                    UltraMessageBox.Show("Por favor ingrese un Código.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoAnexo.Focus();
                    return;
                }
                if (txtNroDocumento.Text.Trim() == "" && cboTipoPersona.Value.ToString() != "3" && cboTipoDocumento.Value.ToString() != "0")
                {
                    UltraMessageBox.Show("Por favor ingrese un Nro. Documento.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNroDocumento.Focus();
                    return;
                }
                if (txtPrimerNombre.Text.Trim() == "")
                {
                    UltraMessageBox.Show("Por favor ingrese un Nombre o Razón Social.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrimerNombre.Focus();
                    return;
                }
                if (txtDireccion.Text.Trim() == "")
                {
                    UltraMessageBox.Show("Por favor ingrese una Dirección.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                    return;
                }

                if (_objClienteBL.ObtenerClienteCodigo(ref objOperationResult, txtCodigoAnexo.Text, _clienteDto.v_IdCliente, _Parametro) != null)
                {
                    UltraMessageBox.Show("Este Código Anexo ya ha sido registrado ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboTipoPersona.Value.ToString() != "3" && cboTipoDocumento.Value.ToString() != "0")
                {
                    if (_objClienteBL.ObtenerClienteDocumentoIdentificacion(ref objOperationResult, txtNroDocumento.Text, _clienteDto.v_IdCliente, _Parametro) != null)
                    {
                        UltraMessageBox.Show("Este Nro. Documento ya ha sido registrado ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                if (cboTipoDocumento.Value.ToString() == "6") // Si es Ruc-->Busco si que no se haya registrado con Dni
                {

                    var objClienteConsulta = _objClienteBL.ObtenerClienteDocumentoIdentificacion(ref objOperationResult, txtNroDocumento.Text.Substring(2, 8), _clienteDto.v_IdCliente, "V");

                    if (objClienteConsulta != null)
                    {
                        UltraMessageBox.Show("Este Nro. Documento ya ha sido registrado con :" + objClienteConsulta.v_NroDocIdentificacion, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                }
                else if (cboTipoDocumento.Value.ToString() == "1") // Si es Dni ,verifico que no se haya registrado con su Ruc
                {
                    if (cboTipoPersona.Value.ToString() == "1") //Natural
                    {
                        string Ruc = "10" + txtNroDocumento.Text + "X";
                        Ruc = "10" + txtNroDocumento.Text + CalcularUltimoDigitoRuc(Ruc);
                        var objClienteConsulta = _objClienteBL.ObtenerClienteDocumentoIdentificacion(ref objOperationResult, Ruc, _clienteDto.v_IdCliente, "V");

                        if (objClienteConsulta != null)
                        {
                            UltraMessageBox.Show("Este Nro. Documento ya ha sido registrado con :" + objClienteConsulta.v_NroDocIdentificacion, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else if (cboTipoPersona.Value.ToString() == "2") //Juridica
                    {
                        string Ruc = "20" + txtNroDocumento.Text + "X";
                        Ruc = "20" + txtNroDocumento.Text + CalcularUltimoDigitoRuc(Ruc);
                        var objClienteConsulta = _objClienteBL.ObtenerClienteDocumentoIdentificacion(ref objOperationResult, Ruc, _clienteDto.v_IdCliente, "V");

                        if (objClienteConsulta != null)
                        {
                            UltraMessageBox.Show("Este Nro. Documento ya ha sido registrado con :" + objClienteConsulta.v_NroDocIdentificacion, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                }
                if (_Parametro == "V" && rbtnSiPrestador.Checked)
                {

                    if (uvServicios.Validate(true, false).IsValid)
                    {
                    }
                    else
                    {
                        UltraTabsCollection tabs = Tabs.Tabs;
                        Tabs.SelectedTab = tabs["tpServicios"];
                        Tabs.ActiveTab = tabs["tpServicios"];
                        Tabs.Focus();
                        Tabs.EndUpdate();

                        if (uvServicios.Validate(true, false).IsValid)
                        {
                        }
                        else
                        {
                            return;
                        }
                    }


                }
                if (_mode == "New")
                {
                    _clienteDto = new clienteDto();
                    _clienteDto.v_CodCliente = txtCodigoAnexo.Text.Trim();
                    _clienteDto.i_IdTipoPersona = int.Parse(cboTipoPersona.Value.ToString());
                    _clienteDto.i_IdTipoIdentificacion = int.Parse(cboTipoDocumento.Value.ToString());
                    if (cboTipoPersona.Value.ToString() != "2" && cboTipoPersona.Value.ToString() != "3")
                    {
                        _clienteDto.v_PrimerNombre = txtPrimerNombre.Text.Trim();
                        _clienteDto.v_SegundoNombre = txtSegundoNombre.Text.Trim();
                        _clienteDto.v_ApePaterno = txtApePaterno.Text.Trim();
                        _clienteDto.v_ApeMaterno = txtApeMaterno.Text.Trim();
                        _clienteDto.v_RazonSocial = string.Empty;
                    }
                    else
                    {
                        _clienteDto.v_PrimerNombre = string.Empty;
                        _clienteDto.v_SegundoNombre = string.Empty;
                        _clienteDto.v_ApePaterno = string.Empty;
                        _clienteDto.v_ApeMaterno = string.Empty;
                        _clienteDto.v_RazonSocial = txtPrimerNombre.Text.Trim();
                    }
                    _clienteDto.i_UsaLineaCredito = chkLineaCredito.Checked ? 1 : 0;
                    _clienteDto.v_NombreContacto = txtContacto.Text.Trim();
                    _clienteDto.v_NroDocIdentificacion = txtNroDocumento.Text.Trim();
                    _clienteDto.v_DirecPrincipal = txtDireccion.Text;
                    _clienteDto.v_DirecPrincipal = _clienteDto.v_DirecPrincipal.Length <= 200 ? _clienteDto.v_DirecPrincipal : _clienteDto.v_DirecPrincipal.Substring(0, 200);
                    _clienteDto.v_DirecSecundaria = txtDireccionSec.Text.Trim();
                    _clienteDto.v_Correo = txtEmail.Text.Trim();
                    _clienteDto.v_TelefonoFax = txtFax.Text.Trim();
                    _clienteDto.v_TelefonoFijo = txtTelefono.Text.Trim();
                    _clienteDto.v_TelefonoMovil = txtCelular.Text.Trim();
                    _clienteDto.i_IdPais = int.Parse(ddlPais.Value.ToString());
                    _clienteDto.i_IdDistrito = int.Parse(ddlDistrito.Value.ToString());
                    _clienteDto.i_IdDepartamento = int.Parse(ddlDepartamento.Value.ToString());
                    _clienteDto.i_IdListaPrecios = (_Parametro == "V") ? -1 : int.Parse(cboListaPrecios.Value.ToString());
                    _clienteDto.i_IdProvincia = int.Parse(ddlProvincia.Value.ToString());
                    if (txtFecNac.Checked == true) { _clienteDto.t_FechaNacimiento = txtFecNac.Value; } else { _clienteDto.t_FechaNacimiento = null; }
                    _clienteDto.i_Nacionalidad = chkExtrangero.Checked == true ? 1 : 0;
                    _clienteDto.i_Activo = chkActivo.Checked == true ? 1 : 0;
                    _clienteDto.i_IdSexo = int.Parse(cboGenero.Value.ToString());
                    if (cboZona.Value != null && cboGrupoCliente.Value != null)
                    {
                        _clienteDto.i_IdGrupoCliente = int.Parse(cboGrupoCliente.Value.ToString());
                        _clienteDto.i_IdZona = int.Parse(cboZona.Value.ToString());
                    }
                    _clienteDto.v_FlagPantalla = _Parametro;

                    _clienteDto.v_NroCuentaDetraccion = _Parametro == "V" ? txtProveedorNroCuentaDetraccion.Text : txtClienteNroCuentaDetraccion.Text;
                    _clienteDto.i_AfectoDetraccion = chkProveedorAfectoT.Checked == true ? 1 : 0;


                    _lineacreditoempresaDto = new lineacreditoempresaDto();
                    _lineacreditoempresaDto.d_Acuenta = !string.IsNullOrEmpty(txtAcuenta.Text.Trim()) ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtAcuenta.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.d_Credito = !string.IsNullOrEmpty(txtCredito.Text.Trim()) ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtCredito.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.d_Saldo = !string.IsNullOrEmpty(txtSaldo.Text.Trim()) ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtSaldo.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.i_IdMoneda = cboMoneda.Value == null ? -1 : int.Parse(cboMoneda.Value.ToString());

                    _clienteDto.i_EsPrestadorServicios = rbtnSiPrestador.Checked ? 1 : 0;
                    _clienteDto.v_Servicio = txtProveedorServicio.Text;
                    _clienteDto.i_IdConvenioDobleTributacion = int.Parse(cboDobleTributacion.Value.ToString());
                    _clienteDto.v_Alias = txtAlias.Text.Trim();
                    if (txtPassword.Visible && !string.IsNullOrWhiteSpace(txtPassword.Text))
                        _clienteDto.v_Password = Utils.Encrypt(txtPassword.Text);
                    else
                        _clienteDto.v_Password = txtPassword.Tag as string;
                    // Save the data
                    _objClienteBL.InsertarCliente(ref objOperationResult, _clienteDto, Globals.ClientSession.GetAsList(), _lineacreditoempresaDto, null, null, null, null, null);
                  //  if (_Parametro == "C") Tabs.Tabs["tpAdicionales"].Enabled = true;            //tcDetalle.Controls["tpAdicionales"].Enabled = true;
                }
                else if (_mode == "Edit")
                {
                    _clienteDto.v_CodCliente = txtCodigoAnexo.Text.Trim();
                    _clienteDto.i_IdTipoPersona = int.Parse(cboTipoPersona.Value.ToString());
                    _clienteDto.i_IdTipoIdentificacion = int.Parse(cboTipoDocumento.Value.ToString());
                    if (cboTipoPersona.Value.ToString() != "2" && cboTipoPersona.Value.ToString() != "3")
                    {
                        _clienteDto.v_PrimerNombre = txtPrimerNombre.Text.Trim();
                        _clienteDto.v_SegundoNombre = txtSegundoNombre.Text.Trim();
                        _clienteDto.v_ApePaterno = txtApePaterno.Text.Trim();
                        _clienteDto.v_ApeMaterno = txtApeMaterno.Text.Trim();
                        _clienteDto.v_RazonSocial = string.Empty;
                    }
                    else
                    {
                        _clienteDto.v_PrimerNombre = string.Empty;
                        _clienteDto.v_SegundoNombre = string.Empty;
                        _clienteDto.v_ApePaterno = string.Empty;
                        _clienteDto.v_ApeMaterno = string.Empty;
                        _clienteDto.v_RazonSocial = txtPrimerNombre.Text.Trim();
                    }
                    _clienteDto.i_UsaLineaCredito = chkLineaCredito.Checked ? 1 : 0;
                    _clienteDto.v_NombreContacto = txtContacto.Text.Trim();
                    _clienteDto.v_NroDocIdentificacion = txtNroDocumento.Text.Trim();
                    _clienteDto.v_DirecPrincipal = txtDireccion.Text;
                    _clienteDto.v_DirecPrincipal = _clienteDto.v_DirecPrincipal.Length <= 200 ? _clienteDto.v_DirecPrincipal : _clienteDto.v_DirecPrincipal.Substring(0, 200);
                    _clienteDto.v_DirecSecundaria = txtDireccionSec.Text.Trim();
                    _clienteDto.v_Correo = txtEmail.Text.Trim();
                    _clienteDto.v_TelefonoFax = txtFax.Text.Trim();
                    _clienteDto.v_TelefonoFijo = txtTelefono.Text.Trim();
                    _clienteDto.i_IdListaPrecios = (_Parametro == "V") ? -1 : int.Parse(cboListaPrecios.Value.ToString());
                    //_clienteDto.i_IdListaPrecios = int.Parse(cboListaPrecios.Value.ToString());
                    _clienteDto.v_TelefonoMovil = txtCelular.Text.Trim();
                    _clienteDto.i_IdPais = int.Parse(ddlPais.Value.ToString());
                    _clienteDto.i_IdDistrito = int.Parse(ddlDistrito.Value.ToString());
                    _clienteDto.i_IdDepartamento = int.Parse(ddlDepartamento.Value.ToString());
                    _clienteDto.i_IdProvincia = int.Parse(ddlProvincia.Value.ToString());
                    if (txtFecNac.Checked) { _clienteDto.t_FechaNacimiento = txtFecNac.Value; } else { _clienteDto.t_FechaNacimiento = null; }
                    _clienteDto.i_Nacionalidad = chkExtrangero.Checked ? 1 : 0;
                    _clienteDto.i_Activo = chkActivo.Checked ? 1 : 0;
                    _clienteDto.i_IdSexo = int.Parse(cboGenero.Value.ToString());
                    _clienteDto.v_Alias = txtAlias.Text.Trim();
                    if (cboZona.Value != null && cboGrupoCliente.Value != null)
                    {
                        _clienteDto.i_IdGrupoCliente = int.Parse(cboGrupoCliente.Value.ToString());
                        _clienteDto.i_IdZona = int.Parse(cboZona.Value.ToString());
                    }
                    _clienteDto.v_FlagPantalla = _Parametro;


                    //_clienteDto.v_NroCuentaDetraccion = txtProveedorNroCuentaDetraccion.Text;
                    _clienteDto.v_NroCuentaDetraccion = _Parametro == "V" ? txtProveedorNroCuentaDetraccion.Text : txtClienteNroCuentaDetraccion.Text;
                    _clienteDto.i_AfectoDetraccion = chkProveedorAfectoT.Checked == true ? 1 : 0;

                    _lineacreditoempresaDto.d_Acuenta = txtAcuenta.Value != null ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtAcuenta.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.d_Credito = txtCredito.Value != null ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtCredito.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.d_Saldo = txtSaldo.Value != null ? Utils.Windows.DevuelveValorRedondeado(decimal.Parse(txtSaldo.Value.ToString()), 2) : 0;
                    _lineacreditoempresaDto.i_IdMoneda = cboMoneda.Value == null ? -1 : int.Parse(cboMoneda.Value.ToString());


                    _clienteDto.i_EsPrestadorServicios = rbtnSiPrestador.Checked ? 1 : 0;
                    _clienteDto.v_Servicio = txtProveedorServicio.Text;
                    _clienteDto.i_IdConvenioDobleTributacion = int.Parse(cboDobleTributacion.Value.ToString());
                    if (txtPassword.Visible && !string.IsNullOrWhiteSpace(txtPassword.Text))
                        _clienteDto.v_Password = Utils.Encrypt(txtPassword.Text);
                    else
                        _clienteDto.v_Password = txtPassword.Tag as string;
                    // Save the data
                    _objClienteBL.Actualizarcliente(ref objOperationResult, _clienteDto, Globals.ClientSession.GetAsList(), _lineacreditoempresaDto, null, null, null, null, null, null, null, null, null, null, null, null, null);
                }
                //// Analizar el resultado de la operación
                if (objOperationResult.Success == 1)  // Operación sin error
                {
                    btnBuscar_Click(sender, e);
                    MantenerSeleccion(_clienteDto.v_IdCliente);
                    UltraMessageBox.Show("El registro se ha guardado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // Operación con error
                {
                    UltraMessageBox.Show(Constants.GenericErrorMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregarAval_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            if (uvAval.Validate(true, false).IsValid)
            {
                if (txtAvalApeNombres.Text.Trim() == "" | txtAvalDireccion.Text.Trim() == "" | txtAvalLocalidad.Text.Trim() == "" | txtAvalNroDocumento.Text.Trim() == "" | txtAvalTelefono.Text.Trim() == "")
                {
                    UltraMessageBox.Show("Porfavor ingrese todos los campos antes de guardar", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (_modeAval == "New")
                {
                    _avalclienteDto = new avalclienteDto();
                    _avalclienteDto.v_Direccion = txtAvalDireccion.Text.Trim();
                    _avalclienteDto.v_Localidad = txtAvalLocalidad.Text.Trim();
                    _avalclienteDto.v_Nombres = txtAvalApeNombres.Text.Trim();
                    _avalclienteDto.v_NroDocIdentificacion = txtAvalNroDocumento.Text.Trim();
                    _avalclienteDto.v_Telefono = txtAvalTelefono.Text.Trim();
                    _avalclienteDto.v_IdCliente = _v_IdCliente;
                    // Save the data
                    _objClienteAvalBL.InsertarAvalCliente(ref objOperationResult, _avalclienteDto, Globals.ClientSession.GetAsList());

                }
                else if (_modeAval == "Edit")
                {
                    _avalclienteDto.v_Direccion = txtAvalDireccion.Text.Trim();
                    _avalclienteDto.v_Localidad = txtAvalLocalidad.Text.Trim();
                    _avalclienteDto.v_Nombres = txtAvalApeNombres.Text.Trim();
                    _avalclienteDto.v_NroDocIdentificacion = txtAvalNroDocumento.Text.Trim();
                    _avalclienteDto.v_Telefono = txtAvalTelefono.Text.Trim();
                    _avalclienteDto.v_IdCliente = _v_IdCliente;
                    // Save the data
                    _objClienteAvalBL.ActualizarAvalCliente(ref objOperationResult, _avalclienteDto, Globals.ClientSession.GetAsList());
                }
                // Analizar el resultado de la operación
                if (objOperationResult.Success == 1)  // Operación sin error
                {
                    objOperationResult = new OperationResult();
                    grdAvales.DataSource = _objClienteAvalBL.ObtenerListadoAvalCliente(ref objOperationResult, null, null, _v_IdCliente);
                    lblAvalContadorFilas.Text = string.Format("Se encontraron {0} registros.", grdAvales.Rows.Count());
                    ActivaDesactivaBotonesAval();
                    MantenerSeleccionAval(_avalclienteDto.v_NroDocIdentificacion);
                    LimpiarAvalDatos();
                    _modeAval = "New";
                }
                else  // Operación con error
                {
                    UltraMessageBox.Show(Constants.GenericErrorMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChoferEditar_Click(object sender, EventArgs e)
        {
            _modeAval = "Edit";
            if (!grdAvales.Rows.Any()) return;
            OperationResult objOperationResult = new OperationResult();
            _avalclienteDto = new avalclienteDto();
            _avalclienteDto = _objClienteAvalBL.ObtenerAvalCliente(ref objOperationResult, grdAvales.Rows[grdAvales.ActiveRow.Index].Cells["v_IdAvalCliente"].Value.ToString());
            txtAvalApeNombres.Text = _avalclienteDto.v_Nombres;
            txtAvalDireccion.Text = _avalclienteDto.v_Direccion;
            txtAvalLocalidad.Text = _avalclienteDto.v_Localidad;
            txtAvalNroDocumento.Text = _avalclienteDto.v_NroDocIdentificacion;
            txtAvalTelefono.Text = _avalclienteDto.v_Telefono;
        }

        private void btnChoferEliminar_Click(object sender, EventArgs e)
        {
            if (grdAvales.Rows.Count() == 0) return;
            OperationResult objOperationResult = new OperationResult();
            DialogResult Result = UltraMessageBox.Show("¿Está seguro de eliminar este registro?:" + Environment.NewLine + objOperationResult.ExceptionMessage, "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                _objClienteAvalBL.EliminarAvalCliente(ref objOperationResult, grdAvales.Rows[grdAvales.ActiveRow.Index].Cells["v_IdAvalCliente"].Value.ToString(), Globals.ClientSession.GetAsList());
                grdAvales.DataSource = _objClienteAvalBL.ObtenerListadoAvalCliente(ref objOperationResult, null, null, _v_IdCliente);
                lblAvalContadorFilas.Text = string.Format("Se encontraron {0} registros.", grdAvales.Rows.Count());
                ActivaDesactivaBotonesAval();
                LimpiaDetalle();
            }
        }

        private void btnConsultaInternet_Click(object sender, EventArgs e)
        {
            string nroDoc = this.txtNroDocumento.Text.Trim();
            if (cboTipoDocumento.Value.ToString() == "6")//evaluar
            {
                if (nroDoc.Length != txtNroDocumento.MaxLength)
                {
                    UltraMessageBox.Show("El RUC Ingresado es incorrecto", "Error!");
                    txtApeMaterno.Clear();
                    txtApePaterno.Clear();
                    txtPrimerNombre.Clear();
                    txtSegundoNombre.Clear();
                    txtDireccion.Clear();
                    _clienteDto.v_NroDocIdentificacion = null;
                    return;
                }
                else
                {
                    if (Utils.Windows.ValidarRuc(nroDoc) != true)
                    {
                        UltraMessageBox.Show("El RUC Ingresado es incorrecto", "Error!");
                        txtApeMaterno.Clear();
                        txtApePaterno.Clear();
                        txtPrimerNombre.Clear();
                        txtSegundoNombre.Clear();
                        txtDireccion.Clear();
                        _clienteDto.v_NroDocIdentificacion = null;
                        txtCodigoAnexo.Clear();
                        return;
                    }
                }

                string[] _Contribuyente = new string[10];

                #region OLD
                //frmCustomerCapchaSUNAT frm = new frmCustomerCapchaSUNAT(nroDoc);
                //frm.ShowDialog();
                //if (frm.ConectadoRecibido == true)
                //{
                //    _Contribuyente = frm.DatosContribuyente;

                //    if (txtNroDocumento.Text.StartsWith("1") && cboTipoPersona.Value.ToString() == "1")
                //    {
                //        string[] Cadena = _Contribuyente[0].ToUpper().Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                //        if (Cadena.GetUpperBound(0) == 1)
                //        {
                //            txtApePaterno.Text = Cadena[0];
                //            txtApeMaterno.Text = Cadena[1];
                //            txtPrimerNombre.Text = Cadena[Cadena.Length - 1];
                //            txtSegundoNombre.Text = string.Empty;
                //        }

                //        if (Cadena.GetUpperBound(0) == 2)
                //        {
                //            txtApePaterno.Text = Cadena[0];
                //            txtApeMaterno.Text = Cadena[1];
                //            txtPrimerNombre.Text = Cadena[Cadena.Length - 1];
                //            txtSegundoNombre.Text = string.Empty;
                //        }

                //        if (Cadena.GetUpperBound(0) >= 3)
                //        {
                //            txtApePaterno.Text = Cadena[0];
                //            txtApeMaterno.Text = Cadena[1];
                //            txtPrimerNombre.Text = Cadena[Cadena.Length - 2];
                //            txtSegundoNombre.Text = Cadena[Cadena.Length - 1];
                //        }
                //    }
                //    else
                //    {
                //        txtPrimerNombre.Text = _Contribuyente[0].ToUpper().Trim();
                //        txtSegundoNombre.Text = string.Empty;
                //        txtApePaterno.Text = string.Empty;
                //        txtApeMaterno.Text = string.Empty;
                //    }
                //    txtDireccion.Text = Regex.Replace(_Contribuyente[5], @"[ ]+", " ");
                //    var resultUbigueo = Utils.Ubigeo.GetUbigueo(txtDireccion.Text);
                //    if (resultUbigueo != null)
                //    {
                //        ddlDepartamento.Value = resultUbigueo[0].Key;
                //        ddlProvincia.Value = resultUbigueo[1].Key;
                //        ddlDistrito.Value = resultUbigueo[2].Key;
                //    }
                //    txtTelefono.Text = _Contribuyente[6];
                //}
                

                #endregion

                ObtenerDatosRUC(nroDoc);

            }

            if (cboTipoDocumento.Value.ToString() == "1")
            {
                if (nroDoc.Length != txtNroDocumento.MaxLength)
                {
                    UltraMessageBox.Show("El DNI Ingresado es incorrecto", "Error!");
                    return;
                }
                string[] _Persona = new string[3];

                #region OLD
                //frmCustomerCapchaRENIEC frm = new frmCustomerCapchaRENIEC(nroDoc);
                //frm.ShowDialog();
                //if (frm.ConectadoRecibido == true)
                //{
                //    _Persona = frm.DatosPersona;
                //    if (_Persona != null)
                //    {
                //        string[] cadena = (_Persona[0] + " " + _Persona[1] + " " + _Persona[2]).ToUpper().Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                //        if (cadena.GetUpperBound(0) == 1)
                //        {
                //            txtApePaterno.Text = cadena[0];
                //            txtApeMaterno.Text = cadena[1];
                //            txtPrimerNombre.Text = cadena[cadena.Length - 1];
                //            txtSegundoNombre.Text = string.Empty;
                //        }

                //        if (cadena.GetUpperBound(0) == 2)
                //        {
                //            txtApePaterno.Text = cadena[0];
                //            txtApeMaterno.Text = cadena[1];
                //            txtPrimerNombre.Text = cadena[cadena.Length - 1];
                //            txtSegundoNombre.Text = string.Empty;
                //        }

                //        if (cadena.GetUpperBound(0) >= 3)
                //        {
                //            txtApePaterno.Text = cadena[0];
                //            txtApeMaterno.Text = cadena[1];
                //            txtPrimerNombre.Text = cadena[cadena.Length - 2];
                //            txtSegundoNombre.Text = cadena[cadena.Length - 1];
                //        }
                //    }
                //    txtDireccion.Focus();
                //}
                

                #endregion

                ObtenerDatosDNI_New(nroDoc);
            }
        }

        private void ObtenerDatosDNI_New(string nroDoc)
        {
            try
            {
                txtApeMaterno.Clear();
                txtApePaterno.Clear();
                txtPrimerNombre.Clear();
                txtSegundoNombre.Clear();
                txtDireccion.Clear();
                var urlEssalud = "http://ww1.essalud.gob.pe/sisep/postulante/postulante/postulante_obtenerDatosPostulante.htm?strDni=" + nroDoc;

                System.Net.WebClient wcEssalud = new System.Net.WebClient();

                var DataEssalud = wcEssalud.DownloadString(urlEssalud);

                string validar = DataEssalud.Split(',', ':')[6].Replace("\"", "").Trim();
                if (validar != "" && validar != null)
                {
                    string[] desconcat = DataEssalud.Split(',', ':');

                    txtPrimerNombre.Text = desconcat[6].Replace("\"", "").Trim();
                    txtApePaterno.Text = desconcat[4].Replace("\"", "").Trim();

                    txtApeMaterno.Text = desconcat[12].Replace("\"", "").Trim();
                    txtApeMaterno.Text = txtApeMaterno.Text.Replace("}", "").Trim();
                    txtApeMaterno.Text = txtApeMaterno.Text.Replace("]", "").Trim();

                    //txtDocNumber.Text = desconcat[2].Replace("\"", "").Trim();
                    txtFecNac.Value = DateTime.Parse(desconcat[8].Replace("\"", "").Trim());
                    cboGenero.SelectedIndex = Convert.ToInt32(desconcat[10].Replace("\"", "").Trim());// == "3" ? "2" : desconcat[10].Replace("\"", "").Trim() == "2" ? "1" : "1";
                    //ddlDocTypeId.SelectedValue = "1";
                    //_personId = null;
                }
                else
                {
                    var urlReniec = "https://dniruc.apisperu.com/api/v1/dni/" + nroDoc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImVkdWFyZG9xYzE4M0BvdXRsb29rLmNvbSJ9.RVuS2_RQEowXN8om3Wx7ifm0I2gl01ck5_vH4HlG5Nw";

                    System.Net.WebClient wcReniec = new System.Net.WebClient();
                    string DataReniec = wcReniec.DownloadString(urlReniec);

                    if (DataReniec != null)
                    {
                        string[] desconcat = DataReniec.Split(',', ':');

                        txtPrimerNombre.Text = desconcat[3].Replace("\"", "").Trim();
                        txtApePaterno.Text = desconcat[5].Replace("\"", "").Trim();
                        txtApeMaterno.Text = desconcat[7].Replace("\"", "").Trim();
                        //txtDocNumber.Text = desconcat[1].Replace("\"", "").Trim();
                        //ddlDocTypeId.SelectedValue = "1";
                        //_personId = null;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Nro. de documento incorrecto", @"Información");
                throw;
            }
        }

        private void ObtenerDatosRUC(string nroDoc)
        {
            try
            {
                txtApeMaterno.Clear();
                txtApePaterno.Clear();
                txtPrimerNombre.Clear();
                txtSegundoNombre.Clear();
                txtDireccion.Clear();
                var urlReniec = "https://dniruc.apisperu.com/api/v1/ruc/" + nroDoc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImVkdWFyZG9xYzE4M0BvdXRsb29rLmNvbSJ9.RVuS2_RQEowXN8om3Wx7ifm0I2gl01ck5_vH4HlG5Nw";

                System.Net.WebClient wcReniec = new System.Net.WebClient();
                string DataReniec = wcReniec.DownloadString(urlReniec);

                if (DataReniec != null)
                {
                    string[] desconcat = DataReniec.Split(',', ':');

                    string actividadConc = desconcat[33].Replace("\"", "");
                    actividadConc = actividadConc.Replace("[", "");
                    actividadConc = actividadConc.Replace("]", "");

                    var actividad = actividadConc.Trim().Split(new[] { '-', '\n' });

                    txtPrimerNombre.Text = desconcat[3].Replace("\"", "").Trim();
                    txtDireccion.Text = desconcat[15].Replace("\"", "").Trim() + " " + desconcat[17].Replace("\"", "").Trim() + " - " + desconcat[19].Replace("\"", "").Trim() + " - " + desconcat[21].Replace("\"", "").Trim();

                    txtTelefono.Text = desconcat[7].Replace("\"", "").Trim();
                    txtTelefono.Text = desconcat[7].Replace("[", "").Trim();
                    txtTelefono.Text = desconcat[7].Replace("]", "").Trim();

                    if (actividad.Length >= 2)
                    {
                        txtAlias.Text = actividad[0].Trim() + "" + actividad[1].Trim();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Nro. de documento incorrecto", @"Información");
                throw;
            }
        }

        private void grdAvales_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new System.Drawing.Point(e.X, e.Y);
            Infragistics.Win.UIElement uiElement = ((Infragistics.Win.UltraWinGrid.UltraGridBase)sender).DisplayLayout.UIElement.ElementFromPoint(point);

            if (uiElement == null || uiElement.Parent == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)uiElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (row == null)
            {
                btnAvalEditar.Enabled = false;
                btnChoferEliminar.Enabled = false;
            }
            else
            {
                btnAvalEditar.Enabled = _btnAvalEditar;
                btnChoferEliminar.Enabled = _btnChoferEliminar;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVendedor frm = new frmVendedor(_v_IdCliente, grdData.Rows[grdData.ActiveRow.Index].Cells["NombreRazonSocial"].Value.ToString());
            frm.ShowDialog();
            if (frm._OrigenProcesado == true)
            {
                string NroDoc = grdData.Rows[grdData.ActiveRow.Index].Cells["v_NroDocIdentificacion"].Value.ToString();
                btnBuscar_Click(sender, e);
                lblNombreVendedor.Text = frm._NombreVendedor;
                MantenerSeleccion(NroDoc);
            }
        }
        #endregion

        #region Clases/Validaciones
        private void MantenerSeleccion(string ValorSeleccionado)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grdData.Rows)
            {
                if (row.Cells["v_IdCliente"].Text == ValorSeleccionado)
                {
                    grdData.ActiveRow = row;
                    grdData.ActiveRow.Selected = true;
                    break;
                }
            }
        }

        private void MantenerSeleccionAval(string ValorSeleccionado)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grdAvales.Rows)
            {
                if (row.Cells["v_NroDocIdentificacion"].Text == ValorSeleccionado)
                {
                    grdAvales.ActiveRow = row;
                    grdAvales.ActiveRow.Selected = true;
                    break;
                }
            }
        }

        private void LimpiaDetalle()
        {
            txtCodigoAnexo.Clear();
            cboTipoPersona.Value = "-1";
            cboTipoDocumento.Value = "-1";
            cboTipoDocumento.Enabled = true;
            txtNroDocumento.Clear();
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtApeMaterno.Clear();
            txtApePaterno.Clear();
            cboGenero.Value = "-1";
            txtDireccion.Clear();
            txtDireccionSec.Clear();
            ddlPais.Value = "-1";
            ddlDepartamento.Value = "-1";
            ddlProvincia.Value = "-1";
            ddlDistrito.Value = "-1";
            txtTelefono.Clear();
            txtFax.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            txtContacto.Clear();
            txtWeb.Clear();
            chkActivo.Checked = true;
            chkExtrangero.Checked = false;
            txtFecNac.Text = null;
            txtCodigoAnexo.Focus();
            btnConsultaInternet.Enabled = false;
            txtProveedorNroCuentaDetraccion.Clear();
            txtProveedorServicio.Clear();
            chkProveedorAfectoT.Checked = false;
            rbtnNoPrestador.Checked = true;
            cboDobleTributacion.Value = "-1";
            txtProveedorServicio.Clear();
        }

        private void LimpiarAvalDatos()
        {
            txtAvalTelefono.Clear();
            txtAvalApeNombres.Clear();
            txtAvalDireccion.Clear();
            txtAvalLocalidad.Clear();
            txtAvalNroDocumento.Clear();
        }

        private void ActivaDesactivaBotonesAval()
        {
            if (grdAvales.Rows.Count() == 0)
            {
                btnAvalEditar.Enabled = false;
                btnChoferEliminar.Enabled = false;
            }
            else
            {
                btnAvalEditar.Enabled = _btnAvalEditar;
                btnChoferEliminar.Enabled = _btnChoferEliminar;
            }
        }

        //private string CalcularUltimoDigitoRuc(string NroDocumento)
        //{
        //    int NroIdentificador =0 ;

        //    if (!string.IsNullOrEmpty(NroDocumento) && NroDocumento.Length == 11)
        //    {
        //        int[] Factores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
        //        int[] Productos = new int[10];
        //        int LongitudDocumento = NroDocumento.Length;
        //        int SumaProductos, Resultado;
        //        NroIdentificador = int.Parse(NroDocumento.Substring(LongitudDocumento - 1, 1));

        //        for (int i = 0; i < 10; i++)
        //        {
        //            int Valor = int.Parse(NroDocumento.Substring(i, 1));
        //            Productos[i] = Valor * Factores[i];
        //        }

        //        SumaProductos = Productos.Sum();
        //        Resultado = 11 - (SumaProductos % 11);

        //        switch (Resultado)
        //        {
        //            case 10:
        //                Resultado = 0;
        //                break;

        //            case 11:
        //                Resultado = 1;
        //                break;
        //        }

        //        if (Resultado > 11)
        //        {
        //            string _Result;
        //            _Result = Resultado.ToString();
        //            Resultado = int.Parse(_Result.Substring(_Result.Length - 1, 1));
        //        }


        //        //if (Resultado == NroIdentificador)
        //        //{
        //        //    //return true;
        //        //}
        //    }
        //    return NroIdentificador.ToString();


        //}

        public int CalcularUltimoDigitoRuc(string NroDocumento)
        {

            int[] Factores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int[] Productos = new int[10];
            //int LongitudDocumento = NroDocumento.Length;
            int SumaProductos, Resultado;
            //int NroIdentificador = int.Parse(NroDocumento.Substring(LongitudDocumento - 1, 1));

            for (int i = 0; i < 10; i++)
            {
                int Valor = int.Parse(NroDocumento.Substring(i, 1));
                Productos[i] = Valor * Factores[i];
            }

            SumaProductos = Productos.Sum();
            Resultado = 11 - (SumaProductos % 11);

            switch (Resultado)
            {
                case 10:
                    Resultado = 0;
                    break;

                case 11:
                    Resultado = 1;
                    break;
            }

            if (Resultado > 11)
            {
                string _Result;
                _Result = Resultado.ToString();
                Resultado = int.Parse(_Result.Substring(_Result.Length - 1, 1));
                return Resultado;
            }
            else
            {
                return Resultado;
            }
        }

        #endregion

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigoAnexo_Validating(object sender, CancelEventArgs e)
        {


        }


        #region AMC

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sW = new StreamWriter(@"C:\hola.txt");

            for (int row = 0; row < grdData.Rows.Count(); row++)
            {
                string lines = "";
                for (int col = 0; col < 3; col++)
                {
                    string String = grdData.Rows[row].Cells[col].Value.ToString();
                    int LengthString = String.Length;
                    if (col == 0)
                    {
                        int LengthCell = 70;

                        if (string.IsNullOrEmpty(lines))
                        {
                            lines += String.PadRight(LengthCell);
                        }
                        else
                        {
                            lines += "|" + String.PadRight(LengthCell - LengthString);
                        }
                        //lines += (string.IsNullOrEmpty(lines) ? " " : "|") + grdData.Rows[row].Cells[col].Value.ToString(); 
                    }
                    else if (col == 1)
                    {
                        int LengthCell = 3;

                        if (string.IsNullOrEmpty(lines))
                        {
                            lines += String.PadRight(LengthCell);
                        }
                        else
                        {
                            lines += "|" + String.PadRight(LengthCell - LengthString);
                        }
                    }
                    else if (col == 2)
                    {
                        int LengthCell = 10;

                        if (string.IsNullOrEmpty(lines))
                        {
                            lines += String.PadRight(LengthCell);
                        }
                        else
                        {
                            lines += "|" + String.PadRight(LengthCell - LengthString);
                        }
                    }

                }

                sW.WriteLine(lines);
            }

            sW.Close();
        }
        #endregion

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboTipoDocumento.Value.ToString() == "1" || cboTipoDocumento.Value.ToString() == "6")
            {
                Utils.Windows.NumeroEnteroUltraTextBox(txtNroDocumento, e);
            }
        }

        #region Linea Credito
        void ActivarLineaCredito(bool estado)
        {
            txtAcuenta.Enabled = estado;
            txtCredito.Enabled = estado;
            cboMoneda.Enabled = estado;
            txtSaldo.Enabled = estado;
            btnCalcular.Enabled = estado;
            btnBuscarPendientes.Enabled = estado;
        }

        private void chkLineaCredito_CheckedChanged(object sender, EventArgs e)
        {
            ActivarLineaCredito(chkLineaCredito.Checked);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            OperationResult pOperationResult = new OperationResult();
            double TipoCambio = 0;
            TipoCambio = double.Parse(new VentaBL().DevolverTipoCambioPorFecha(ref pOperationResult, DateTime.Today.Date));

            if (TipoCambio == 0)
            {
                UltraMessageBox.Show("No se ha registrado ningún tipo de cambio para el día de hoy.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (uvLineaCredito.Validate(true, false).IsValid)
            {
                double Credito = double.Parse(txtCredito.Value.ToString());
                double Deuda, Saldo;

                if (Credito > 0)
                {
                    Deuda = _objClienteBL.ObtenerDeudaPendientePorCliente(ref pOperationResult, int.Parse(cboMoneda.Value.ToString()), _clienteDto.v_IdCliente, TipoCambio);
                    Saldo = Credito - Deuda;
                    txtAcuenta.Value = Deuda;
                    txtSaldo.Value = Saldo;

                    if (Saldo < 0)
                    {
                        txtSaldo.Appearance.BackColor = Color.Salmon;
                        UltraMessageBox.Show("La deuda es mayor que el crédito disponible! \nPor favor ingrese un crédito más alto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCredito.Focus();
                    }
                    else
                    {
                        txtSaldo.Appearance.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnBuscarPendientes_Click(object sender, EventArgs e)
        {
            string Filtro = "v_IdCliente==\"" + _clienteDto.v_IdCliente + "\"";
            DateTime F_Ini = DateTime.Parse("1/01/" + Globals.ClientSession.i_Periodo.ToString());
            DateTime F_Fin = DateTime.Parse("31/12/" + Globals.ClientSession.i_Periodo.ToString());

            OperationResult objOperationResult = new OperationResult();
            var _objData = new CobranzaBL().ListarCobranzasPendientes(ref objOperationResult, null, Filtro, F_Ini, F_Fin, true);

            if (objOperationResult.Success != 1)
            {
                UltraMessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdDataCredito.DataSource = _objData;
        }

        void CargarLineaCredito(string IdCliente)
        {
            OperationResult objOperationResult = new OperationResult();

            _lineacreditoempresaDto = _objClienteBL.DevuelveLineaCreditoCliente(ref objOperationResult, _clienteDto.v_IdCliente);

            if (_lineacreditoempresaDto != null)
            {
                chkLineaCredito.Checked = _clienteDto.i_UsaLineaCredito == 1 ? true : false;
                txtAcuenta.Value = _lineacreditoempresaDto.d_Acuenta;
                txtCredito.Value = _lineacreditoempresaDto.d_Credito;
                txtSaldo.Value = _lineacreditoempresaDto.d_Saldo;
                cboMoneda.Value = _lineacreditoempresaDto.i_IdMoneda.ToString();
                ActivarLineaCredito(chkLineaCredito.Checked);
            }
            else
            {
                _lineacreditoempresaDto = new lineacreditoempresaDto();
                ActivarLineaCredito(false);
                chkLineaCredito.Checked = _clienteDto.i_UsaLineaCredito == 1 ? true : false;
                txtAcuenta.Value = 0;
                txtSaldo.Value = 0;
                txtCredito.Value = 0;
                cboMoneda.Value = "-1";
            }
        }
        #endregion

        private void txtNroDocumento_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnConsultar")
            {
                if (txtNroDocumento.Text.Trim().Length == 11 && Utils.Windows.ValidarRuc(txtNroDocumento.Text.Trim()))
                {
                    string[] _Contribuyente = new string[10];

                    frmCustomerCapchaSUNAT frm = new frmCustomerCapchaSUNAT(txtNroDocumento.Text.Trim());
                    frm.ShowDialog();
                }
                else
                {
                    UltraMessageBox.Show("Sólo se verifica para ruc válidos", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void rbtnSiPrestador_CheckedChanged(object sender, EventArgs e)
        {
            Hab_DeshSiPrestadorServicios(true);
            
        }
        private void Hab_DeshSiPrestadorServicios(bool Estado)
        {
            txtProveedorServicio.Enabled = Estado;
            //cboDobleTributacion.Enabled = Estado;

        }

        private void rbtnNoPrestador_CheckedChanged(object sender, EventArgs e)
        {
            Hab_DeshSiPrestadorServicios(false);
           // cboDobleTributacion.Value = "-1";
        }

        private void btnDirecciones_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(_clienteDto.v_IdCliente))
            {
                frmClienteDirecciones frm = new frmClienteDirecciones(_clienteDto.v_IdCliente);
                frm.ShowDialog();
            }

        }

        private void btnActualizarDirecciones_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            new ClienteBL().IniciarDirecionesClientes(ref  objOperationResult);
            if (objOperationResult.Success == 0)
            {
                UltraMessageBox.Show("Hubo un error al generar proceso");
            }
            else
            {
                UltraMessageBox.Show("Proceso terminado correctamente");
            }
        }

    }
}
