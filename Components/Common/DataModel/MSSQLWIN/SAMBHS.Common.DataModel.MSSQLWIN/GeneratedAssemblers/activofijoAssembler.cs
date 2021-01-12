//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/19 - 18:13:12
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
    /// Assembler for <see cref="activofijo"/> and <see cref="activofijoDto"/>.
    /// </summary>
    public static partial class activofijoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="activofijoDto"/> converted from <see cref="activofijo"/>.</param>
        static partial void OnDTO(this activofijo entity, activofijoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="activofijo"/> converted from <see cref="activofijoDto"/>.</param>
        static partial void OnEntity(this activofijoDto dto, activofijo entity);

        /// <summary>
        /// Converts this instance of <see cref="activofijoDto"/> to an instance of <see cref="activofijo"/>.
        /// </summary>
        /// <param name="dto"><see cref="activofijoDto"/> to convert.</param>
        public static activofijo ToEntity(this activofijoDto dto)
        {
            if (dto == null) return null;

            var entity = new activofijo();

            entity.v_IdActivoFijo = dto.v_IdActivoFijo;
            entity.v_IdProducto = dto.v_IdProducto;
            entity.i_IdTipoMotivo = dto.i_IdTipoMotivo;
            entity.v_Periodo = dto.v_Periodo;
            entity.v_CodigoActivoFijo = dto.v_CodigoActivoFijo;
            entity.v_Descricpion = dto.v_Descricpion;
            entity.v_Marca = dto.v_Marca;
            entity.v_Modelo = dto.v_Modelo;
            entity.v_Serie = dto.v_Serie;
            entity.v_Placa = dto.v_Placa;
            entity.i_IdTipoActivo = dto.i_IdTipoActivo;
            entity.i_IdTipoAdquisicion = dto.i_IdTipoAdquisicion;
            entity.v_Color = dto.v_Color;
            entity.v_CodigoAnterior = dto.v_CodigoAnterior;
            entity.i_IdEstado = dto.i_IdEstado;
            entity.i_IdTipoIntangible = dto.i_IdTipoIntangible;
            entity.d_ValorActualizadoMn = dto.d_ValorActualizadoMn;
            entity.d_ValorAdquisicionMe = dto.d_ValorAdquisicionMe;
            entity.d_ValorActualizadoMe = dto.d_ValorActualizadoMe;
            entity.d_ValorAdquisicionMn = dto.d_ValorAdquisicionMn;
            entity.i_MesesDepreciadosPAnterior = dto.i_MesesDepreciadosPAnterior;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.v_OrdenCompra = dto.v_OrdenCompra;
            entity.t_FechaOrdenCompra = dto.t_FechaOrdenCompra;
            entity.v_NumeroFactura = dto.v_NumeroFactura;
            entity.t_FechaFactura = dto.t_FechaFactura;
            entity.d_MonedaNacional = dto.d_MonedaNacional;
            entity.d_MonedaExtranjera = dto.d_MonedaExtranjera;
            entity.i_IdUbicacion = dto.i_IdUbicacion;
            entity.i_IdCentroCosto = dto.i_IdCentroCosto;
            entity.v_IdResponsable = dto.v_IdResponsable;
            entity.v_NroContrato = dto.v_NroContrato;
            entity.i_NumeroCuotas = dto.i_NumeroCuotas;
            entity.t_FechaUso = dto.t_FechaUso;
            entity.i_Depreciara = dto.i_Depreciara;
            entity.i_IdMesesDepreciara = dto.i_IdMesesDepreciara;
            entity.i_Baja = dto.i_Baja;
            entity.t_FechaBaja = dto.t_FechaBaja;
            entity.v_MotivoBaja = dto.v_MotivoBaja;
            entity.i_Transferencia = dto.i_Transferencia;
            entity.t_FechaTransferencia = dto.t_FechaTransferencia;
            entity.i_IdTipoActivoTransferencia = dto.i_IdTipoActivoTransferencia;
            entity.i_Ajuste = dto.i_Ajuste;
            entity.t_FechaAjuste = dto.t_FechaAjuste;
            entity.i_MesesAjuste = dto.i_MesesAjuste;
            entity.i_Asignacion = dto.i_Asignacion;
            entity.i_EsTemporal = dto.i_EsTemporal;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_PeriodoAnterior = dto.v_PeriodoAnterior;
            entity.b_Foto = dto.b_Foto;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.v_UbicacionFoto = dto.v_UbicacionFoto;
            entity.i_IdSituacionActivoFijo = dto.i_IdSituacionActivoFijo;
            entity.i_IdClaseActivoFijo = dto.i_IdClaseActivoFijo;
            entity.v_CodigoOriginal = dto.v_CodigoOriginal;
            entity.v_AnioFabricacion = dto.v_AnioFabricacion;
            entity.v_CodigoBarras = dto.v_CodigoBarras;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="activofijo"/> to an instance of <see cref="activofijoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="activofijo"/> to convert.</param>
        public static activofijoDto ToDTO(this activofijo entity)
        {
            if (entity == null) return null;

            var dto = new activofijoDto();

            dto.v_IdActivoFijo = entity.v_IdActivoFijo;
            dto.v_IdProducto = entity.v_IdProducto;
            dto.i_IdTipoMotivo = entity.i_IdTipoMotivo;
            dto.v_Periodo = entity.v_Periodo;
            dto.v_CodigoActivoFijo = entity.v_CodigoActivoFijo;
            dto.v_Descricpion = entity.v_Descricpion;
            dto.v_Marca = entity.v_Marca;
            dto.v_Modelo = entity.v_Modelo;
            dto.v_Serie = entity.v_Serie;
            dto.v_Placa = entity.v_Placa;
            dto.i_IdTipoActivo = entity.i_IdTipoActivo;
            dto.i_IdTipoAdquisicion = entity.i_IdTipoAdquisicion;
            dto.v_Color = entity.v_Color;
            dto.v_CodigoAnterior = entity.v_CodigoAnterior;
            dto.i_IdEstado = entity.i_IdEstado;
            dto.i_IdTipoIntangible = entity.i_IdTipoIntangible;
            dto.d_ValorActualizadoMn = entity.d_ValorActualizadoMn;
            dto.d_ValorAdquisicionMe = entity.d_ValorAdquisicionMe;
            dto.d_ValorActualizadoMe = entity.d_ValorActualizadoMe;
            dto.d_ValorAdquisicionMn = entity.d_ValorAdquisicionMn;
            dto.i_MesesDepreciadosPAnterior = entity.i_MesesDepreciadosPAnterior;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.v_OrdenCompra = entity.v_OrdenCompra;
            dto.t_FechaOrdenCompra = entity.t_FechaOrdenCompra;
            dto.v_NumeroFactura = entity.v_NumeroFactura;
            dto.t_FechaFactura = entity.t_FechaFactura;
            dto.d_MonedaNacional = entity.d_MonedaNacional;
            dto.d_MonedaExtranjera = entity.d_MonedaExtranjera;
            dto.i_IdUbicacion = entity.i_IdUbicacion;
            dto.i_IdCentroCosto = entity.i_IdCentroCosto;
            dto.v_IdResponsable = entity.v_IdResponsable;
            dto.v_NroContrato = entity.v_NroContrato;
            dto.i_NumeroCuotas = entity.i_NumeroCuotas;
            dto.t_FechaUso = entity.t_FechaUso;
            dto.i_Depreciara = entity.i_Depreciara;
            dto.i_IdMesesDepreciara = entity.i_IdMesesDepreciara;
            dto.i_Baja = entity.i_Baja;
            dto.t_FechaBaja = entity.t_FechaBaja;
            dto.v_MotivoBaja = entity.v_MotivoBaja;
            dto.i_Transferencia = entity.i_Transferencia;
            dto.t_FechaTransferencia = entity.t_FechaTransferencia;
            dto.i_IdTipoActivoTransferencia = entity.i_IdTipoActivoTransferencia;
            dto.i_Ajuste = entity.i_Ajuste;
            dto.t_FechaAjuste = entity.t_FechaAjuste;
            dto.i_MesesAjuste = entity.i_MesesAjuste;
            dto.i_Asignacion = entity.i_Asignacion;
            dto.i_EsTemporal = entity.i_EsTemporal;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_PeriodoAnterior = entity.v_PeriodoAnterior;
            dto.b_Foto = entity.b_Foto;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.v_UbicacionFoto = entity.v_UbicacionFoto;
            dto.i_IdSituacionActivoFijo = entity.i_IdSituacionActivoFijo;
            dto.i_IdClaseActivoFijo = entity.i_IdClaseActivoFijo;
            dto.v_CodigoOriginal = entity.v_CodigoOriginal;
            dto.v_AnioFabricacion = entity.v_AnioFabricacion;
            dto.v_CodigoBarras = entity.v_CodigoBarras;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="activofijoDto"/> to an instance of <see cref="activofijo"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<activofijo> ToEntities(this IEnumerable<activofijoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="activofijo"/> to an instance of <see cref="activofijoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<activofijoDto> ToDTOs(this IEnumerable<activofijo> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
