//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:14:28
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
    /// Assembler for <see cref="planillavaloresrentaquinta"/> and <see cref="planillavaloresrentaquintaDto"/>.
    /// </summary>
    public static partial class planillavaloresrentaquintaAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillavaloresrentaquintaDto"/> converted from <see cref="planillavaloresrentaquinta"/>.</param>
        static partial void OnDTO(this planillavaloresrentaquinta entity, planillavaloresrentaquintaDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillavaloresrentaquinta"/> converted from <see cref="planillavaloresrentaquintaDto"/>.</param>
        static partial void OnEntity(this planillavaloresrentaquintaDto dto, planillavaloresrentaquinta entity);

        /// <summary>
        /// Converts this instance of <see cref="planillavaloresrentaquintaDto"/> to an instance of <see cref="planillavaloresrentaquinta"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillavaloresrentaquintaDto"/> to convert.</param>
        public static planillavaloresrentaquinta ToEntity(this planillavaloresrentaquintaDto dto)
        {
            if (dto == null) return null;

            var entity = new planillavaloresrentaquinta();

            entity.i_Id = dto.i_Id;
            entity.v_Periodo = dto.v_Periodo;
            entity.i_Tope1 = dto.i_Tope1;
            entity.d_Porcentaje1 = dto.d_Porcentaje1;
            entity.i_Tope2 = dto.i_Tope2;
            entity.d_Porcentaje2 = dto.d_Porcentaje2;
            entity.i_Tope3 = dto.i_Tope3;
            entity.d_Porcentaje3 = dto.d_Porcentaje3;
            entity.i_Tope4 = dto.i_Tope4;
            entity.d_Porcentaje4 = dto.d_Porcentaje4;
            entity.d_Porcentaje4Superior = dto.d_Porcentaje4Superior;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_IdConceptoPlanillaRenta5T = dto.v_IdConceptoPlanillaRenta5T;
            entity.v_IdConceptoPlanillaGratificacion = dto.v_IdConceptoPlanillaGratificacion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillavaloresrentaquinta"/> to an instance of <see cref="planillavaloresrentaquintaDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillavaloresrentaquinta"/> to convert.</param>
        public static planillavaloresrentaquintaDto ToDTO(this planillavaloresrentaquinta entity)
        {
            if (entity == null) return null;

            var dto = new planillavaloresrentaquintaDto();

            dto.i_Id = entity.i_Id;
            dto.v_Periodo = entity.v_Periodo;
            dto.i_Tope1 = entity.i_Tope1;
            dto.d_Porcentaje1 = entity.d_Porcentaje1;
            dto.i_Tope2 = entity.i_Tope2;
            dto.d_Porcentaje2 = entity.d_Porcentaje2;
            dto.i_Tope3 = entity.i_Tope3;
            dto.d_Porcentaje3 = entity.d_Porcentaje3;
            dto.i_Tope4 = entity.i_Tope4;
            dto.d_Porcentaje4 = entity.d_Porcentaje4;
            dto.d_Porcentaje4Superior = entity.d_Porcentaje4Superior;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_IdConceptoPlanillaRenta5T = entity.v_IdConceptoPlanillaRenta5T;
            dto.v_IdConceptoPlanillaGratificacion = entity.v_IdConceptoPlanillaGratificacion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillavaloresrentaquintaDto"/> to an instance of <see cref="planillavaloresrentaquinta"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillavaloresrentaquinta> ToEntities(this IEnumerable<planillavaloresrentaquintaDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillavaloresrentaquinta"/> to an instance of <see cref="planillavaloresrentaquintaDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillavaloresrentaquintaDto> ToDTOs(this IEnumerable<planillavaloresrentaquinta> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
