//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/03/07 - 17:28:59
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
    public partial class tipodecambioDto
    {
        [DataMember()]
        public Int32 i_CodTipoCambio { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Periodo { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaTipoC { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorCompra { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorVenta { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorCompraContable { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorVentaContable { get; set; }

        public tipodecambioDto()
        {
        }

        public tipodecambioDto(Int32 i_CodTipoCambio, Nullable<Int32> i_Periodo, Nullable<DateTime> d_FechaTipoC, Nullable<Decimal> d_ValorCompra, Nullable<Decimal> d_ValorVenta, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Decimal> d_ValorCompraContable, Nullable<Decimal> d_ValorVentaContable)
        {
			this.i_CodTipoCambio = i_CodTipoCambio;
			this.i_Periodo = i_Periodo;
			this.d_FechaTipoC = d_FechaTipoC;
			this.d_ValorCompra = d_ValorCompra;
			this.d_ValorVenta = d_ValorVenta;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.d_ValorCompraContable = d_ValorCompraContable;
			this.d_ValorVentaContable = d_ValorVentaContable;
        }
    }
}
