//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:23
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
    public partial class lineacreditoempresaDto
    {
        [DataMember()]
        public Int32 i_IdLineaPrecio { get; set; }

        [DataMember()]
        public String v_IdCliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Credito { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Acuenta { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Saldo { get; set; }

        public lineacreditoempresaDto()
        {
        }

        public lineacreditoempresaDto(Int32 i_IdLineaPrecio, String v_IdCliente, Nullable<Int32> i_IdMoneda, Nullable<Decimal> d_Credito, Nullable<Decimal> d_Acuenta, Nullable<Decimal> d_Saldo)
        {
			this.i_IdLineaPrecio = i_IdLineaPrecio;
			this.v_IdCliente = v_IdCliente;
			this.i_IdMoneda = i_IdMoneda;
			this.d_Credito = d_Credito;
			this.d_Acuenta = d_Acuenta;
			this.d_Saldo = d_Saldo;
        }
    }
}
