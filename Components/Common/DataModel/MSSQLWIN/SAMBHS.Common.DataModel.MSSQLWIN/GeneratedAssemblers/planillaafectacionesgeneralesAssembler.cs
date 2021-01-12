//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:59
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
    /// Assembler for <see cref="planillaafectacionesgenerales"/> and <see cref="planillaafectacionesgeneralesDto"/>.
    /// </summary>
    public static partial class planillaafectacionesgeneralesAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="planillaafectacionesgeneralesDto"/> converted from <see cref="planillaafectacionesgenerales"/>.</param>
        static partial void OnDTO(this planillaafectacionesgenerales entity, planillaafectacionesgeneralesDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="planillaafectacionesgenerales"/> converted from <see cref="planillaafectacionesgeneralesDto"/>.</param>
        static partial void OnEntity(this planillaafectacionesgeneralesDto dto, planillaafectacionesgenerales entity);

        /// <summary>
        /// Converts this instance of <see cref="planillaafectacionesgeneralesDto"/> to an instance of <see cref="planillaafectacionesgenerales"/>.
        /// </summary>
        /// <param name="dto"><see cref="planillaafectacionesgeneralesDto"/> to convert.</param>
        public static planillaafectacionesgenerales ToEntity(this planillaafectacionesgeneralesDto dto)
        {
            if (dto == null) return null;

            var entity = new planillaafectacionesgenerales();

            entity.i_Id = dto.i_Id;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_IdConceptoPlanilla = dto.v_IdConceptoPlanilla;
            entity.i_Leyes_Trab_ONP = dto.i_Leyes_Trab_ONP;
            entity.i_Leyes_Trab_Senati = dto.i_Leyes_Trab_Senati;
            entity.i_Leyes_Trab_SCTR = dto.i_Leyes_Trab_SCTR;
            entity.i_Leyes_Emp_Essalud = dto.i_Leyes_Emp_Essalud;
            entity.i_Leyes_Emp_SCTR = dto.i_Leyes_Emp_SCTR;
            entity.i_AFP_Afecto = dto.i_AFP_Afecto;
            entity.i_Rent5ta_Afecto = dto.i_Rent5ta_Afecto;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="planillaafectacionesgenerales"/> to an instance of <see cref="planillaafectacionesgeneralesDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="planillaafectacionesgenerales"/> to convert.</param>
        public static planillaafectacionesgeneralesDto ToDTO(this planillaafectacionesgenerales entity)
        {
            if (entity == null) return null;

            var dto = new planillaafectacionesgeneralesDto();

            dto.i_Id = entity.i_Id;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_IdConceptoPlanilla = entity.v_IdConceptoPlanilla;
            dto.i_Leyes_Trab_ONP = entity.i_Leyes_Trab_ONP;
            dto.i_Leyes_Trab_Senati = entity.i_Leyes_Trab_Senati;
            dto.i_Leyes_Trab_SCTR = entity.i_Leyes_Trab_SCTR;
            dto.i_Leyes_Emp_Essalud = entity.i_Leyes_Emp_Essalud;
            dto.i_Leyes_Emp_SCTR = entity.i_Leyes_Emp_SCTR;
            dto.i_AFP_Afecto = entity.i_AFP_Afecto;
            dto.i_Rent5ta_Afecto = entity.i_Rent5ta_Afecto;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaafectacionesgeneralesDto"/> to an instance of <see cref="planillaafectacionesgenerales"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<planillaafectacionesgenerales> ToEntities(this IEnumerable<planillaafectacionesgeneralesDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="planillaafectacionesgenerales"/> to an instance of <see cref="planillaafectacionesgeneralesDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<planillaafectacionesgeneralesDto> ToDTOs(this IEnumerable<planillaafectacionesgenerales> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
