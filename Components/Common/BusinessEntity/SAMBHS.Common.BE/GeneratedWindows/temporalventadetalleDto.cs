//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:08:14
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
    public partial class temporalventadetalleDto
    {
        [DataMember()]
        public Int32 v_IdTemporalVentaD { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdAlmacen { get; set; }

        [DataMember()]
        public String v_IdProductoDetalle { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdUnidadEmpaque { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Cantidad { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdUnidadMedida { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_CantidadEmpaque { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Precio { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Total { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_CantidadBulto { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoBulto { get; set; }

        [DataMember()]
        public String v_Observacion { get; set; }

        [DataMember()]
        public String v_IdMovimientoDetalle { get; set; }

        public temporalventadetalleDto()
        {
        }

        public temporalventadetalleDto(Int32 v_IdTemporalVentaD, Nullable<Int32> i_IdAlmacen, String v_IdProductoDetalle, Nullable<Int32> i_IdUnidadEmpaque, Nullable<Decimal> d_Cantidad, Nullable<Int32> i_IdUnidadMedida, Nullable<Decimal> d_CantidadEmpaque, Nullable<Decimal> d_Precio, Nullable<Decimal> d_Total, Nullable<Decimal> d_CantidadBulto, Nullable<Int32> i_IdTipoBulto, String v_Observacion, String v_IdMovimientoDetalle)
        {
			this.v_IdTemporalVentaD = v_IdTemporalVentaD;
			this.i_IdAlmacen = i_IdAlmacen;
			this.v_IdProductoDetalle = v_IdProductoDetalle;
			this.i_IdUnidadEmpaque = i_IdUnidadEmpaque;
			this.d_Cantidad = d_Cantidad;
			this.i_IdUnidadMedida = i_IdUnidadMedida;
			this.d_CantidadEmpaque = d_CantidadEmpaque;
			this.d_Precio = d_Precio;
			this.d_Total = d_Total;
			this.d_CantidadBulto = d_CantidadBulto;
			this.i_IdTipoBulto = i_IdTipoBulto;
			this.v_Observacion = v_Observacion;
			this.v_IdMovimientoDetalle = v_IdMovimientoDetalle;
        }
    }
}
