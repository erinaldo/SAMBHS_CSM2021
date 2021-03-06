//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:45
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
    /// Assembler for <see cref="planillaafechrsexttard"/> and <see cref="planillaafechrsexttardDto"/>.
    /// </summary>
    public static partial class planillaafechrsexttardAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillaafechrsexttardDto"/> converted from <see cref="planillaafechrsexttard"/>.</param>
        static partial void OnDTO(this planillaafechrsexttard entity, planillaafechrsexttardDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillaafechrsexttard"/> converted from <see cref="planillaafechrsexttardDto"/>.</param>
        static partial void OnEntity(this planillaafechrsexttardDto dto, planillaafechrsexttard entity);

        /// <summary>
        /// Converts this instance of <see cref="planillaafechrsexttardDto"/> to an instance of <see cref="planillaafechrsexttard"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillaafechrsexttardDto"/> to convert.</param>
        public static planillaafechrsexttard ToEntity(this planillaafechrsexttardDto dto)
        {
            if (dto == null) return null;

            var entity = new planillaafechrsexttard();

            entity.i_Id = dto.i_Id;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_IdConceptoPlanilla = dto.v_IdConceptoPlanilla;
            entity.i_HorasExtras = dto.i_HorasExtras;
            entity.i_Tardanza = dto.i_Tardanza;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillaafechrsexttard"/> to an instance of <see cref="planillaafechrsexttardDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillaafechrsexttard"/> to convert.</param>
        public static planillaafechrsexttardDto ToDTO(this planillaafechrsexttard entity)
        {
            if (entity == null) return null;

            var dto = new planillaafechrsexttardDto();

            dto.i_Id = entity.i_Id;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_IdConceptoPlanilla = entity.v_IdConceptoPlanilla;
            dto.i_HorasExtras = entity.i_HorasExtras;
            dto.i_Tardanza = entity.i_Tardanza;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaafechrsexttardDto"/> to an instance of <see cref="planillaafechrsexttard"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillaafechrsexttard> ToEntities(this IEnumerable<planillaafechrsexttardDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaafechrsexttard"/> to an instance of <see cref="planillaafechrsexttardDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillaafechrsexttardDto> ToDTOs(this IEnumerable<planillaafechrsexttard> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
