//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:10:14
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
    public partial class letrasdescuentomantenimientoDto
    {
        [DataMember()]
        public String v_IdLetraDescuentoCancelacion { get; set; }

        [DataMember()]
        public String v_IdLetrasDetalle { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaCancelacion { get; set; }

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
        public Nullable<Int32> i_Estado { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Saldo { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Acuenta { get; set; }

        [DataMember()]
        public letrasdetalleDto letrasdetalle { get; set; }

        public letrasdescuentomantenimientoDto()
        {
        }

        public letrasdescuentomantenimientoDto(String v_IdLetraDescuentoCancelacion, String v_IdLetrasDetalle, Nullable<DateTime> t_FechaCancelacion, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_Estado, Nullable<Decimal> d_Saldo, Nullable<Decimal> d_Acuenta, letrasdetalleDto letrasdetalle)
        {
			this.v_IdLetraDescuentoCancelacion = v_IdLetraDescuentoCancelacion;
			this.v_IdLetrasDetalle = v_IdLetrasDetalle;
			this.t_FechaCancelacion = t_FechaCancelacion;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_Estado = i_Estado;
			this.d_Saldo = d_Saldo;
			this.d_Acuenta = d_Acuenta;
			this.letrasdetalle = letrasdetalle;
        }
    }
}
