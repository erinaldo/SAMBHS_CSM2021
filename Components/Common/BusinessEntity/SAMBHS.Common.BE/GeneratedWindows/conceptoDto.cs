//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:03
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
    public partial class conceptoDto
    {
        [DataMember()]
        public String v_IdConcepto { get; set; }

        [DataMember()]
        public String v_Codigo { get; set; }

        [DataMember()]
        public String v_Nombre { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdArea { get; set; }

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
        public String v_Periodo { get; set; }

        public conceptoDto()
        {
        }

        public conceptoDto(String v_IdConcepto, String v_Codigo, String v_Nombre, Nullable<Int32> i_IdArea, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, String v_Periodo)
        {
			this.v_IdConcepto = v_IdConcepto;
			this.v_Codigo = v_Codigo;
			this.v_Nombre = v_Nombre;
			this.i_IdArea = i_IdArea;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.v_Periodo = v_Periodo;
        }
    }
}
