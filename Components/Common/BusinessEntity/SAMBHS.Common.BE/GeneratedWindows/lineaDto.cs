//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:30
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
    public partial class lineaDto
    {
        [DataMember()]
        public String v_IdLinea { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_CodLinea { get; set; }

        [DataMember()]
        public String v_Nombre { get; set; }

        [DataMember()]
        public String v_NroCuentaVenta { get; set; }

        [DataMember()]
        public String v_NroCuentaCompra { get; set; }

        [DataMember()]
        public String v_NroCuentaDConsumo { get; set; }

        [DataMember()]
        public String v_NroCuentaHConsumo { get; set; }

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
        public Byte[] b_Foto { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Header { get; set; }

        [DataMember()]
        public List<lineacuentaDto> lineacuenta { get; set; }

        public lineaDto()
        {
        }

        public lineaDto(String v_IdLinea, String v_Periodo, String v_CodLinea, String v_Nombre, String v_NroCuentaVenta, String v_NroCuentaCompra, String v_NroCuentaDConsumo, String v_NroCuentaHConsumo, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Byte[] b_Foto, Nullable<Int32> i_Header, List<lineacuentaDto> lineacuenta)
        {
			this.v_IdLinea = v_IdLinea;
			this.v_Periodo = v_Periodo;
			this.v_CodLinea = v_CodLinea;
			this.v_Nombre = v_Nombre;
			this.v_NroCuentaVenta = v_NroCuentaVenta;
			this.v_NroCuentaCompra = v_NroCuentaCompra;
			this.v_NroCuentaDConsumo = v_NroCuentaDConsumo;
			this.v_NroCuentaHConsumo = v_NroCuentaHConsumo;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.b_Foto = b_Foto;
			this.i_Header = i_Header;
			this.lineacuenta = lineacuenta;
        }
    }
}
