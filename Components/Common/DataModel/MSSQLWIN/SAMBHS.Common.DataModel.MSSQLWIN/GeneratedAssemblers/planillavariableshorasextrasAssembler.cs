//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:14:06
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
    /// Assembler for <see cref="planillavariableshorasextras"/> and <see cref="planillavariableshorasextrasDto"/>.
    /// </summary>
    public static partial class planillavariableshorasextrasAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillavariableshorasextrasDto"/> converted from <see cref="planillavariableshorasextras"/>.</param>
        static partial void OnDTO(this planillavariableshorasextras entity, planillavariableshorasextrasDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillavariableshorasextras"/> converted from <see cref="planillavariableshorasextrasDto"/>.</param>
        static partial void OnEntity(this planillavariableshorasextrasDto dto, planillavariableshorasextras entity);

        /// <summary>
        /// Converts this instance of <see cref="planillavariableshorasextrasDto"/> to an instance of <see cref="planillavariableshorasextras"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillavariableshorasextrasDto"/> to convert.</param>
        public static planillavariableshorasextras ToEntity(this planillavariableshorasextrasDto dto)
        {
            if (dto == null) return null;

            var entity = new planillavariableshorasextras();

            entity.i_Id = dto.i_Id;
            entity.v_IdPlanillaVariablesTrabajador = dto.v_IdPlanillaVariablesTrabajador;
            entity.d_HorasExtras = dto.d_HorasExtras;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_IdTipoHorasExtras = dto.i_IdTipoHorasExtras;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillavariableshorasextras"/> to an instance of <see cref="planillavariableshorasextrasDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillavariableshorasextras"/> to convert.</param>
        public static planillavariableshorasextrasDto ToDTO(this planillavariableshorasextras entity)
        {
            if (entity == null) return null;

            var dto = new planillavariableshorasextrasDto();

            dto.i_Id = entity.i_Id;
            dto.v_IdPlanillaVariablesTrabajador = entity.v_IdPlanillaVariablesTrabajador;
            dto.d_HorasExtras = entity.d_HorasExtras;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_IdTipoHorasExtras = entity.i_IdTipoHorasExtras;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillavariableshorasextrasDto"/> to an instance of <see cref="planillavariableshorasextras"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillavariableshorasextras> ToEntities(this IEnumerable<planillavariableshorasextrasDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillavariableshorasextras"/> to an instance of <see cref="planillavariableshorasextrasDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillavariableshorasextrasDto> ToDTOs(this IEnumerable<planillavariableshorasextras> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
