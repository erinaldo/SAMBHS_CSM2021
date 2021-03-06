//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:48
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
    /// Assembler for <see cref="planillaconceptosadministracion"/> and <see cref="planillaconceptosadministracionDto"/>.
    /// </summary>
    public static partial class planillaconceptosadministracionAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillaconceptosadministracionDto"/> converted from <see cref="planillaconceptosadministracion"/>.</param>
        static partial void OnDTO(this planillaconceptosadministracion entity, planillaconceptosadministracionDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillaconceptosadministracion"/> converted from <see cref="planillaconceptosadministracionDto"/>.</param>
        static partial void OnEntity(this planillaconceptosadministracionDto dto, planillaconceptosadministracion entity);

        /// <summary>
        /// Converts this instance of <see cref="planillaconceptosadministracionDto"/> to an instance of <see cref="planillaconceptosadministracion"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillaconceptosadministracionDto"/> to convert.</param>
        public static planillaconceptosadministracion ToEntity(this planillaconceptosadministracionDto dto)
        {
            if (dto == null) return null;

            var entity = new planillaconceptosadministracion();

            entity.i_Id = dto.i_Id;
            entity.v_IdConceptoPlanilla = dto.v_IdConceptoPlanilla;
            entity.i_IdGrupo = dto.i_IdGrupo;
            entity.i_IdColumnaEquivalente = dto.i_IdColumnaEquivalente;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillaconceptosadministracion"/> to an instance of <see cref="planillaconceptosadministracionDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillaconceptosadministracion"/> to convert.</param>
        public static planillaconceptosadministracionDto ToDTO(this planillaconceptosadministracion entity)
        {
            if (entity == null) return null;

            var dto = new planillaconceptosadministracionDto();

            dto.i_Id = entity.i_Id;
            dto.v_IdConceptoPlanilla = entity.v_IdConceptoPlanilla;
            dto.i_IdGrupo = entity.i_IdGrupo;
            dto.i_IdColumnaEquivalente = entity.i_IdColumnaEquivalente;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaconceptosadministracionDto"/> to an instance of <see cref="planillaconceptosadministracion"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillaconceptosadministracion> ToEntities(this IEnumerable<planillaconceptosadministracionDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaconceptosadministracion"/> to an instance of <see cref="planillaconceptosadministracionDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillaconceptosadministracionDto> ToDTOs(this IEnumerable<planillaconceptosadministracion> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
