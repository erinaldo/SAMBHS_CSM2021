//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/18 - 12:09:20
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
    public partial class saldoscontablesDto
    {
        [DataMember()]
        public Int32 i_IdSaldo { get; set; }

        [DataMember()]
        public String v_Anio { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_NroCuenta { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ImporteSolesD { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ImporteSolesH { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ImporteDolaresD { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ImporteDolaresH { get; set; }

        [DataMember()]
        public String v_ReplicationId { get; set; }

        public saldoscontablesDto()
        {
        }

        public saldoscontablesDto(Int32 i_IdSaldo, String v_Anio, String v_Mes, String v_NroCuenta, Nullable<Int32> i_IdMoneda, Nullable<Decimal> d_ImporteSolesD, Nullable<Decimal> d_ImporteSolesH, Nullable<Decimal> d_ImporteDolaresD, Nullable<Decimal> d_ImporteDolaresH, String v_ReplicationId)
        {
            this.i_IdSaldo = i_IdSaldo;
            this.v_Anio = v_Anio;
            this.v_Mes = v_Mes;
            this.v_NroCuenta = v_NroCuenta;
            this.i_IdMoneda = i_IdMoneda;
            this.d_ImporteSolesD = d_ImporteSolesD;
            this.d_ImporteSolesH = d_ImporteSolesH;
            this.d_ImporteDolaresD = d_ImporteDolaresD;
            this.d_ImporteDolaresH = d_ImporteDolaresH;
            this.v_ReplicationId = v_ReplicationId;
        }
    }
}
