//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:18
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
    /// Assembler for <see cref="contratotrabajador"/> and <see cref="contratotrabajadorDto"/>.
    /// </summary>
    public static partial class contratotrabajadorAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="contratotrabajadorDto"/> converted from <see cref="contratotrabajador"/>.</param>
        static partial void OnDTO(this contratotrabajador entity, contratotrabajadorDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="contratotrabajador"/> converted from <see cref="contratotrabajadorDto"/>.</param>
        static partial void OnEntity(this contratotrabajadorDto dto, contratotrabajador entity);

        /// <summary>
        /// Converts this instance of <see cref="contratotrabajadorDto"/> to an instance of <see cref="contratotrabajador"/>.
        /// </summary>
        /// <param name="dto"><see cref="contratotrabajadorDto"/> to convert.</param>
        public static contratotrabajador ToEntity(this contratotrabajadorDto dto)
        {
            if (dto == null) return null;

            var entity = new contratotrabajador();

            entity.v_IdContrato = dto.v_IdContrato;
            entity.v_IdTrabajador = dto.v_IdTrabajador;
            entity.v_NroContrato = dto.v_NroContrato;
            entity.i_ContratoVigente = dto.i_ContratoVigente;
            entity.i_IdTipoContrato = dto.i_IdTipoContrato;
            entity.i_IdTipoPlanilla = dto.i_IdTipoPlanilla;
            entity.i_IdMonedaContrato = dto.i_IdMonedaContrato;
            entity.d_Importe = dto.d_Importe;
            entity.t_FechaInicio = dto.t_FechaInicio;
            entity.t_FechaFin = dto.t_FechaFin;
            entity.i_IdMotivoBaja = dto.i_IdMotivoBaja;
            entity.i_IdModalidadFormativa = dto.i_IdModalidadFormativa;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.t_HoraIngreso = dto.t_HoraIngreso;
            entity.t_HoraSalida = dto.t_HoraSalida;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="contratotrabajador"/> to an instance of <see cref="contratotrabajadorDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="contratotrabajador"/> to convert.</param>
        public static contratotrabajadorDto ToDTO(this contratotrabajador entity)
        {
            if (entity == null) return null;

            var dto = new contratotrabajadorDto();

            dto.v_IdContrato = entity.v_IdContrato;
            dto.v_IdTrabajador = entity.v_IdTrabajador;
            dto.v_NroContrato = entity.v_NroContrato;
            dto.i_ContratoVigente = entity.i_ContratoVigente;
            dto.i_IdTipoContrato = entity.i_IdTipoContrato;
            dto.i_IdTipoPlanilla = entity.i_IdTipoPlanilla;
            dto.i_IdMonedaContrato = entity.i_IdMonedaContrato;
            dto.d_Importe = entity.d_Importe;
            dto.t_FechaInicio = entity.t_FechaInicio;
            dto.t_FechaFin = entity.t_FechaFin;
            dto.i_IdMotivoBaja = entity.i_IdMotivoBaja;
            dto.i_IdModalidadFormativa = entity.i_IdModalidadFormativa;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.t_HoraIngreso = entity.t_HoraIngreso;
            dto.t_HoraSalida = entity.t_HoraSalida;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="contratotrabajadorDto"/> to an instance of <see cref="contratotrabajador"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<contratotrabajador> ToEntities(this IEnumerable<contratotrabajadorDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="contratotrabajador"/> to an instance of <see cref="contratotrabajadorDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<contratotrabajadorDto> ToDTOs(this IEnumerable<contratotrabajador> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
