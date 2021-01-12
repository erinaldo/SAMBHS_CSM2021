//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/10/02 - 09:33:03
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
    public partial class ordenproduccionDto
    {
        [DataMember()]
        public Int32 i_IdOrdenProduccion { get; set; }

        [DataMember()]
        public String v_IdProductoDetalle { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Correlativo { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaRegistro { get; set; }

        [DataMember()]
        public String v_Observacion { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaInicio { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaTermino { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Cantidad { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_CantidadUnidadMedida { get; set; }

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

        public ordenproduccionDto()
        {
        }

        public ordenproduccionDto(Int32 i_IdOrdenProduccion, String v_IdProductoDetalle, String v_Mes, String v_Correlativo, String v_Periodo, Nullable<DateTime> t_FechaRegistro, String v_Observacion, Nullable<DateTime> t_FechaInicio, Nullable<DateTime> t_FechaTermino, Nullable<Decimal> d_Cantidad, Nullable<Decimal> d_CantidadUnidadMedida, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha)
        {
			this.i_IdOrdenProduccion = i_IdOrdenProduccion;
			this.v_IdProductoDetalle = v_IdProductoDetalle;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.v_Periodo = v_Periodo;
			this.t_FechaRegistro = t_FechaRegistro;
			this.v_Observacion = v_Observacion;
			this.t_FechaInicio = t_FechaInicio;
			this.t_FechaTermino = t_FechaTermino;
			this.d_Cantidad = d_Cantidad;
			this.d_CantidadUnidadMedida = d_CantidadUnidadMedida;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
        }
    }
}
