//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:26
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
    /// Assembler for <see cref="cajachica"/> and <see cref="cajachicaDto"/>.
    /// </summary>
    public static partial class cajachicaAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="cajachicaDto"/> converted from <see cref="cajachica"/>.</param>
        static partial void OnDTO(this cajachica entity, cajachicaDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="cajachica"/> converted from <see cref="cajachicaDto"/>.</param>
        static partial void OnEntity(this cajachicaDto dto, cajachica entity);

        /// <summary>
        /// Converts this instance of <see cref="cajachicaDto"/> to an instance of <see cref="cajachica"/>.
        /// </summary>
        /// <param name="dto"><see cref="cajachicaDto"/> to convert.</param>
        public static cajachica ToEntity(this cajachicaDto dto)
        {
            if (dto == null) return null;

            var entity = new cajachica();

            entity.v_IdCajaChica = dto.v_IdCajaChica;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.t_FechaRegistro = dto.t_FechaRegistro;
            entity.d_TotalIngresos = dto.d_TotalIngresos;
            entity.d_TotalGastos = dto.d_TotalGastos;
            entity.d_CajaSaldo = dto.d_CajaSaldo;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.i_IdEstado = dto.i_IdEstado;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.i_IdMoneda = dto.i_IdMoneda;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="cajachica"/> to an instance of <see cref="cajachicaDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="cajachica"/> to convert.</param>
        public static cajachicaDto ToDTO(this cajachica entity)
        {
            if (entity == null) return null;

            var dto = new cajachicaDto();

            dto.v_IdCajaChica = entity.v_IdCajaChica;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.t_FechaRegistro = entity.t_FechaRegistro;
            dto.d_TotalIngresos = entity.d_TotalIngresos;
            dto.d_TotalGastos = entity.d_TotalGastos;
            dto.d_CajaSaldo = entity.d_CajaSaldo;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.i_IdEstado = entity.i_IdEstado;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.i_IdMoneda = entity.i_IdMoneda;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="cajachicaDto"/> to an instance of <see cref="cajachica"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<cajachica> ToEntities(this IEnumerable<cajachicaDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="cajachica"/> to an instance of <see cref="cajachicaDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<cajachicaDto> ToDTOs(this IEnumerable<cajachica> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
