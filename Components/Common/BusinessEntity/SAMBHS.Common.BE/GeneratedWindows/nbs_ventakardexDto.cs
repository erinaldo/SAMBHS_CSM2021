//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:35
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
    public partial class nbs_ventakardexDto
    {
        [DataMember()]
        public String v_IdVentaKardex { get; set; }

        [DataMember()]
        public String v_IdVenta { get; set; }

        [DataMember()]
        public String v_NroKardex { get; set; }

        [DataMember()]
        public String v_TipoKardex { get; set; }

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
        public Nullable<Decimal> d_Monto { get; set; }

        public nbs_ventakardexDto()
        {
        }

        public nbs_ventakardexDto(String v_IdVentaKardex, String v_IdVenta, String v_NroKardex, String v_TipoKardex, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Decimal> d_Monto)
        {
			this.v_IdVentaKardex = v_IdVentaKardex;
			this.v_IdVenta = v_IdVenta;
			this.v_NroKardex = v_NroKardex;
			this.v_TipoKardex = v_TipoKardex;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.d_Monto = d_Monto;
        }
    }
}
