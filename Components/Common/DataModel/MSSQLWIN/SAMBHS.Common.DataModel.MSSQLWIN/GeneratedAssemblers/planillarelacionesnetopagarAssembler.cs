//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:51
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
    /// Assembler for <see cref="planillarelacionesnetopagar"/> and <see cref="planillarelacionesnetopagarDto"/>.
    /// </summary>
    public static partial class planillarelacionesnetopagarAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillarelacionesnetopagarDto"/> converted from <see cref="planillarelacionesnetopagar"/>.</param>
        static partial void OnDTO(this planillarelacionesnetopagar entity, planillarelacionesnetopagarDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillarelacionesnetopagar"/> converted from <see cref="planillarelacionesnetopagarDto"/>.</param>
        static partial void OnEntity(this planillarelacionesnetopagarDto dto, planillarelacionesnetopagar entity);

        /// <summary>
        /// Converts this instance of <see cref="planillarelacionesnetopagarDto"/> to an instance of <see cref="planillarelacionesnetopagar"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillarelacionesnetopagarDto"/> to convert.</param>
        public static planillarelacionesnetopagar ToEntity(this planillarelacionesnetopagarDto dto)
        {
            if (dto == null) return null;

            var entity = new planillarelacionesnetopagar();

            entity.i_Id = dto.i_Id;
            entity.v_Periodo = dto.v_Periodo;
            entity.i_IdTipoPlanilla = dto.i_IdTipoPlanilla;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillarelacionesnetopagar"/> to an instance of <see cref="planillarelacionesnetopagarDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillarelacionesnetopagar"/> to convert.</param>
        public static planillarelacionesnetopagarDto ToDTO(this planillarelacionesnetopagar entity)
        {
            if (entity == null) return null;

            var dto = new planillarelacionesnetopagarDto();

            dto.i_Id = entity.i_Id;
            dto.v_Periodo = entity.v_Periodo;
            dto.i_IdTipoPlanilla = entity.i_IdTipoPlanilla;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillarelacionesnetopagarDto"/> to an instance of <see cref="planillarelacionesnetopagar"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillarelacionesnetopagar> ToEntities(this IEnumerable<planillarelacionesnetopagarDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillarelacionesnetopagar"/> to an instance of <see cref="planillarelacionesnetopagarDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillarelacionesnetopagarDto> ToDTOs(this IEnumerable<planillarelacionesnetopagar> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
