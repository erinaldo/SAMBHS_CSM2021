//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:16
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
    public partial class relacionusuarioclienteDto
    {
        [DataMember()]
        public Int32 i_IdRelacionusuariocliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SystemUser { get; set; }

        [DataMember()]
        public String v_IdCliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdDireccionCliente { get; set; }

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
        public clienteDto cliente { get; set; }

        public relacionusuarioclienteDto()
        {
        }

        public relacionusuarioclienteDto(Int32 i_IdRelacionusuariocliente, Nullable<Int32> i_SystemUser, String v_IdCliente, Nullable<Int32> i_IdDireccionCliente, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, clienteDto cliente)
        {
			this.i_IdRelacionusuariocliente = i_IdRelacionusuariocliente;
			this.i_SystemUser = i_SystemUser;
			this.v_IdCliente = v_IdCliente;
			this.i_IdDireccionCliente = i_IdDireccionCliente;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.cliente = cliente;
        }
    }
}
