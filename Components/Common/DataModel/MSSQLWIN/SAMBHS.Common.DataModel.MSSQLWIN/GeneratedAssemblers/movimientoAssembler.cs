//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:14:12
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
    /// Assembler for <see cref="movimiento"/> and <see cref="movimientoDto"/>.
    /// </summary>
    public static partial class movimientoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="movimientoDto"/> converted from <see cref="movimiento"/>.</param>
        static partial void OnDTO(this movimiento entity, movimientoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="movimiento"/> converted from <see cref="movimientoDto"/>.</param>
        static partial void OnEntity(this movimientoDto dto, movimiento entity);

        /// <summary>
        /// Converts this instance of <see cref="movimientoDto"/> to an instance of <see cref="movimiento"/>.
        /// </summary>
        /// <param name="dto"><see cref="movimientoDto"/> to convert.</param>
        public static movimiento ToEntity(this movimientoDto dto)
        {
            if (dto == null) return null;

            var entity = new movimiento();

            entity.v_IdMovimiento = dto.v_IdMovimiento;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_Mes = dto.v_Mes;
            entity.v_Correlativo = dto.v_Correlativo;
            entity.i_IdEstablecimiento = dto.i_IdEstablecimiento;
            entity.i_IdAlmacenOrigen = dto.i_IdAlmacenOrigen;
            entity.i_IdAlmacenDestino = dto.i_IdAlmacenDestino;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.i_IdTipoMovimiento = dto.i_IdTipoMovimiento;
            entity.t_Fecha = dto.t_Fecha;
            entity.d_TipoCambio = dto.d_TipoCambio;
            entity.i_IdTipoMotivo = dto.i_IdTipoMotivo;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.v_Glosa = dto.v_Glosa;
            entity.d_TotalPrecio = dto.d_TotalPrecio;
            entity.d_TotalCantidad = dto.d_TotalCantidad;
            entity.v_OrigenTipo = dto.v_OrigenTipo;
            entity.v_OrigenRegPeriodo = dto.v_OrigenRegPeriodo;
            entity.v_OrigenRegMes = dto.v_OrigenRegMes;
            entity.v_OrigenRegCorrelativo = dto.v_OrigenRegCorrelativo;
            entity.i_EsDevolucion = dto.i_EsDevolucion;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_IdMovimientoOrigen = dto.v_IdMovimientoOrigen;
            entity.i_GenerarGuia = dto.i_GenerarGuia;
            entity.v_NroOrdenCompra = dto.v_NroOrdenCompra;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_SerieDocumento = dto.v_SerieDocumento;
            entity.v_CorrelativoDocumento = dto.v_CorrelativoDocumento;
            entity.v_NroGuiaVenta = dto.v_NroGuiaVenta;
            entity.i_IdDireccionCliente = dto.i_IdDireccionCliente;
            entity.v_MotivoEliminacion = dto.v_MotivoEliminacion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="movimiento"/> to an instance of <see cref="movimientoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="movimiento"/> to convert.</param>
        public static movimientoDto ToDTO(this movimiento entity)
        {
            if (entity == null) return null;

            var dto = new movimientoDto();

            dto.v_IdMovimiento = entity.v_IdMovimiento;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_Mes = entity.v_Mes;
            dto.v_Correlativo = entity.v_Correlativo;
            dto.i_IdEstablecimiento = entity.i_IdEstablecimiento;
            dto.i_IdAlmacenOrigen = entity.i_IdAlmacenOrigen;
            dto.i_IdAlmacenDestino = entity.i_IdAlmacenDestino;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.i_IdTipoMovimiento = entity.i_IdTipoMovimiento;
            dto.t_Fecha = entity.t_Fecha;
            dto.d_TipoCambio = entity.d_TipoCambio;
            dto.i_IdTipoMotivo = entity.i_IdTipoMotivo;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.v_Glosa = entity.v_Glosa;
            dto.d_TotalPrecio = entity.d_TotalPrecio;
            dto.d_TotalCantidad = entity.d_TotalCantidad;
            dto.v_OrigenTipo = entity.v_OrigenTipo;
            dto.v_OrigenRegPeriodo = entity.v_OrigenRegPeriodo;
            dto.v_OrigenRegMes = entity.v_OrigenRegMes;
            dto.v_OrigenRegCorrelativo = entity.v_OrigenRegCorrelativo;
            dto.i_EsDevolucion = entity.i_EsDevolucion;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_IdMovimientoOrigen = entity.v_IdMovimientoOrigen;
            dto.i_GenerarGuia = entity.i_GenerarGuia;
            dto.v_NroOrdenCompra = entity.v_NroOrdenCompra;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_SerieDocumento = entity.v_SerieDocumento;
            dto.v_CorrelativoDocumento = entity.v_CorrelativoDocumento;
            dto.v_NroGuiaVenta = entity.v_NroGuiaVenta;
            dto.i_IdDireccionCliente = entity.i_IdDireccionCliente;
            dto.v_MotivoEliminacion = entity.v_MotivoEliminacion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="movimientoDto"/> to an instance of <see cref="movimiento"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<movimiento> ToEntities(this IEnumerable<movimientoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="movimiento"/> to an instance of <see cref="movimientoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<movimientoDto> ToDTOs(this IEnumerable<movimiento> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
