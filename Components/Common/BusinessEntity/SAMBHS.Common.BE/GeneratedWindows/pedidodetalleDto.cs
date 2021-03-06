//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/27 - 17:29:58
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
    public partial class pedidodetalleDto
    {
        [DataMember()]
        public String v_IdPedidoDetalle { get; set; }

        [DataMember()]
        public String v_IdPedido { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdAlmacen { get; set; }

        [DataMember()]
        public String v_IdProductoDetalle { get; set; }

        [DataMember()]
        public String v_NombreProducto { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Cantidad { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_CantidadEmpaque { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdUnidadMedida { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_PrecioUnitario { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Valor { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Descuento { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorVenta { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Igv { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_PrecioVenta { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NroUnidades { get; set; }

        [DataMember()]
        public String v_Observacion { get; set; }

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
        public String v_Descuento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoOperacion { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaLiberacion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_LiberacionUsuario { get; set; }

        [DataMember()]
        public String v_NroSerie { get; set; }

        [DataMember()]
        public String v_NroLote { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaCaducidad { get; set; }

        [DataMember()]
        public String v_NroPedido { get; set; }

        public pedidodetalleDto()
        {
        }

        public pedidodetalleDto(String v_IdPedidoDetalle, String v_IdPedido, Nullable<Int32> i_IdAlmacen, String v_IdProductoDetalle, String v_NombreProducto, Nullable<Decimal> d_Cantidad, Nullable<Decimal> d_CantidadEmpaque, Nullable<Int32> i_IdUnidadMedida, Nullable<Decimal> d_PrecioUnitario, Nullable<Decimal> d_Valor, Nullable<Decimal> d_Descuento, Nullable<Decimal> d_ValorVenta, Nullable<Decimal> d_Igv, Nullable<Decimal> d_PrecioVenta, Nullable<Int32> i_NroUnidades, String v_Observacion, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, String v_Descuento, Nullable<Int32> i_IdTipoOperacion, Nullable<DateTime> t_FechaLiberacion, Nullable<Int32> i_LiberacionUsuario, String v_NroSerie, String v_NroLote, Nullable<DateTime> t_FechaCaducidad, String v_NroPedido)
        {
			this.v_IdPedidoDetalle = v_IdPedidoDetalle;
			this.v_IdPedido = v_IdPedido;
			this.i_IdAlmacen = i_IdAlmacen;
			this.v_IdProductoDetalle = v_IdProductoDetalle;
			this.v_NombreProducto = v_NombreProducto;
			this.d_Cantidad = d_Cantidad;
			this.d_CantidadEmpaque = d_CantidadEmpaque;
			this.i_IdUnidadMedida = i_IdUnidadMedida;
			this.d_PrecioUnitario = d_PrecioUnitario;
			this.d_Valor = d_Valor;
			this.d_Descuento = d_Descuento;
			this.d_ValorVenta = d_ValorVenta;
			this.d_Igv = d_Igv;
			this.d_PrecioVenta = d_PrecioVenta;
			this.i_NroUnidades = i_NroUnidades;
			this.v_Observacion = v_Observacion;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.v_Descuento = v_Descuento;
			this.i_IdTipoOperacion = i_IdTipoOperacion;
			this.t_FechaLiberacion = t_FechaLiberacion;
			this.i_LiberacionUsuario = i_LiberacionUsuario;
			this.v_NroSerie = v_NroSerie;
			this.v_NroLote = v_NroLote;
			this.t_FechaCaducidad = t_FechaCaducidad;
			this.v_NroPedido = v_NroPedido;
        }
    }
}
