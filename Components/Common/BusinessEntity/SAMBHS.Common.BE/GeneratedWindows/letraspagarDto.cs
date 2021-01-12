//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:10:36
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SAMBHS.Common.BE
{
    [DataContract()]
    public partial class letraspagarDto
    {
        [DataMember()]
        public String v_IdLetrasPagar { get; set; }

        [DataMember()]
        public String v_IdProveedor { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Correlativo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstado { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaRegistro { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NoSeleccionarFactura { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalFacturas { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalLetras { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NroLetras { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NroDias { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public List<letraspagarcanjeDto> letraspagarcanje { get; set; }

        [DataMember()]
        public List<letraspagardetalleDto> letraspagardetalle { get; set; }

        public letraspagarDto()
        {
        }

        public letraspagarDto(String v_IdLetrasPagar, String v_IdProveedor, String v_Periodo, String v_Mes, String v_Correlativo, Nullable<Int32> i_IdEstado, Nullable<DateTime> t_FechaRegistro, Nullable<Decimal> d_TipoCambio, Nullable<Int32> i_IdMoneda, Nullable<Int32> i_NoSeleccionarFactura, Nullable<Decimal> d_TotalFacturas, Nullable<Decimal> d_TotalLetras, Nullable<Int32> i_NroLetras, Nullable<Int32> i_NroDias, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, List<letraspagarcanjeDto> letraspagarcanje, List<letraspagardetalleDto> letraspagardetalle)
        {
			this.v_IdLetrasPagar = v_IdLetrasPagar;
			this.v_IdProveedor = v_IdProveedor;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.i_IdEstado = i_IdEstado;
			this.t_FechaRegistro = t_FechaRegistro;
			this.d_TipoCambio = d_TipoCambio;
			this.i_IdMoneda = i_IdMoneda;
			this.i_NoSeleccionarFactura = i_NoSeleccionarFactura;
			this.d_TotalFacturas = d_TotalFacturas;
			this.d_TotalLetras = d_TotalLetras;
			this.i_NroLetras = i_NroLetras;
			this.i_NroDias = i_NroDias;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.letraspagarcanje = letraspagarcanje;
			this.letraspagardetalle = letraspagardetalle;
        }
    }
}
