//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:34
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using SAMBHS.Common.DataModel;

namespace SAMBHS.Common.BE
{

    /// <summary>
    /// Assembler for <see cref="letras"/> and <see cref="letrasDto"/>.
    /// </summary>
    public static partial class letrasAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="letrasDto"/> converted from <see cref="letras"/>.</param>
        static partial void OnDTO(this letras entity, letrasDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="letras"/> converted from <see cref="letrasDto"/>.</param>
        static partial void OnEntity(this letrasDto dto, letras entity);

        /// <summary>
        /// Converts this instance of <see cref="letrasDto"/> to an instance of <see cref="letras"/>.
        /// </summary>
        /// <param name="dto"><see cref="letrasDto"/> to convert.</param>
        public static letras ToEntity(this letrasDto dto)
        {
            if (dto == null) return null;

            var entity = new letras();

            entity.v_IdLetras = dto.v_IdLetras;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.i_IdEstado = dto.i_IdEstado;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.i_NoSeleccionarFactura = dto.i_NoSeleccionarFactura;
            entity.d_TotalFacturas = dto.d_TotalFacturas;
            entity.d_TotalLetras = dto.d_TotalLetras;
            entity.i_NroLetras = dto.i_NroLetras;
            entity.i_NroDias = dto.i_NroDias;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_MotivoEliminacion = dto.v_MotivoEliminacion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="letras"/> to an instance of <see cref="letrasDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="letras"/> to convert.</param>
        public static letrasDto ToDTO(this letras entity)
        {
            if (entity == null) return null;

            var dto = new letrasDto();

            dto.v_IdLetras = entity.v_IdLetras;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.i_IdEstado = entity.i_IdEstado;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.i_NoSeleccionarFactura = entity.i_NoSeleccionarFactura;
            dto.d_TotalFacturas = entity.d_TotalFacturas;
            dto.d_TotalLetras = entity.d_TotalLetras;
            dto.i_NroLetras = entity.i_NroLetras;
            dto.i_NroDias = entity.i_NroDias;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_MotivoEliminacion = entity.v_MotivoEliminacion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="letrasDto"/> to an instance of <see cref="letras"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<letras> ToEntities(this IEnumerable<letrasDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="letras"/> to an instance of <see cref="letrasDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<letrasDto> ToDTOs(this IEnumerable<letras> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
