//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:08:06
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
    public partial class saldomensualbancosDto
    {
        [DataMember()]
        public String v_IdSaldoMensualB { get; set; }

        [DataMember()]
        public String v_NroCuenta { get; set; }

        [DataMember()]
        public String v_Anio { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SaldoSoles { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SaldoDolares { get; set; }

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

        public saldomensualbancosDto()
        {
        }

        public saldomensualbancosDto(String v_IdSaldoMensualB, String v_NroCuenta, String v_Anio, String v_Mes, Nullable<Decimal> d_SaldoSoles, Nullable<Decimal> d_SaldoDolares, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha)
        {
			this.v_IdSaldoMensualB = v_IdSaldoMensualB;
			this.v_NroCuenta = v_NroCuenta;
			this.v_Anio = v_Anio;
			this.v_Mes = v_Mes;
			this.d_SaldoSoles = d_SaldoSoles;
			this.d_SaldoDolares = d_SaldoDolares;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
        }
    }
}
