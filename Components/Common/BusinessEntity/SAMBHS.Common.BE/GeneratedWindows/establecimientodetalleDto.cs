//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:09:07
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
    public partial class establecimientodetalleDto
    {
        [DataMember()]
        public Int32 i_IdEstablecimientoDetalle { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstablecimiento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoDocumento { get; set; }

        [DataMember()]
        public String v_Serie { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Correlativo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Almacen { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ImpresionVistaPrevia { get; set; }

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
        public String v_NombreImpresora { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DocumentoPredeterminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NumeroItems { get; set; }

        [DataMember()]
        public establecimientoDto establecimiento { get; set; }

        public establecimientodetalleDto()
        {
        }

        public establecimientodetalleDto(Int32 i_IdEstablecimientoDetalle, Nullable<Int32> i_IdEstablecimiento, Nullable<Int32> i_IdTipoDocumento, String v_Serie, Nullable<Int32> i_Correlativo, Nullable<Int32> i_Almacen, Nullable<Int32> i_ImpresionVistaPrevia, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, String v_NombreImpresora, Nullable<Int32> i_DocumentoPredeterminado, Nullable<Int32> i_NumeroItems, establecimientoDto establecimiento)
        {
			this.i_IdEstablecimientoDetalle = i_IdEstablecimientoDetalle;
			this.i_IdEstablecimiento = i_IdEstablecimiento;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_Serie = v_Serie;
			this.i_Correlativo = i_Correlativo;
			this.i_Almacen = i_Almacen;
			this.i_ImpresionVistaPrevia = i_ImpresionVistaPrevia;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.v_NombreImpresora = v_NombreImpresora;
			this.i_DocumentoPredeterminado = i_DocumentoPredeterminado;
			this.i_NumeroItems = i_NumeroItems;
			this.establecimiento = establecimiento;
        }
    }
}
