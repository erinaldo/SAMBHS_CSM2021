//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:54
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
    /// Assembler for <see cref="planillarelaciondescuentos"/> and <see cref="planillarelaciondescuentosDto"/>.
    /// </summary>
    public static partial class planillarelaciondescuentosAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillarelaciondescuentosDto"/> converted from <see cref="planillarelaciondescuentos"/>.</param>
        static partial void OnDTO(this planillarelaciondescuentos entity, planillarelaciondescuentosDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillarelaciondescuentos"/> converted from <see cref="planillarelaciondescuentosDto"/>.</param>
        static partial void OnEntity(this planillarelaciondescuentosDto dto, planillarelaciondescuentos entity);

        /// <summary>
        /// Converts this instance of <see cref="planillarelaciondescuentosDto"/> to an instance of <see cref="planillarelaciondescuentos"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillarelaciondescuentosDto"/> to convert.</param>
        public static planillarelaciondescuentos ToEntity(this planillarelaciondescuentosDto dto)
        {
            if (dto == null) return null;

            var entity = new planillarelaciondescuentos();

            entity.i_Id = dto.i_Id;
            entity.v_Periodo = dto.v_Periodo;
            entity.i_IdTipoPlanilla = dto.i_IdTipoPlanilla;
            entity.v_IdConceptoPlanilla = dto.v_IdConceptoPlanilla;
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
        /// Converts this instance of <see cref="planillarelaciondescuentos"/> to an instance of <see cref="planillarelaciondescuentosDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillarelaciondescuentos"/> to convert.</param>
        public static planillarelaciondescuentosDto ToDTO(this planillarelaciondescuentos entity)
        {
            if (entity == null) return null;

            var dto = new planillarelaciondescuentosDto();

            dto.i_Id = entity.i_Id;
            dto.v_Periodo = entity.v_Periodo;
            dto.i_IdTipoPlanilla = entity.i_IdTipoPlanilla;
            dto.v_IdConceptoPlanilla = entity.v_IdConceptoPlanilla;
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
        /// Converts each instance of <see cref="planillarelaciondescuentosDto"/> to an instance of <see cref="planillarelaciondescuentos"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillarelaciondescuentos> ToEntities(this IEnumerable<planillarelaciondescuentosDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillarelaciondescuentos"/> to an instance of <see cref="planillarelaciondescuentosDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillarelaciondescuentosDto> ToDTOs(this IEnumerable<planillarelaciondescuentos> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
