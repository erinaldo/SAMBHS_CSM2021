//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/18 - 16:17:28
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
    /// Assembler for <see cref="diario"/> and <see cref="diarioDto"/>.
    /// </summary>
    public static partial class diarioAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="diarioDto"/> converted from <see cref="diario"/>.</param>
        static partial void OnDTO(this diario entity, diarioDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="diario"/> converted from <see cref="diarioDto"/>.</param>
        static partial void OnEntity(this diarioDto dto, diario entity);

        /// <summary>
        /// Converts this instance of <see cref="diarioDto"/> to an instance of <see cref="diario"/>.
        /// </summary>
        /// <param name="dto"><see cref="diarioDto"/> to convert.</param>
        public static diario ToEntity(this diarioDto dto)
        {
            if (dto == null) return null;

            var entity = new diario();

            entity.v_IdDiario = dto.v_IdDiario;
            entity.v_IdDocumentoReferencia = dto.v_IdDocumentoReferencia;
            entity.i_IdPlanillaNumeracion = dto.i_IdPlanillaNumeracion;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.i_IdTipoComprobante = dto.i_IdTipoComprobante;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.i_IdEstado = dto.i_IdEstado;
            entity.v_Nombre = dto.v_Nombre;
            entity.v_Glosa = dto.v_Glosa;
            entity.t_Fecha = dto.t_Fecha;
            entity.d_TotalDebe = dto.d_TotalDebe;
            entity.d_TotalHaber = dto.d_TotalHaber;
            entity.d_TotalDebeCambio = dto.d_TotalDebeCambio;
            entity.d_TotalHaberCambio = dto.d_TotalHaberCambio;
            entity.d_DiferenciaDebe = dto.d_DiferenciaDebe;
            entity.d_DiferenciaHaber = dto.d_DiferenciaHaber;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_MotivoEliminacion = dto.v_MotivoEliminacion;
            entity.i_AfectaDetraccion = dto.i_AfectaDetraccion;
            entity.d_TasaDetraccion = dto.d_TasaDetraccion;
            entity.i_IdTipoOperacionDetraccion = dto.i_IdTipoOperacionDetraccion;
            entity.i_IdCodigoDetraccion = dto.i_IdCodigoDetraccion;
            entity.t_FechaVencimiento = dto.t_FechaVencimiento;
            entity.t_FechaEmision = dto.t_FechaEmision;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="diario"/> to an instance of <see cref="diarioDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="diario"/> to convert.</param>
        public static diarioDto ToDTO(this diario entity)
        {
            if (entity == null) return null;

            var dto = new diarioDto();

            dto.v_IdDiario = entity.v_IdDiario;
            dto.v_IdDocumentoReferencia = entity.v_IdDocumentoReferencia;
            dto.i_IdPlanillaNumeracion = entity.i_IdPlanillaNumeracion;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.i_IdTipoComprobante = entity.i_IdTipoComprobante;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.i_IdEstado = entity.i_IdEstado;
            dto.v_Nombre = entity.v_Nombre;
            dto.v_Glosa = entity.v_Glosa;
            dto.t_Fecha = entity.t_Fecha;
            dto.d_TotalDebe = entity.d_TotalDebe;
            dto.d_TotalHaber = entity.d_TotalHaber;
            dto.d_TotalDebeCambio = entity.d_TotalDebeCambio;
            dto.d_TotalHaberCambio = entity.d_TotalHaberCambio;
            dto.d_DiferenciaDebe = entity.d_DiferenciaDebe;
            dto.d_DiferenciaHaber = entity.d_DiferenciaHaber;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_MotivoEliminacion = entity.v_MotivoEliminacion;
            dto.i_AfectaDetraccion = entity.i_AfectaDetraccion;
            dto.d_TasaDetraccion = entity.d_TasaDetraccion;
            dto.i_IdTipoOperacionDetraccion = entity.i_IdTipoOperacionDetraccion;
            dto.i_IdCodigoDetraccion = entity.i_IdCodigoDetraccion;
            dto.t_FechaVencimiento = entity.t_FechaVencimiento;
            dto.t_FechaEmision = entity.t_FechaEmision;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="diarioDto"/> to an instance of <see cref="diario"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<diario> ToEntities(this IEnumerable<diarioDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="diario"/> to an instance of <see cref="diarioDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<diarioDto> ToDTOs(this IEnumerable<diario> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
